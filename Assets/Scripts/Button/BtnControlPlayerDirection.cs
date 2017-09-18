using UnityEngine;

public class BtnControlPlayerDirection : MonoBehaviour {

    // 按钮类型
    public ConstTemplate.BtnControlDirectionType btnControlDirectionType = ConstTemplate.BtnControlDirectionType.BtnControlDirectionDefault;

    //public AudioClip audioClipClick; // 点击音效

    public Player scriptPlayer;

    //private AudioManager scriptAudioManager; // 声音管理类

    //void Start()
    //{
    //    // 获取声音管理类
    //    GameObject goAudioManager = GameObject.FindGameObjectWithTag("audio_manager");
    //    if (goAudioManager) scriptAudioManager = goAudioManager.GetComponent<AudioManager>();
    //    if (!scriptAudioManager) Debug.LogError("-- silent -- scriptAudioManager isn`t exit --, gameobject name == " + this.gameObject.name);
    //}

    //void OnMouseDown()
    //{
    //    scriptAudioManager.PlayAudioClip(ConstTemplate.AudioType.AudioSound, audioClipClick);
    //}

    //void OnMouseUp()
    //{
    //    scriptAudioManager.PlayAudioClip(ConstTemplate.AudioType.AudioSound, audioClipClick);
    //}

    // 点击事件
    void OnMouseDrag()
    {
        Vector3 vec3Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (vec3Position.x < 0)
            btnControlDirectionType = ConstTemplate.BtnControlDirectionType.BtnControlDirectionLeft;
        
        if (vec3Position.x > 0)
            btnControlDirectionType = ConstTemplate.BtnControlDirectionType.BtnControlDirectionRight;

        scriptPlayer.MovePlayerLeftOrRightByBtn(btnControlDirectionType);
    }

}
