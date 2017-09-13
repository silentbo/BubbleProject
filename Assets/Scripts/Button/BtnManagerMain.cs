using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManagerMain : MonoBehaviour
{

    public bool isPlaying = true;  // 是否正在游戏
    public bool isTouching = true; // 是否可以点击

    public GameObject goBtnMusicOn;  // 音乐开
    public GameObject goBtnMusicOff; // 音乐关
    public GameObject goBtnSoundOn;  // 音效开
    public GameObject goBtnSoundOff; // 音效关

    public AudioManager scriptAudioManager; // 音乐管理类

    void Awake()
    {
        InitBtnMusicAndSound();
    }

    // 初始化 按钮的状态
    private void InitBtnMusicAndSound()
    {
        goBtnMusicOn.SetActive(scriptAudioManager.isPlayMusic);
        goBtnMusicOff.SetActive(!scriptAudioManager.isPlayMusic);
        goBtnSoundOn.SetActive(scriptAudioManager.isPlaySound);
        goBtnSoundOff.SetActive(!scriptAudioManager.isPlaySound);
    }


    // 进入游戏场景按钮
    public void BtnClickOfPlayGame()
    {
        SceneManager.LoadScene("Bubble_Playing"); // 跳转到游戏场景中
    }

    // 音乐开关
    public void BtnClickOfMusic()
    {
        scriptAudioManager.SetKeyAudio(ConstTemplate.AudioType.AudioMusic, !scriptAudioManager.isPlayMusic);
        InitBtnMusicAndSound();
    }

    // 声音开关
    public void BtnClickOfSound()
    {
        scriptAudioManager.SetKeyAudio(ConstTemplate.AudioType.AudioSound, !scriptAudioManager.isPlaySound);
        InitBtnMusicAndSound();
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
