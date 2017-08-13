using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;

// 玩家游戏中玩过的时间
public class PlayerTime : MonoBehaviour {

    public bool isPlaying = true;           // 是否正在游戏

    public float playerTime = 0.0f;         // 玩家玩过的时间
    
    public Text textPlayerTime;             // 玩家玩过的时间 text

    public GameManager scriptGameManager;   // 管理类

	
	// Update is called once per frame
	void Update () {

        if (isPlaying){

            ShowPlayTime();
        }
	}

    // 显示时间 (10.00 s)
    private void ShowPlayTime()
    {
        playerTime += Time.deltaTime;

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(playerTime.ToString("0.00"));
        stringBuilder.Append(" s");

        textPlayerTime.text = stringBuilder.ToString();
    }

    // 游戏结束
    public void GameOverPlayerTime()
    {
        GamePauseOrResumePlayerTime(false);
    }

    // 游戏暂停or继续
    public void GamePauseOrResumePlayerTime(bool pauseOrResume)
    {
        this.isPlaying = pauseOrResume;
    }
}
