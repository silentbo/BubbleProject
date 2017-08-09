using UnityEngine;
using UnityEngine.UI;

// 玩家生命值
public class PlayerLife : MonoBehaviour{

    public bool isPlaying = false;                  // 是否正在游戏中

    public float playerLife = 0.0f;                 // 玩家生命值
    public float vec2PlayerLifeChangeHeight = 0.0f; // 生命改变图片的Rect Transform 坐标

    public Vector3 vec3PlayerLifeChangeMark = Vector3.zero; // 生命改变图片Mark的Rect Transform 坐标

    public Image playerLifeChange;                 // 玩家生命改变值
    public Image playerLifeChangeMark;             // 玩家生命改变mark

    public GameManager scriptGameManager;          // 管理类

    void Start()
    {
        vec2PlayerLifeChangeHeight = playerLifeChange.rectTransform.rect.height;
        vec3PlayerLifeChangeMark = playerLifeChangeMark.rectTransform.localPosition;
    }

    void Update(){

        if (isPlaying){

            DecreasePlayerLifePerSecond();
        }
    }

    // 血条开始计时
    public void PlayerLifeStart()
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
        SetPlayerLifeChangeMarkPosY(ratioLife);
    }

    // 增加玩家生命(增加的生命值)
    public void IncreasePlayerLife(float increaseLifeNum)
    {
        playerLife = playerLife > ConstTemplate.playerLifeMax ? ConstTemplate.playerLifeMax : playerLife + increaseLifeNum;
        SetPlayerLife(playerLife);
    }

    // 设置当前mark的Y轴的位置
    private void SetPlayerLifeChangeMarkPosY(float ratioLife)
    {
        float yPosMark = vec3PlayerLifeChangeMark.y - (1 - ratioLife)*vec2PlayerLifeChangeHeight;
        playerLifeChangeMark.rectTransform.localPosition = new Vector3(vec3PlayerLifeChangeMark.x, yPosMark, vec3PlayerLifeChangeMark.z);
    }

}
