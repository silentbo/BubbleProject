using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;

// 玩家游戏中玩过的时间
public class PlayerTime : MonoBehaviour {

    public bool isPlaying = true;           // 是否正在游戏

    public float playerTime = 0.0f;         // 玩家玩过的时间
    public int playerTimeCount = 0;         // 玩家玩过的时间的次数，已10s为单位
    
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

        int playerTimeCountTemp = (int)(playerTime / 10.0f);
        if (playerTimeCountTemp != playerTimeCount)
        {
            playerTimeCount = playerTimeCountTemp;
            float speedMove = scriptGameManager.speedBgMove + playerTimeCount / 10.0f;
            scriptGameManager.ChangeSpeedBgMove(speedMove);
        }
        stringBuilder.Append(scriptGameManager.speedBgMove);
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

    // 重新开始游戏
    public void PlayGameResetPlayerTime()
    {
        this.playerTime = 0.0f;
        this.playerTimeCount = 0;
        GamePauseOrResumePlayerTime(true);
    }

}
