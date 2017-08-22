using System;
using UnityEngine;
using System.Collections;

// 主角即玩家
public class Player : MonoBehaviour{

    public bool isPlaying = false;               // 是否正在游戏中
    public bool isAnimMoveLeftOrRight = true;    // 是否可以左右移动
    public bool isGameStartBeforeFinish = false; // 是否播放完开场动画了
    public bool isPlayAnimPlayerDying = false;   // 是否正在播放玩家正在死亡动画

    public float speedMoveByBtn = 5.0f; // 按钮控制其左右移动的速度

    public ConstTemplate.RewardToolType rewardToolType = ConstTemplate.RewardToolType.RewardToolNoBuff; // 主角buff类型

    public Vector3 moveDirection = Vector3.zero; // 主角移动的方向

    public GameObject goBubbleNoDie;         // 主角不死动画
    public GameObject goPlayerAttract;       // 主角吸引奖励泡泡动画

    public Animator animatorPlayer;          // 主角动画
    public Animator animatorBubble;          // 泡泡动画

    public CircleCollider2D circleCollider2DPlayer; // 主角的碰撞盒

    public PlayerScore scriptPlayerScore;    // 玩家分数脚本
    public PlayerLife scriptPlayerLife;      // 玩家生命脚本
    public GameManager scriptGamseManager;   // 管理类

    void Start(){
        this.circleCollider2DPlayer.enabled = false;
        goBubbleNoDie.SetActive(false);
        goPlayerAttract.SetActive(false);
    }

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

            case "germ":
                ColliderByGerm(other);
                break;

