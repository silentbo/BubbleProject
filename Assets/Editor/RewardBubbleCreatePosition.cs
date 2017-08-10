using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEditor;
using Random = UnityEngine.Random;

// 工具
public static class RewardBubbleCreatePosition {

    // 结构体 奖励泡泡的数据
    struct RewardBubbleData
    {
        public float posX;
        public float posY;
        public float scaleRadiu;
    }

    // 有多少个奖励泡泡
    private static List<RewardBubbleData> listRewardBubbleDatas = new List<RewardBubbleData>();

    [MenuItem("silentTools/CreateOneRewardBubblePosition")]
	static void CreateOneRewardBubblePosition()
    {
        Debug.Log("-- silent -- 开始创建奖励泡泡");

        Sprite spriteRewardBubble = Resources.Load<Sprite>("Player/bubble_02");

        float randomX = Random.Range( -ConstTemplate.screenWith / 2, ConstTemplate.screenWith / 2);
        float randomY = Random.Range(0.0f, ConstTemplate.screenHeight * 1.5f);
        float randomYInterval = Random.Range(0.8f, 2.0f);
        randomY += randomYInterval;

        GameObject goRewardBubble = new GameObject();
        goRewardBubble.transform.localPosition = new Vector3(randomX, randomY);
        goRewardBubble.transform.parent = GameObject.Find("root/reward_bubbles").transform;
        goRewardBubble.name = "rewardBubbleRandom";

        SpriteRenderer spriteRendererRewardBubble = goRewardBubble.AddComponent<SpriteRenderer>();
        spriteRendererRewardBubble.sprite = spriteRewardBubble;
        spriteRendererRewardBubble.sortingLayerName = "other_object";


        Debug.Log("-- silent -- 结束创建奖励泡泡");
    }

    [MenuItem("silentTools/CreateMultiRewardBubblePosition")]
    static void CreateMultiRewardBubblePosition()
    {
        Debug.Log("-- silent -- 开始创建各个关卡的多个奖励泡泡");

        // 读取外部配置文件
        string strCreateRewardBubbleDataAllLevelPath = Application.dataPath + "/Resources/Data/RewardBubbleData/RewardBubbleDataAllLevel.txt";

        //string strDateAllLevel = File.ReadAllText(strCreateRewardBubbleDataAllLevelPath); // (第几关，没关中的奖励泡泡的数量),(1,100),(2,150)
        string[] strAllRewardCount = File.ReadAllLines(strCreateRewardBubbleDataAllLevelPath);

        // 去掉前1个
        for (int istr = 1; istr < strAllRewardCount.Length; istr ++)
        {
            // 解析字符串
            string strLevelData = strAllRewardCount[istr];
            string[] strLevelDataSqlit = strLevelData.Split(',', '(', ')', ' ');

            // 需要创建的第几个关卡
            int createNums = int.Parse(strLevelDataSqlit[0]);
            Debug.Log("-- silent -- createNums = " + createNums);

            // 清理奖励泡泡列表
            listRewardBubbleDatas.Clear();

            // 需要创建的奖励泡泡的数量
            int rewardBubbleCount = int.Parse(strLevelDataSqlit[1]);

            // 随机生成奖励泡泡的起始高度
            float randomY = Random.Range(0.0f, ConstTemplate.screenHeight);

            // 创建每个奖励泡泡
            for (int i = 0; i < rewardBubbleCount; i ++)
            {
                Sprite spriteRewardBubble = Resources.Load<Sprite>("Player/bubble_02_65");
                float randomX = Random.Range(-ConstTemplate.screenWith * 0.4f, ConstTemplate.screenWith * 0.4f);
                float randomYInterval = Random.Range(ConstTemplate.playerRadius * 2.0f, ConstTemplate.playerRadius * 5f);
                randomY += randomYInterval;

                float randomScalc = Random.Range(0.3f, 0.8f);

                listRewardBubbleDatas.Add(new RewardBubbleData()
                {
                    posX = randomX,
                    posY = randomY,
                    scaleRadiu = randomScalc
                });

                GameObject goRewardBubble = new GameObject();
                goRewardBubble.transform.parent = GameObject.Find("root/reward_bubbles").transform;
                goRewardBubble.name = "rewardBubbleRandom" + i.ToString();
                goRewardBubble.tag = "reward_bubble";
                goRewardBubble.transform.localPosition = new Vector3(randomX, randomY);
                goRewardBubble.transform.localScale = new Vector3(randomScalc, randomScalc, randomScalc);

                SpriteRenderer spriteRendererRewardBubble = goRewardBubble.AddComponent<SpriteRenderer>();
                spriteRendererRewardBubble.sprite = spriteRewardBubble;
                spriteRendererRewardBubble.sortingLayerName = "other_object";

                MoveDownTemplate moveDownRewardBubble = goRewardBubble.AddComponent<MoveDownTemplate>();
                moveDownRewardBubble.isAnimation = true;
                moveDownRewardBubble.speedMoveDown = 1.8f;

                // 添加碰撞盒
                goRewardBubble.AddComponent<CircleCollider2D>();

                // 添加 RewardBubble 组件， 设置其属性
                RewardBubble rewardBubble = goRewardBubble.AddComponent<RewardBubble>();
                rewardBubble.hpRewardBubble = randomScalc * ConstTemplate.rewardBubbleMaxHp;
                rewardBubble.scoreRewardBubble = randomScalc * ConstTemplate.rewardBubbleMaxScore;
                rewardBubble.scaleRewardBubble = randomScalc;
                rewardBubble.speedMoveToPlayer = randomScalc * ConstTemplate.rewardBubbleSpeedMoveToPlayerMax;
                rewardBubble.isEaten = false;
            }

            SaveRewardBubblePositionAndScaleData(createNums);
        }

        Debug.Log("-- silent -- 结束创建各个关卡的多个奖励泡泡");

    }

