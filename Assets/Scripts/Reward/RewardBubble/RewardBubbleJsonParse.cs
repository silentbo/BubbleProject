using System.IO;
using UnityEngine;

// 奖励泡泡关卡数据json
public class RewardBubbleLevelData
{
    public RewardBubbleData[] rewardBubbleDatas;
}

// 奖励泡泡数据信息
public class RewardBubbleData
{
    public int id;
    public float randomX;
    public float randomY;
    public float randomScale;

}

// 奖励泡泡关卡json数据解析
public class RewardBubbleJsonParse {

    public static RewardBubbleLevelData LoadRewardBubbleLevelJsonData(int levelId)
    {
        string rewardBubblePath = Application.dataPath + "/Resources/Data/RewardBubbleData/RewardBubbleDataLevel_" + levelId.ToString() + ".json";
        StreamReader streamReader = new StreamReader(rewardBubblePath);
        string strJsonLevelData = streamReader.ReadToEnd();

        if (strJsonLevelData.Length <= 0) return null;

        return JsonUtility.FromJson<RewardBubbleLevelData>(strJsonLevelData);
    }


}
