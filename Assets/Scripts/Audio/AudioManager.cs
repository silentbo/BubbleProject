using UnityEngine;

public class AudioManager : MonoBehaviour{

    public bool isPlaying = true;   // 是否正在游戏
    public bool isPlayMusic = true; // 是否播放背景音乐
    public bool isPlaySound = true; // 是否播放音效

    public AudioSource audioMusic; // 背景音乐
    public AudioSource audioSound; // 音效
    
    void Awake()
    {
        // 切换场景的时候不销毁这个物体及其子物体
        DontDestroyOnLoad(this.gameObject);
        GetKeyAudio();
        PlayMusic();
    }

    // 获取当前游戏中的音乐的状态
    private void GetKeyAudio()
    {
        isPlayMusic = PlayerPrefs.GetInt(ConstTemplate.keyPlayerPrefsMusic, 1) == 1;
        isPlaySound = PlayerPrefs.GetInt(ConstTemplate.keyPlayerPrefsSound, 1) == 1;
    }

    // 设置当前游戏中的音乐的状态
    public void SetKeyAudio(ConstTemplate.AudioType audioType, bool isPlay)
    {
        switch (audioType)
        {
            case ConstTemplate.AudioType.AudioMusic:
                isPlayMusic = isPlay;
                PlayerPrefs.SetInt(ConstTemplate.keyPlayerPrefsMusic, isPlay ? 1 : 0);
                PlayMusic();
                break;
            case ConstTemplate.AudioType.AudioSound:
                isPlaySound = isPlay;
                PlayerPrefs.SetInt(ConstTemplate.keyPlayerPrefsSound, isPlay ? 1 : 0);
                PlaySound();
                break;
        }
    }

    // 是否播放音乐
    private void PlayMusic()
    {
        if (isPlayMusic)
            audioMusic.Play();
        else
            audioMusic.Pause();
    }

    // 是否播放音效
    private void PlaySound()
    {
        if (isPlaySound)
            audioSound.Play();
        else
            audioSound.Stop();
    }

    // 设置并且播放 音乐
    public void PlayAudioClip(ConstTemplate.AudioType audioType, AudioClip audioClip)
    {
        switch (audioType)
        {
            case ConstTemplate.AudioType.AudioMusic:
                audioMusic.clip = audioClip;
                PlayMusic();
                break;
            case ConstTemplate.AudioType.AudioSound:
                audioSound.clip = audioClip;
                PlaySound();
                break;
        }
    }
}