    // 保存 关卡 奖励泡泡的 位置，缩放 等信息
    private static void SaveRewardBubblePositionAndScaleData(int createNums)
    {
        Debug.Log("-- silent -- 开始保存奖励泡泡数据");
        string strSaveRewardBubbleDataPath = Application.dataPath + "/Resources/Data/RewardBubbleData/RewardBubbleDataLevel_" + createNums.ToString() + ".json";

        // json格式：
        // { "student":[ {"name":"a", "num":"19", "sex":"m"}, {"name":"b", "num":"20", "sex":"w"} ] }

        // {"reward_bubble_data":[ {"id":"0", "randomX":"1.0", "randomY":"1.0", "randomScale":"1.0"}, ······ ]}
        string strDataBegin = "{\n\t\"reward_bubble_data\":\n\t[";
        string strDataEnd = "\n\t]\n}";
        //string strContentTemplate = "\n\t\t{\n\t\t\t\"id\":\"{0}\", \n\t\t\t\"randomX\":\"{1}\", \n\t\t\t\"randomY\":\"{2}\", \n\t\t\t\"randomScale\":\"{3}\"\n\t\t}";
        StringBuilder stringBuilderDataContent = new StringBuilder();
        stringBuilderDataContent.Append(strDataBegin);
        for (int i = 0; i < listRewardBubbleDatas.Count; i ++)
        {
            //stringBuilderDataContent.Append(string.Format(strContentTemplate, i + 1, listRewardBubbleDatas[i].posX,
            //    listRewardBubbleDatas[i].posY, listRewardBubbleDatas[i].scaleRadiu));

            stringBuilderDataContent.Append("\n\t\t{\n\t\t\t\"id\":\"");
            stringBuilderDataContent.Append(i+1);
            stringBuilderDataContent.Append("\", \n\t\t\t\"randomX\":\"");
            stringBuilderDataContent.Append(listRewardBubbleDatas[i].posX);
            stringBuilderDataContent.Append("\", \n\t\t\t\"randomY\":\"");
            stringBuilderDataContent.Append(listRewardBubbleDatas[i].posY);
            stringBuilderDataContent.Append("\", \n\t\t\t\"randomScale\":\"");
            stringBuilderDataContent.Append(listRewardBubbleDatas[i].scaleRadiu);
            stringBuilderDataContent.Append("\"\n\t\t}");

            if (i < listRewardBubbleDatas.Count - 1)
                stringBuilderDataContent.Append(",");
        }

        stringBuilderDataContent.Append(strDataEnd);

        Debug.Log("-- silent -- data = ---------- begin ");
        Debug.Log(stringBuilderDataContent.ToString());
        Debug.Log("-- silent -- data = ---------- end ");

        Debug.Log("-- silent -- 开始写入json文件");

        File.WriteAllText(strSaveRewardBubbleDataPath, stringBuilderDataContent.ToString());

        Debug.Log("-- silent -- 结束写入json文件");

        Debug.Log("-- silent -- 结束保存奖励泡泡数据");
    }