            case "reward_tool":
                ColliderByRewardTool(other);
                break;
        }

    }

    // 碰撞奖励泡泡事件
    private void ColliderByRewardBubble(Collider2D other2D){

        // 获取奖励泡泡增加的生命值
        RewardBubble rewardBubble = other2D.GetComponent<RewardBubble>();
        if (!rewardBubble) return;

        rewardBubble.EatenByPlayer(this.gameObject);                           // 奖励泡泡被吃动画
        scriptPlayerLife.IncreasePlayerLife(rewardBubble.hpRewardBubble);      // 增加玩家生命值
        scriptPlayerScore.IncreasePlayerScore(rewardBubble.scoreRewardBubble); // 增加玩家分数

        // 播放吃东西动画
        PlayAnimEatRewardBubble();
    }

    // 碰撞germ(细菌)事件
    private void ColliderByGerm(Collider2D other2D){

        // 获取细菌germ
        Germ germ = other2D.GetComponent<Germ>();
        if (!germ) return;

        // 关闭碰撞检测了
        germ.HarmPlayerFinish();

        switch (rewardToolType)
        {
            case ConstTemplate.RewardToolType.RewardToolNoDie:
                germ.PlayAnimationDying();                              // 播放germ死亡动画
                scriptPlayerScore.IncreasePlayerScore(germ.scoreGerm);  // 增加玩家分数
                break;
            case ConstTemplate.RewardToolType.RewardToolAddLife:
            case ConstTemplate.RewardToolType.RewardToolAttract:
                scriptPlayerLife.IncreasePlayerLife(-germ.hpGerm);       // 减少生命
                PlayAnimHurtByGerm();                                    // 播放受伤动画
                break;
            case ConstTemplate.RewardToolType.RewardToolLargen:
                scriptPlayerLife.IncreasePlayerLife(-germ.hpGerm / 4);   // 减少生命
                PlayAnimHurtByGerm();                                    // 播放受伤动画
                break;
            case ConstTemplate.RewardToolType.RewardToolLessen:
                scriptPlayerLife.IncreasePlayerLife(-germ.hpGerm * 1.5f); // 减少生命
                PlayAnimHurtByGerm();                                     // 播放受伤动画
                break;
            case ConstTemplate.RewardToolType.RewardToolNoBuff:
                scriptPlayerLife.IncreasePlayerLife(-germ.hpGerm);        // 减少生命
                PlayAnimHurtByGerm();                                     // 播放受伤动画
                break;
        }

    }

    // 碰撞奖励道具事件
    private void ColliderByRewardTool(Collider2D other2D){

        // 获取奖励泡泡增加的生命值
        RewardTools rewardTools = other2D.GetComponent<RewardTools>();
        if (!rewardTools) return;

        // 奖励道具类型
        rewardToolType = rewardTools.rewardToolType;

        rewardTools.EatenByPlayer(this.gameObject);                          // 奖励泡泡被吃动画
        scriptPlayerScore.IncreasePlayerScore(rewardTools.scoreRewardTools); // 增加玩家分数

        // 播放吃东西动画
        PlayAnimEatRewardBubble();

        switch (rewardToolType)
        {
            case ConstTemplate.RewardToolType.RewardToolNoDie:
                PlayerNoDieCallBack();
                break;
            case ConstTemplate.RewardToolType.RewardToolAddLife:
            case ConstTemplate.RewardToolType.RewardToolAttract:
                PlayerAttractCallBack();
                break;
            case ConstTemplate.RewardToolType.RewardToolLargen:
                PlayerLargenCallBack();
                break;
            case ConstTemplate.RewardToolType.RewardToolLessen:
                PlayerLessenCallBack();
                break;
            case ConstTemplate.RewardToolType.RewardToolNoBuff:
                break;
        }

    }

    // 主角不死buff回调
    private void PlayerNoDieCallBack(){
        goBubbleNoDie.SetActive(true);
        CancelInvoke("playerNoDieFinish"); // 先暂停之前的计时，重新计算
        Invoke("playerNoDieFinish", ConstTemplate.rewardToolsDurationTime); // 在规定的时间后结束buff
    }

    // 主角不死buff结束
    private void playerNoDieFinish(){
        goBubbleNoDie.SetActive(false);
        rewardToolType = ConstTemplate.RewardToolType.RewardToolNoBuff;
        CancelInvoke("playerNoDieFinish"); // 结束计时
        DestoryGermByScreen();
    }

    // 主角变大buff
    private void PlayerLargenCallBack(){
        this.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        CancelInvoke("PlayerLargenAndLessenFinish");
        Invoke("PlayerLargenAndLessenFinish", ConstTemplate.rewardToolsDurationTime);
    }

    // 主角变小buff
    private void PlayerLessenCallBack(){
        this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        CancelInvoke("PlayerLargenAndLessenFinish");
        Invoke("PlayerLargenAndLessenFinish", ConstTemplate.rewardToolsDurationTime);
    }
    // 主角变大buff结束
    private void PlayerLargenAndLessenFinish(){
        this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        rewardToolType = ConstTemplate.RewardToolType.RewardToolNoBuff;
        CancelInvoke("PlayerLargenAndLessenFinish"); // 结束计时
        DestoryGermByScreen();
    }

    // 主角吸引奖励泡泡回调
    private void PlayerAttractCallBack(){
        goPlayerAttract.SetActive(true);
        CancelInvoke("PlayerAttractFinish");
        Invoke("PlayerAttractFinish", ConstTemplate.rewardToolsDurationTime);
    }

    // 主角吸引奖励泡泡buff结束
    private void PlayerAttractFinish(){
        goPlayerAttract.SetActive(false);
        rewardToolType = ConstTemplate.RewardToolType.RewardToolNoBuff;
        DestoryGermByScreen();
    }


    // 销毁屏幕内的所有germ
    private void DestoryGermByScreen()
    {
        // 在屏幕范围内的germ都将自爆
        for (int i = 0; i < scriptGamseManager.goGermCreate.transform.childCount; i++)
        {
            Transform transChild = scriptGamseManager.goGermCreate.transform.GetChild(i);
            if (transChild.position.y < ConstTemplate.screenHeight / 2)
            {
                Germ germChild = transChild.GetComponent<Germ>();
                if (germChild && germChild.animator)
                    germChild.PlayAnimationDying();
            }
        }
    }

    // 吃掉其他泡泡动画
    private void PlayAnimEatRewardBubble(){
        
        // 玩家正在死亡的时候,吃东西不播放吃东西动画
        if (isPlayAnimPlayerDying) return; 
        animatorPlayer.PlayInFixedTime("player_eat");
    }

    // 被细菌伤害了
    private void PlayAnimHurtByGerm()
    {
        //print("-- silent -- player play hurt by germ --");
    }
    // 左右移动
    public void MovePlayerLeftOrRightByBtn(ConstTemplate.BtnControlDirectionType btnDirectionType){
        
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
    private bool LimitRangeOfPlayerMove(Vector3 vec3AddValue){

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
    private void BeforeStartGamePlayerAnimation(){

        if (isGameStartBeforeFinish)
            return;

        // 是否到达指定高度了，在上移过程中，泡泡是可以左右移动的
        if (Math.Abs(this.transform.position.y - ConstTemplate.playerPlayPosY) < 0.001f)
        {
            scriptGamseManager.PlayGameStart();
            return;
        }

        // 在一定的时间内移动到指定位置，第一个参数为this.transform.position， 自己写的new Vector3(x，y，z)不好使，不理解
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x, ConstTemplate.playerPlayPosY, this.transform.position.z), (this.transform.position.y < ConstTemplate.playerPlayPosYQuick ? ConstTemplate.playerSpeedBeforeGameStartQuick : ConstTemplate.playerSpeedBeforeGameStart) * Time.deltaTime);
    }

    // 游戏结束player需要处理的内容
    public void GameOverPlayer(){

        GamePauseOrResumePlayer(false);

        animatorPlayer.Stop();
        goBubbleNoDie.SetActive(false);

        PlayAnimBubbleDie();
    }

    // 暂停or继续游戏
    public void GamePauseOrResumePlayer(bool pauseOrResume)
    {
        this.circleCollider2DPlayer.enabled = pauseOrResume;
        this.isPlaying = pauseOrResume;
        this.isAnimMoveLeftOrRight = pauseOrResume;
    }

    // 播放泡泡死亡动画
    private void PlayAnimBubbleDie(){

        animatorPlayer.gameObject.SetActive(false);
        animatorBubble.PlayInFixedTime("bubble_die");
    }


    // 播放泡泡正在死亡动画
    public void PlayAnimPlayerDying(bool boolValue){

        // 播放增在死亡动画 boolValue = true
        if (isPlayAnimPlayerDying != boolValue && !isPlayAnimPlayerDying)
            animatorPlayer.PlayInFixedTime("player_die");
        
        // 播放待机动画 boolValue = false
        if (isPlayAnimPlayerDying != boolValue && isPlayAnimPlayerDying)
            animatorPlayer.PlayInFixedTime("player_idle");

        isPlayAnimPlayerDying = boolValue;
    }

    // 开始游戏
    public void PlayGameStartPlayer(){

        isPlaying = true;
        isGameStartBeforeFinish = true;
        this.circleCollider2DPlayer.enabled = true;

    }

}
