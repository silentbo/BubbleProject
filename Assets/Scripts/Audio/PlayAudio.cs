using UnityEngine;
using UnityEngine.EventSystems;


public class PlayAudio : MonoBehaviour, IPointerClickHandler{

    public bool isPlaying = true; // 是否正在游戏

    public ConstTemplate.AudioType audioType = ConstTemplate.AudioType.AudioSound;

    public AudioClip audioClip;  // 声音组件

    public AudioManager scriptAudioManager; // 声音管理

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
