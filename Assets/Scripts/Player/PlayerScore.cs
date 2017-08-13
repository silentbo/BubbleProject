using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// 玩家得到的分数
// 移动的距离 + 奖励的分数

public class PlayerScore : MonoBehaviour{

    public bool isPlaying = true; // 是否在游戏

    public float playerScore = 0; // 玩家获得的分数

    public Text textPlayerScore;  // 玩家获得的分数

    public GameManager scritpGameManager; // 管理类
	
	// Update is called once per frame
	void Update (){

	    if (isPlaying){

	        ShowPlayerScore();
	    }
	}

    // 显示分数
    private void ShowPlayerScore()
    {
        playerScore += Time.deltaTime * scritpGameManager.speedBgMove;

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("score: ");
        stringBuilder.Append(playerScore.ToString("0"));

        textPlayerScore.text = stringBuilder.ToString();
    }

    // 增加分数
    public void IncreasePlayerScore(float addSocreValue)
    {
        playerScore += addSocreValue;
        ShowPlayerScore();
    }

    // 暂停or继续游戏
    public void GamePauseOrResumePlayerScore(bool pauseOrResume)
    {
        this.isPlaying = pauseOrResume;
    }

    // 结束游戏
    public void GameOverPlayerScore()
    {
        GamePauseOrResumePlayerScore(false);
    }
}
