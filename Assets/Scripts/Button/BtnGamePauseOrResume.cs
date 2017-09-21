using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// 游戏暂停or继续按钮实现(实现方式是使用接口来实现，api中的自带的方法)
public class BtnGamePauseOrResume : MonoBehaviour, IPointerClickHandler {

    public bool isPlaying = false;           // 是否正在游戏中
    public bool isPlayPauseOrResume = true;  // 游戏时暂停还是继续游戏

    public Image imagePauseResume;           // 按钮图标，暂停还是继续游戏图标

    public Animator animatorBtnMore;         // 更多按钮动画

    public GameManager scriptGameManager;    // 管理类

    private Sprite sprPauseIcon;             // 暂停按钮icon
    private Sprite sprResumeIcon;            // 继续按钮icon

    void Start(){

        sprPauseIcon = Resources.Load<Sprite>(ConstTemplate.resPathSpriteBtnPause);
        sprResumeIcon = Resources.Load<Sprite>(ConstTemplate.resPathSpriteBtnResume);

    }

    // 监听点击事件
    public void OnPointerClick(PointerEventData eventData){

        if (!isPlaying) return;

        // 修改游戏状态
        isPlayPauseOrResume = !isPlayPauseOrResume;
        scriptGameManager.PlayGamePauseOrResume(isPlayPauseOrResume);
        PlayBtnMoreAnimator(isPlayPauseOrResume);
    }

    public void PlayBtnMoreAnimator(bool isState)
    {
        // 修改图片
        imagePauseResume.sprite = isState ? sprPauseIcon : sprResumeIcon;
        if (isState)
        {
            animatorBtnMore.SetFloat("speed_condition", -1.0f);
        }
        else
        {
            animatorBtnMore.enabled = true;
            animatorBtnMore.PlayInFixedTime("btn_play_scene");
            animatorBtnMore.SetFloat("speed_condition", 1.0f);
        }
    }

    // 开始游戏
    public void PlayGameStartBtnGamePauseOrResume()
    {
        this.isPlaying = true;
    }

    // 游戏结束
    public void PlayGameOverBtnGamePauseOrResume()
    {
        this.isPlaying = false;
        PlayBtnMoreAnimator(false);
    }

    // 重新开始游戏
    public void PlayerGameResetBtnGamePauseOrResume()
    {
        this.isPlaying = false;
        PlayBtnMoreAnimator(true);
    }
}
