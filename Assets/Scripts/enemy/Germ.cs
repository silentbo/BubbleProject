using UnityEngine;
using System.Collections;

public class Germ : MonoBehaviour {

    public bool isPlaying = true; // 是否正在游戏

    public float hpGerm = ConstTemplate.germMaxHp;       // 细菌的生命值，就是玩家减少的生命值
    public float scaleGerm = 1.0f;                       // 细菌的大小
    public float scoreGerm = ConstTemplate.germMaxScore; // 细菌的分数

    public Animator animator;     // 动画

    private CircleCollider2D circleCollider2D; // 碰撞盒

    void Start(){
        circleCollider2D = this.transform.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update () {
        AutoDestroy();
    }

    // 已经伤害过一次主角了，
    public void HarmPlayerFinish()
    {
        circleCollider2D.enabled = false;
    }


    // 播放正在死亡动画
    public void PlayAnimationDying()
    {
        animator.PlayInFixedTime("grem_die");
    }

    // 自动销毁
    private void AutoDestroy()
    {
        if (this.transform.position.y <= -ConstTemplate.screenHeight / 2.0f * 1.5f)
            Destroy(this.gameObject); 
    }




}
