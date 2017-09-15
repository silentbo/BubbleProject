using UnityEngine;
using UnityEngine.EventSystems;

// 音乐添加类 -- 添加需要发出的声音，在点击或者运行的时候会播放对应的声音
public class PlayAudio : MonoBehaviour, IPointerClickHandler{

    public bool isPlaying = true; // 是否正在游戏

    public ConstTemplate.AudioType audioType = ConstTemplate.AudioType.AudioSound;

    public AudioClip audioClip;        // 音效音乐

    private  AudioManager scriptAudioManager; // 声音管理

    void Start()
    {
        // 获取声音管理类
        GameObject goAudioManager = GameObject.FindGameObjectWithTag("audio_manager");
        if (goAudioManager) scriptAudioManager = goAudioManager.GetComponent<AudioManager>();
        if (!scriptAudioManager) Debug.LogError("-- silent -- scriptAudioManager isn`t exit --, gameobject name == " + this.gameObject.name);

        // 自动播放背景音乐
        if (audioType == ConstTemplate.AudioType.AudioMusic)
            scriptAudioManager.PlayAudioClip(audioType, audioClip);
    }

    // 非ugui下的点击事件
    void OnMouseUpAsButton()
    {
        print("-- silent -- playAudio OnMouseUpAsButton -- ");
        scriptAudioManager.PlayAudioClip(audioType, audioClip);
    }


    // ugui下的点击事件
    public void OnPointerClick(PointerEventData eventData)
    {
        print("-- silent -- playAudio OnPointerClick -- ");
        scriptAudioManager.PlayAudioClip(audioType, audioClip);
    }

}
