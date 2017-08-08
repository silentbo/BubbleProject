using UnityEngine;
using UnityEngine.UI;
using System.Text;

// 玩家游戏中玩过的时间
public class PlayerTime : MonoBehaviour {

    public Text textPlayerTime; // 玩家玩过的时间 text
    public float playerTime = 0.0f; // 玩家玩过的时间
    public GameManager gameManager; // 管理类

    public bool isPlaying = true; // 是否正在游戏

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isPlaying)
        {
            AddSecondPlayTime();
        }
	}

    // 增加游戏的时间
    private void AddSecondPlayTime()
    {
        playerTime += Time.deltaTime;

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(playerTime.ToString("0.00"));
        stringBuilder.Append(" s");

        textPlayerTime.text = stringBuilder.ToString();
    }
}
