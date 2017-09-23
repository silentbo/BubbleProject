using UnityEngine;
using UnityEngine.UI;

public class GameResult : MonoBehaviour {

    public bool isPlaying = true; // 是否正在游戏

    public Text textBestScore; // 最好的成绩文本

    public GameObject goWin;  // 胜利
    public GameObject goLose; // 失败

    public PlayerScore scriptPlayerScore; // 分数脚本

    public void ShowBestScore(){

        float bestScore = PlayerPrefs.GetFloat(ConstTemplate.keyPlayerPrefsBestScore, 0.0f);
        float nowScore = scriptPlayerScore.playerScore;
        if (bestScore < nowScore)
        {
            bestScore = nowScore;
            PlayerPrefs.SetFloat(ConstTemplate.keyPlayerPrefsBestScore, bestScore);
        }
        textBestScore.text = bestScore.ToString("0");
    }

    public void GameOverGameResult(){
        this.transform.gameObject.SetActive(true);
        ShowBestScore();
        goLose.SetActive(true);
    }

    public void PlayGameResetGameResult()
    {
        this.transform.gameObject.SetActive(false);
        goLose.SetActive(false);
        goWin.SetActive(false);
    }

}
