using System.IO;
using System.Text;
using UnityEngine;
using UnityEditor;

public class GermGetPositionData {

    [MenuItem("silentTools/GetGermPositionData")]
    public static void GetGermPositionData()
    {

        Debug.Log("-- silent -- GetGermPositionData() --");

        // 获取奖励泡泡的跟对象
        Transform transGermRoot = GameObject.Find("root/enemy").transform;
        if (!transGermRoot)
        {
            Debug.Log("-- silent -- root/enemy is null --");
            return;
        }

        Debug.Log("-- silent -- 开始保存奖励泡泡数据 --");

        // 保存文件名及路径
        string strSaveGermDataPath = Application.dataPath + "/Resources/Data/GermData/GermDataLevel_0001.json";

        // json格式：
        // { "student":[ {"name":"a", "num":"19", "sex":"m"}, {"name":"b", "num":"20", "sex":"w"} ] }

        // {"germ_data":[ {"id":"0", "randomX":"1.0", "randomY":"1.0"}, ······ ]}
        string strDataBegin = "{\n\t\"germ_data\":\n\t[";
        string strDataEnd = "\n\t]\n}";
        StringBuilder stringBuilderDataContent = new StringBuilder();
        stringBuilderDataContent.Append(strDataBegin);
        int germCount = 0;

        // 遍历所有孩子
        for (int i = 0; i < transGermRoot.childCount; i++)
        {
            Transform transChild = transGermRoot.GetChild(i);
            // 孩子是奖励泡泡
            if (transChild.tag.Equals("germ"))
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

        File.WriteAllText(strSaveGermDataPath, stringBuilderDataContent.ToString());

        Debug.Log("-- silent -- 结束写入json文件 --");

        Debug.Log("-- silent -- 结束保存奖励泡泡数据 --");



    }

}
