using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class RewardToolsGetPositionData : MonoBehaviour {

    [MenuItem("silentTools/GetRewardToolsPositionData")]
    public static void GetRewardToolsPositionData()
    {

        Debug.Log("-- silent -- GetRewardToolsPositionData() --");

        // 获取奖励泡泡的跟对象
        Transform transRewardToolsRoot = GameObject.Find("root/reward_tools").transform;
        if (!transRewardToolsRoot)
        {
            Debug.Log("-- silent -- root/reward_tools is null --");
            return;
        }

        Debug.Log("-- silent -- 开始保存reward_tool数据 --");

        // 保存文件名及路径
        string strSaveRewardToolsDataPath = Application.dataPath + "/Resources/Data/RewardToolsData/RewardToolsDataLevel_0001.json";

        // json格式：
        // { "student":[ {"name":"a", "num":"19", "sex":"m"}, {"name":"b", "num":"20", "sex":"w"} ] }

        // {"germ_data":[ {"id":"0", "randomX":"1.0", "randomY":"1.0"}, ······ ]}
        string strDataBegin = "{\n\t\"reward_tool_data\":\n\t[";
        string strDataEnd = "\n\t]\n}";
        StringBuilder stringBuilderDataContent = new StringBuilder();
        stringBuilderDataContent.Append(strDataBegin);
        int germCount = 0;

        // 遍历所有孩子
        for (int i = 0; i < transRewardToolsRoot.childCount; i++)
        {
            Transform transChild = transRewardToolsRoot.GetChild(i);
            // 孩子是奖励泡泡
            if (transChild.tag.Equals("reward_tool"))
            {
                if (0 != germCount)
                    stringBuilderDataContent.Append(",");

                stringBuilderDataContent.Append("\n\t\t{\n\t\t\t\"id\":\"");
                stringBuilderDataContent.Append(germCount++);
                stringBuilderDataContent.Append("\", \n\t\t\t\"randomX\":\"");
                stringBuilderDataContent.Append(transChild.position.x);
                stringBuilderDataContent.Append("\", \n\t\t\t\"randomY\":\"");
                stringBuilderDataContent.Append(transChild.position.y);
                stringBuilderDataContent.Append("\"\n\t\t}");
            }
        }
        stringBuilderDataContent.Append(strDataEnd);
        Debug.Log("-- silent -- data = ---------- begin --");
        Debug.Log(stringBuilderDataContent.ToString());
        Debug.Log("-- silent -- data = ---------- end --");

        Debug.Log("-- silent -- 开始写入json文件 --");

        File.WriteAllText(strSaveRewardToolsDataPath, stringBuilderDataContent.ToString());

        Debug.Log("-- silent -- 结束写入json文件 --");

        Debug.Log("-- silent -- 结束保存reward_tool数据 --");

    }
}
