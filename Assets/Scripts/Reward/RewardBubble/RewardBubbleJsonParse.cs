using System.IO;
using UnityEngine;

// 奖励泡泡关卡数据json
[System.Serializable] // 序列化，必须要加这个，网上说但是不建议使用这个类了，建议使用LitJson
public class RewardBubbleLevelData
{
    public RewardBubbleData[] reward_bubble_data;
}

// 奖励泡泡数据信息
[System.Serializable] // 定义的变量名与json中的名字一样
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
        // 获取文件的绝对路径
        string rewardBubblePath = Application.dataPath + ConstTemplate.resLevelPath + ConstTemplate.resLevelName + levelId.ToString() + ".json";
        // 使用读取流来获取文件内容
        StreamReader streamReader = new StreamReader(rewardBubblePath);
        // 读取文件所有内容
        string strJsonLevelData = streamReader.ReadToEnd();

        // 没有内容就不做处理了
        if (strJsonLevelData.Length <= 0) return null;

        // 返回解析json的数据结构
        return JsonUtility.FromJson<RewardBubbleLevelData>(strJsonLevelData);
    }


}
