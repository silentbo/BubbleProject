using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class RewardBubbleGetPositionData {
    
    [MenuItem("silentTools/GetRewardBubblePositionData")]
    public static void GetRewardBubblePositionData()
    {
        Debug.Log("-- silent -- GetRewardBubblePositionData() --");
        
        // 获取奖励泡泡的跟对象
        Transform transRewardBubbleRoot = GameObject.Find("root/reward_bubbles").transform;
        if (!transRewardBubbleRoot)
        {
            Debug.Log("-- silent -- root/reward_bubbles is null --");
            return;
        }

        Debug.Log("-- silent -- 开始保存奖励泡泡数据 --");

        // 保存文件名及路径
        string strSaveRewardBubbleDataPath = Application.dataPath + "/Resources/Data/RewardBubbleData/RewardBubbleDataLevel_0001.json";

        // json格式：
        // { "student":[ {"name":"a", "num":"19", "sex":"m"}, {"name":"b", "num":"20", "sex":"w"} ] }

        //// {"reward_bubble_data":[ {"id":"0", "randomX":"1.0", "randomY":"1.0", "randomScale":"1.0"}, ······ ]}
        // {"reward_bubble_data":[ {"id":"0", "randomX":"1.0", "randomY":"1.0"}, ······ ]}
        string strDataBegin = "{\n\t\"reward_bubble_data\":\n\t[";
        string strDataEnd = "\n\t]\n}";
        StringBuilder stringBuilderDataContent = new StringBuilder();
        stringBuilderDataContent.Append(strDataBegin);
        int rewardBubbleCount = 0;

        // 遍历所有孩子
        for (int i = 0; i < transRewardBubbleRoot.childCount; i ++)
        {
            Transform transChild = transRewardBubbleRoot.GetChild(i);
            // 孩子是奖励泡泡
            if (transChild.tag.Equals("reward_bubble"))
            {
                if (0 != rewardBubbleCount)
                    stringBuilderDataContent.Append(",");

                stringBuilderDataContent.Append("\n\t\t{\n\t\t\t\"id\":\"");
                stringBuilderDataContent.Append(rewardBubbleCount ++);
                stringBuilderDataContent.Append("\", \n\t\t\t\"randomX\":\"");
                stringBuilderDataContent.Append(transChild.localPosition.x);
                stringBuilderDataContent.Append("\", \n\t\t\t\"randomY\":\"");
                stringBuilderDataContent.Append(transChild.localPosition.y);
                stringBuilderDataContent.Append("\"\n\t\t}");
            }
        }
        stringBuilderDataContent.Append(strDataEnd);
        Debug.Log("-- silent -- data = ---------- begin --");
        Debug.Log(stringBuilderDataContent.ToString());
        Debug.Log("-- silent -- data = ---------- end --");

        Debug.Log("-- silent -- 开始写入json文件 --");

        File.WriteAllText(strSaveRewardBubbleDataPath, stringBuilderDataContent.ToString());

        Debug.Log("-- silent -- 结束写入json文件 --");

        Debug.Log("-- silent -- 结束保存奖励泡泡数据 --");
    }

}
