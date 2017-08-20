using System;
using UnityEngine;

// 泡泡不死 类
public class BubbleNoDie : MonoBehaviour {

    public bool isPlaying = true;        // 是否正在游戏中
    public bool isAnimate = false;       // 是否播放动画
    public bool isFormMinToMax = true;  // 是否是从小到大的

    public float speedScale = ConstTemplate.bubbleSpeedNoDie; // 泡泡不死动画的缩放变化速度
    public float scaleMin = 1.0f; // 最小缩放值
    public float scaleMax = 1.5f; // 最大缩放值

    public SpriteRenderer spriteRenderer; // 图片

    void OnEnable(){
        isAnimate = true;
    }

    void OnDisable(){
        this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        isAnimate = false;
    }

    void Update(){
        if (isAnimate)
            PlayAnimationScalePingPang();
    }

    // 使用乒乓的形式播放缩放动画
    private void PlayAnimationScalePingPang(){

        // 从小到大的缩放
        if(isFormMinToMax){
            PlayAnimationScaleOFormMinToMax(true);
            if (this.transform.localScale.x > scaleMax)
                isFormMinToMax = false;
        }
        else{
            PlayAnimationScaleOFormMinToMax(false);
            if (this.transform.localScale.x < scaleMin)
                isFormMinToMax = true;
        }
    }

    // 播放缩放动画从小到大的动画(true 为小到大，false 为大到小)
    private void PlayAnimationScaleOFormMinToMax(bool isFormMinToMax){
        float scaleTransChange = this.transform.localScale.x + (isFormMinToMax ? speedScale * Time.deltaTime : -speedScale * Time.deltaTime);
        this.transform.localScale = new Vector3(scaleTransChange, scaleTransChange, scaleTransChange);
    }



}
