using UnityEngine;
using UnityEngine.SceneManagement;

// 按钮管理类，基本上游戏中的ugui按钮的回调都在这里实现的
public class BtnManagerMain : MonoBehaviour
{

    public bool isPlaying = true;  // 是否正在游戏
    public bool isTouching = true; // 是否可以点击

    public GameObject goBtnMusicOn;  // 音乐开
    public GameObject goBtnMusicOff; // 音乐关
    public GameObject goBtnSoundOn;  // 音效开
    public GameObject goBtnSoundOff; // 音效关

    private AudioManager scriptAudioManager = null; // 音乐管理类
    private GameManager scriptGameManager = null;   // 游戏管理类
    private GameObject goGameManager = null;        // 游戏管理对象

    void Start()
    {
        // 获取声音管理类
        GameObject goAudioManager = GameObject.FindGameObjectWithTag("audio_manager");
        if (goAudioManager) scriptAudioManager = goAudioManager.GetComponent<AudioManager>();
        if (!scriptAudioManager) Debug.LogError("-- silent -- scriptAudioManager isn`t exit --, gameobject name == " + this.gameObject.name);

        InitBtnMusicAndSound();
    }

    void Update()
    {
        //QuitGameKey();
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

    // 返回到游戏开始场景按钮
    public void BtnClickOfPlayBack()
    {
        SceneManager.LoadScene("Bubble_Main"); // 跳转到游戏开始场景中
    }

    // 重新开始游戏
    public void BtnClickOfPlayReset()
    {
        if (scriptGameManager)
            scriptGameManager.PlayGameReset();
        else
        {
            goGameManager = goGameManager ?? GameObject.FindGameObjectWithTag("game_manager");
            scriptGameManager = goGameManager.GetComponent<GameManager>();
            scriptGameManager.PlayGameReset();
        }

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