    [MenuItem("silentTools/CrewatMultiRewardBubblePositionOrganize")]
    public static void CrewatMultiRewardBubblePositionOrganize()
    {
        Debug.Log("-- silent -- 开始创建各个关卡的多个奖励泡泡(有规律的)");

        // 读取外部配置文件
        string strCreateRewardBubbleDataAllLevelPath = Application.dataPath + "/Resources/Data/RewardBubbleData/RewardBubbleDataAllLevel.txt";

        //string strDateAllLevel = File.ReadAllText(strCreateRewardBubbleDataAllLevelPath); // (第几关，没关中的奖励泡泡的数量),(1,100),(2,150)
        string[] strAllRewardCount = File.ReadAllLines(strCreateRewardBubbleDataAllLevelPath);

        // 去掉前1个
        for (int istr = 1; istr < strAllRewardCount.Length; istr ++)
        {
            // 解析字符串
            string strLevelData = strAllRewardCount[istr];
            string[] strLevelDataSqlit = strLevelData.Split(',', '(', ')', ' ');

            // 需要创建的第几个关卡
            int createNums = int.Parse(strLevelDataSqlit[0]);
            Debug.Log("-- silent -- createNums = " + createNums);

            // 清理奖励泡泡列表
            listRewardBubbleDatas.Clear();

            // 需要创建的奖励泡泡的数量
            int rewardBubbleCount = int.Parse(strLevelDataSqlit[1]);

            // 随机生成奖励泡泡的起始高度
            float randomY = Random.Range(ConstTemplate.screenHeight / 2, ConstTemplate.screenHeight);

            Sprite spriteRewardBubble = Resources.Load<Sprite>("Player/bubble_02_65");

            for (int iBubbleAll = 0; iBubbleAll < rewardBubbleCount; )
            {

                int rewardBubbleInterval = Random.Range(10, 50);
                if (iBubbleAll + rewardBubbleInterval > rewardBubbleCount)
                    rewardBubbleInterval = rewardBubbleCount - iBubbleAll;
                iBubbleAll += rewardBubbleInterval;

                // 开始的x、y值
                float randomX = Random.Range(-ConstTemplate.screenWith*0.4f, ConstTemplate.screenWith*0.4f);
                float randomYstart = Random.Range(ConstTemplate.screenHeight*0.5f, ConstTemplate.screenHeight*1.5f);
                randomY += randomYstart;

                // 每个相距的x、y值
                float randomXInterval = Random.Range(ConstTemplate.playerRadius * 1.0f, ConstTemplate.playerRadius * 2.0f);
                float randomYInterval = Random.Range(ConstTemplate.playerRadius * 2.0f, ConstTemplate.playerRadius * 3.0f);

                Debug.Log("-- silent -- 本次创建的奖励泡泡的数量 = " + rewardBubbleInterval);
                for (int iBubbleInterval = 0; iBubbleInterval < rewardBubbleInterval; iBubbleInterval++)
                {
                    // 泡泡的缩放值
                    float randomScalc = Random.Range(0.4f, 0.9f);

                    // y轴处理
                    randomY += randomYInterval;

                    // x轴处理
                    if (randomX + randomXInterval > ConstTemplate.screenWith*0.4f || randomX + randomXInterval < -ConstTemplate.screenWith*0.4f)
                        randomXInterval = -randomXInterval;
                    randomX += randomXInterval;

                    listRewardBubbleDatas.Add(new RewardBubbleData()
                    {
                        posX = randomX,
                        posY = randomY,
                        scaleRadiu = randomScalc
                    });

                    GameObject goRewardBubble = new GameObject();
                    goRewardBubble.transform.parent = GameObject.Find("root/reward_bubbles").transform;
                    goRewardBubble.name = "rewardBubbleRandom_" + iBubbleAll + "_" + iBubbleInterval;
                    goRewardBubble.tag = "reward_bubble";
                    goRewardBubble.transform.localPosition = new Vector3(randomX, randomY);
                    goRewardBubble.transform.localScale = new Vector3(randomScalc, randomScalc, randomScalc);

                    SpriteRenderer spriteRendererRewardBubble = goRewardBubble.AddComponent<SpriteRenderer>();
                    spriteRendererRewardBubble.sprite = spriteRewardBubble;
                    spriteRendererRewardBubble.sortingLayerName = "other_object";

                    // 添加碰撞盒
                    goRewardBubble.AddComponent<CircleCollider2D>();

                    // 添加 RewardBubble 组件， 设置其属性
                    RewardBubble rewardBubble = goRewardBubble.AddComponent<RewardBubble>();
                    rewardBubble.hpRewardBubble = randomScalc * ConstTemplate.rewardBubbleMaxHp;
                    rewardBubble.scoreRewardBubble = randomScalc * ConstTemplate.rewardBubbleMaxScore;
                    rewardBubble.scaleRewardBubble = randomScalc;
                    rewardBubble.speedMoveToPlayer = randomScalc * ConstTemplate.rewardBubbleSpeedMoveToPlayerMax;
                    rewardBubble.isEaten = false;
                }
            }

            SaveRewardBubblePositionAndScaleData(createNums);
        }
    }


}
