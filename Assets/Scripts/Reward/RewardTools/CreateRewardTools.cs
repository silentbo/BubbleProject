using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreateRewardTools : MonoBehaviour
{

    public PlayerDistance scriptPlayerDistance; // 主角移动距离 脚本

    private float distanceCreateRewardTools = 0.0f; // 创建奖励道具的距离(上次创建的奖励道具的移动距离)

    private Sprite spriteRewardTool; // 奖励道具的图片，就一个图片，然后奖励是随机的，不吃到不知道

    private List<ObjectPositionData> listRewardToolsPositionData = new List<ObjectPositionData>(); // list奖励道具的位置信息


	// Use this for initialization
	void Start (){

	    spriteRewardTool = Resources.Load<Sprite>(ConstTemplate.resPathSpriteDefaultRewardTool);
	}

    void Update()
    {
        CreateRewardToolByDistance();
    }


    // 排序，通过Y轴的坐标类排序 大到小
    private int SortRewardToolPositionY(ObjectPositionData opdL, ObjectPositionData opdR)
    {
        if (opdL.randomY < opdR.randomY)
            return 1;
        else if (opdL.randomY == opdR.randomY)
            return 0;
        else return -1;
    }

    // 创建第几关的奖励道具
    public void CreateRewardLevelTool(int levelId)
    {
        // 读取泡泡数据
        RewardToolsLevelData rewardToolsLevelData = JsonParseTemplate.LoadRewardToolLevelJsonData(levelId);
        listRewardToolsPositionData = rewardToolsLevelData.reward_tool_data.ToList();
        listRewardToolsPositionData.Sort(SortRewardToolPositionY);
        distanceCreateRewardTools = -ConstTemplate.screenHeight / 2;
    }

    // 创建奖励道具，通过距离来创建奖励道具，优化，避免一帧实例化太多，造成卡顿
    private void CreateRewardToolByDistance()
    {
        // 没有数据、没有到下一屏幕，不创建对象
        if (listRewardToolsPositionData.Count <= 0) return;
        if (distanceCreateRewardTools + ConstTemplate.screenHeight / 2 > scriptPlayerDistance.playerDistance) return;

        distanceCreateRewardTools = scriptPlayerDistance.playerDistance;
        print("-- silent -- distatnceCreateRewardTools == " + distanceCreateRewardTools);
        float maxPosYCreateRewardTool = scriptPlayerDistance.playerDistance - ConstTemplate.screenHeight / 2 + ConstTemplate.screenHeight * 1.5f;
        print("-- silent -- maxPosYCreateRewardTool == " + maxPosYCreateRewardTool);

        // 从后向前遍历，动态删除的哦
        for (int i = listRewardToolsPositionData.Count - 1; i >= 0; i--)
        {
            // 之后的下次在创建
            if (listRewardToolsPositionData[i].randomY > maxPosYCreateRewardTool)
                break;
            // 创建奖励道具
            CreateOneRewardTool(listRewardToolsPositionData[i], distanceCreateRewardTools);
            // 删除已经生成过的奖励道具
            listRewardToolsPositionData.RemoveAt(i);
        }
        
    }

    // 创建一个奖励工具
    private void CreateOneRewardTool(ObjectPositionData rewardToolPositionDate, float distanceMoved = 0.0f)
    {
        // 创建对象，设置属性值
        GameObject goNewRewardBubble = new GameObject();
        goNewRewardBubble.name = "reward_bubble_" + rewardToolPositionDate.id.ToString();
        goNewRewardBubble.transform.parent = this.transform;
        goNewRewardBubble.tag = "reward_tool";
        goNewRewardBubble.transform.localPosition = new Vector3(rewardToolPositionDate.randomX, rewardToolPositionDate.randomY - distanceMoved, 0.0f);
        float randomScale = Random.Range(0.5f, 1.0f);
        goNewRewardBubble.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

        // 添加 SpriteRenderer 组件， 设置层级
        SpriteRenderer spriteRendererRewardBubble = goNewRewardBubble.AddComponent<SpriteRenderer>();
        spriteRendererRewardBubble.sprite = spriteRewardTool;
        spriteRendererRewardBubble.sortingLayerName = "other_object";

        // 添加 MoveDownTemplate 组件， 设置速度
        MoveDownTemplate moveDownRewardBubble = goNewRewardBubble.AddComponent<MoveDownTemplate>();
        moveDownRewardBubble.isAnimation = true;
        moveDownRewardBubble.speedMoveDown = ConstTemplate.rewardToolsSpeedMoveDown;

        // 添加碰撞盒
        goNewRewardBubble.AddComponent<CircleCollider2D>();

        // 添加 RewardTools 组件， 设置其属性
        RewardTools rewardTools = goNewRewardBubble.AddComponent<RewardTools>();
        rewardTools.hpRewardTools = randomScale * ConstTemplate.rewardToolsMaxHp;
        rewardTools.scoreRewardTools = randomScale * ConstTemplate.rewardToolsMaxScore;
        rewardTools.scaleRewardTools = randomScale;
        rewardTools.speedMoveToPlayer = randomScale * ConstTemplate.rewardToolsSpeedMoveToPlayerMax;
        rewardTools.isEaten = false;


    }

}
