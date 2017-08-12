using System;
using UnityEngine;
using System.Collections;

// 主角即玩家
public class Player : MonoBehaviour{

    public bool isPlaying = false;               // 是否正在游戏中
    public bool isAnimMoveLeftOrRight = true;    // 是否可以左右移动
    public bool isGameStartBeforeFinish = false; // 是否播放完开场动画了

    public float speedMoveByBtn = 5.0f; // 按钮控制其左右移动的速度

    public Vector3 moveDirection = Vector3.zero; // 主角移动的方向

    public Animator animatorPlayer;          // 主角动画
    public Animator animatorBubble;          // 泡泡动画

    public CircleCollider2D circleCollider2DPlayer; // 主角的碰撞盒

    public PlayerScore scriptPlayerScore;    // 玩家分数脚本
    public PlayerLife scriptPlayerLife;      // 玩家生命脚本
    public GameManager scriptGamseManager;   // 管理类
	
	// Update is called once per frame
	void Update () {
        BeforeStartGamePlayerAnimation();
	}

    // 2d 碰撞触发函数
    void OnTriggerEnter2D(Collider2D other){
        
        switch (other.tag)
        {
            case "reward_bubble":
                ColliderByRewardBubble(other);
                break;
        }

    }

    // 碰撞奖励泡泡事件
    private void ColliderByRewardBubble(Collider2D other2D)
    {
        // 播放吃东西动画
        PlayAnimEatRewardBubble();

        // 获取奖励泡泡增加的生命值
        RewardBubble rewardBubble = other2D.GetComponent<RewardBubble>();
        if (!rewardBubble) return;

        rewardBubble.EatenByPlayer(this.gameObject);                           // 奖励泡泡被吃动画
        scriptPlayerLife.IncreasePlayerLife(rewardBubble.hpRewardBubble);      // 增加玩家生命值
        scriptPlayerScore.IncreasePlayerScore(rewardBubble.scoreRewardBubble); // 增加玩家分数
    }

    // 吃掉其他泡泡动画
    private void PlayAnimEatRewardBubble()
    {
        animatorPlayer.PlayInFixedTime("player_eat");
    }

    // 左右移动
    public void MovePlayerLeftOrRightByBtn(ConstTemplate.BtnControlDirectionType btnDirectionType)
    {
        if (!isAnimMoveLeftOrRight) return;

        switch (btnDirectionType){

            case ConstTemplate.BtnControlDirectionType.BtnControlDirectionDefault:
                moveDirection = Vector3.zero;
                break;

            case ConstTemplate.BtnControlDirectionType.BtnControlDirectionLeft:
                moveDirection = Vector3.left;
                break;

            case ConstTemplate.BtnControlDirectionType.BtnControlDirectionRight:
                moveDirection = Vector3.right;
                break;
        }
        Vector3 vec3MoveDirection = moveDirection * speedMoveByBtn * Time.deltaTime;

        if (LimitRangeOfPlayerMove(vec3MoveDirection))
            this.transform.Translate(vec3MoveDirection);
    }

    // 限制主角的移动范围
    private bool LimitRangeOfPlayerMove(Vector3 vec3AddValue)
    {
        Vector3 vec3PlayerEndPos = this.transform.position + vec3AddValue;
        float vec3PlayerLimitX = ConstTemplate.screenWith / 2 - ConstTemplate.playerRadius * 1.2f;
        if (vec3PlayerEndPos.x >= vec3PlayerLimitX)
        {
            this.transform.position = new Vector3(vec3PlayerLimitX, this.transform.position.y,this.transform.position.z);
            return false;
        }
        else if (vec3PlayerEndPos.x <= -vec3PlayerLimitX - ConstTemplate.playerRadius)
        {
            this.transform.position = new Vector3(vec3PlayerLimitX, this.transform.position.y, this.transform.position.z);
            return false;
        }
        return true;
    }

    // 在游戏开始之前播放的动画
    private void BeforeStartGamePlayerAnimation()
    {
        if (isGameStartBeforeFinish)
            return;

        // 是否到达指定高度了，在上移过程中，泡泡是可以左右移动的
        if (Math.Abs(this.transform.position.y - ConstTemplate.playerPlayPosY) < 0.1f)
        {
            scriptGamseManager.PlayGameStart();
            isGameStartBeforeFinish = true;
            return;
        }

        // 在一定的时间内移动到指定位置，第一个参数为this.transform.position， 自己写的new Vector3(x，y，z)不好使，不理解
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x, ConstTemplate.playerPlayPosY, this.transform.position.z), ConstTemplate.playerSpeedBeforeGameStart * Time.deltaTime);
    }

    // 游戏结束player需要处理的内容
    public void GameOverPlayer()
    {
        this.circleCollider2DPlayer.enabled = false;
        this.isPlaying = false;
        this.isAnimMoveLeftOrRight = false;

        animatorPlayer.Stop();

        PlayAnimBubbleDie();

    }

    // 播放泡泡死亡动画
    private void PlayAnimBubbleDie()
    {
        animatorPlayer.gameObject.SetActive(false);
        animatorBubble.PlayInFixedTime("bubble_die");
    }


    // 播放泡泡正在死亡动画
    public void PlayAnimPlayerDying(bool boolValue)
    {
        animatorPlayer.SetBool("player_dying", boolValue);
    }

}
