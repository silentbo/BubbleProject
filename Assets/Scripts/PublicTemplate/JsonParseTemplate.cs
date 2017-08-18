// json 文件解析类
// 通过解析对应的json文件，来获取其中对应的值
// 解析的时候需要定义解析类

using System.IO;
using UnityEngine;



// 奖励泡泡关卡数据json解析类
[System.Serializable] // 序列化，必须要加这个，网上说但是不建议使用这个类了，建议使用LitJson
public class RewardBubbleLevelData
{
    public ObjectPositionData[] reward_bubble_data;
}

// germ(细菌)关卡数据json解析类
[System.Serializable]
public class GermLevelData
{
    public ObjectPositionData[] germ_data;
}

// 奖励道具关卡数据json解析类
[System.Serializable]
public class RewardToolsLevelData
{
    public ObjectPositionData[] reward_tool_data;
}


// 物体位置数据信息解析类
[System.Serializable] // 定义的变量名与json中的名字一样
public class ObjectPositionData
{
    public int id;
    public float randomX;
    public float randomY;
}

// json解析类
public class JsonParseTemplate : MonoBehaviour {

    // 获取对应关卡的奖励泡泡的所有位置信息
    public static RewardBubbleLevelData LoadRewardBubbleLevelJsonData(int levelId)
    {
        // 获取文件的绝对路径
        string rewardBubblePath = Application.dataPath + ConstTemplate.resRewardBubbleLevelPath + ConstTemplate.resRewardBubbleLevelName + string.Format("{0:D2}.json", levelId);
        // 使用读取流来获取文件内容
        StreamReader streamReader = new StreamReader(rewardBubblePath);
        // 读取文件所有内容
        string strJsonLevelData = streamReader.ReadToEnd();

        // 没有内容就不做处理了
        if (strJsonLevelData.Length <= 0) return null;

        // 返回解析json的数据结构
        return JsonUtility.FromJson<RewardBubbleLevelData>(strJsonLevelData);
    }

    // 获取对应关卡的germ(细菌)的所有位置信息
    public static GermLevelData LoadGermLevelJsonData(int levelId)
    {
        // 获取文件的绝对路径
        string germPath = Application.dataPath + ConstTemplate.resGermLevelPath + ConstTemplate.resGermLevelName + string.Format("{0:D2}.json", levelId);
        // 使用读取流来获取文件内容
        StreamReader streamReader = new StreamReader(germPath);
        // 读取文件所有内容
        string strJsonLevelData = streamReader.ReadToEnd();

        // 没有内容就不做处理了
        if (strJsonLevelData.Length <= 0) return null;

        // 返回解析json的数据结构
        return JsonUtility.FromJson<GermLevelData>(strJsonLevelData);
    }

    // 获取对应关卡的germ(细菌)的所有位置信息
    public static RewardToolsLevelData LoadRewardToolLevelJsonData(int levelId)
    {
        // 获取文件的绝对路径
        string rewardToolPath = Application.dataPath + ConstTemplate.resRewardToolLevelPath + ConstTemplate.resRewardToolLevelName + string.Format("{0:D2}.json", levelId);
        // 使用读取流来获取文件内容
        StreamReader streamReader = new StreamReader(rewardToolPath);
        // 读取文件所有内容
        string strJsonLevelData = streamReader.ReadToEnd();

        // 没有内容就不做处理了
        if (strJsonLevelData.Length <= 0) return null;

        // 返回解析json的数据结构
        return JsonUtility.FromJson<RewardToolsLevelData>(strJsonLevelData);
    }

}
