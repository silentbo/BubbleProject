using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManagerMain : MonoBehaviour
{

    public bool isPlaying = true;  // 是否正在游戏
    public bool isTouching = true; // 是否可以点击

    public Transform tran;

    // 进入游戏场景按钮
    public void BtnClickOfPlayGame()
    {
        SceneManager.LoadScene("Bubble_Playing"); // 跳转到游戏场景中
    }

    // 音乐开关
    public void BtnClickOfMusic()
    {
        
    }

    // 声音开关
    public void BtnClickOfSound()
    {

    }

    // 分享
    public void BtnClickOfShare()
    {
        
    }

    // 帮助
    public void BtnClickOfHelp()
    {
        
    }

    // 信息
    public void BtnClickOfInfo()
    {
 
    }


}
