using UnityEngine;
using UnityEngine.UI;

// 玩家生命值
public class PlayerLife : MonoBehaviour{

    public bool isPlaying = false;                  // 是否正在游戏中

    public float playerLife = 0.0f;                 // 玩家生命值

    public Image playerLifeChange;                 // 玩家生命改变值

    public Animator animatorPlayerLife;            // 玩家生命动画

    public GameManager scriptGameManager;          // 管理类
    public Player scriptPlayer;                    // 主角类

    void Update(){

        if (isPlaying){

            DecreasePlayerLifePerSecond();
        }
    }

    // 血条开始计时
    public void PlayGameStartPlayerLife()
    {
        isPlaying = true;
        playerLife = ConstTemplate.playerLifeMax;
    }

    // 每秒减少玩家的生命
    private void DecreasePlayerLifePerSecond()
    {
        if (playerLife < ConstTemplate.playerLifeMin) return;

        playerLife = playerLife > ConstTemplate.playerLifeMin ? playerLife - Time.deltaTime : ConstTemplate.playerLifeMin;

        SetPlayerLife(playerLife);

        if (playerLife < ConstTemplate.playerLifeMin)
            scriptGameManager.PlayGameOver();
    }

    // 设置当前玩家生命值
    public void SetPlayerLife(float playerLife)
    {
        float ratioLife = playerLife / ConstTemplate.playerLifeMax;
        playerLifeChange.fillAmount = ratioLife;
        PlayDiePlayerLifeAnim(ratioLife);
    }

    // 增加玩家生命(增加的生命值)
    public void IncreasePlayerLife(float increaseLifeNum)
    {
        playerLife = playerLife > ConstTemplate.playerLifeMax ? ConstTemplate.playerLifeMax : playerLife + increaseLifeNum;
        SetPlayerLife(playerLife);
        PlayIncreasePlayerLifeAnim();
    }

    // 播放玩家增加生命的动画
    private void PlayIncreasePlayerLifeAnim()
    {
        if (playerLifeChange.fillAmount >= ConstTemplate.playerLifeDieValue)
            animatorPlayerLife.PlayInFixedTime("player_life_Increase");
    }

    // 播放玩家生命要结束的动画
    private void PlayDiePlayerLifeAnim(float lifeValue)
    {
        if (lifeValue >= ConstTemplate.playerLifeDieValue || lifeValue <= 0.0f)
        {
            animatorPlayerLife.SetBool("player_life_die", false);
            scriptPlayer.PlayAnimPlayerDying(false);
            return;
        }

        animatorPlayerLife.SetBool("player_life_die", true);
        animatorPlayerLife.Play("player_life_die");
        scriptPlayer.PlayAnimPlayerDying(true);
    }

    // 生命暂停or继续
    public void GamePauseOrResumePlayerLife(bool pauseOrResume)
    {
        this.isPlaying = pauseOrResume;
    }

    public void GameOverPlayerLife()
    {
        GamePauseOrResumePlayerLife(false);
    }
}
