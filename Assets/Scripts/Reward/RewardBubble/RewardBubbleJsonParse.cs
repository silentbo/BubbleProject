using System.IO;
using UnityEngine;

// 奖励泡泡关卡数据json
[System.Serializable] // 序列化，必须要加这个，网上说但是不建议使用这个类了，建议使用LitJson
public class RewardBubbleLevelData
{
    public RewardBubbleData[] reward_bubble_data;
}

// 奖励泡泡数据信息
[System.Serializable]
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
