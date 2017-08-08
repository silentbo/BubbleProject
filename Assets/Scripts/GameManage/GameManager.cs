using UnityEngine;

// 游戏管理类
public class GameManager : MonoBehaviour {

    public float playerLife = 10.0f; // 玩家生命值(实时更新)
    public float playerLifeDecreasePerSecond = 1.0f; // 玩家每秒减少的生命值

    public PlayerLife playerLifeScript; // 玩家生命改变显示

    public int levelId = 1; // 第几个关卡

    public int playerDistance = 0; // 玩家走过的距离

    public MoveDownTemplate[] bgMoveDownTemplateScrips; // 背景的移动效果

    public CreateRewardBubbles rewardBubbleCreateScrip;


	// Use this for initialization
	void Start (){
	    levelId = PlayerPrefs.GetInt(ConstTemplate.keyPlayerPrefsLevelId, 1);
	}
	
	// Update is called once per frame
	void Update () {

        DecreasePlayerLifePerSecond();
    }

    // 每秒减少玩家的生命
    private void DecreasePlayerLifePerSecond()
    {
        if (playerLife < ConstTemplate.playerLifeMin) return;

        playerLifeDecreasePerSecond = Time.deltaTime;
        playerLife = playerLife > ConstTemplate.playerLifeMin ? playerLife - playerLifeDecreasePerSecond : ConstTemplate.playerLifeMin;
        ChangePlayerLife();
        if (playerLife <= ConstTemplate.playerLifeMin)
            PlayGameOver();
    }

    // 增加玩家生命(增加的生命值)
    public void IncreasePlayerLife(float increaseLifeNum)
    {
        print("-- silent -- increase player life == " + increaseLifeNum);
        playerLife = playerLife > ConstTemplate.playerLifeMax ? ConstTemplate.playerLifeMax : playerLife + increaseLifeNum;
        ChangePlayerLife();
    }

    // 改变生命值
    private void ChangePlayerLife()
    {
        playerLifeScript.SetPlayerLife(playerLife / ConstTemplate.playerLifeMax);
    }


    // 开始游戏
    public void PlayGameStart()
    {
        print("-- silent -- game start -- ");

        for (int i = 0; i < bgMoveDownTemplateScrips.Length; i++)
        {
            bgMoveDownTemplateScrips[i].isAnimation = true;
            bgMoveDownTemplateScrips[i].speedMoveDown = 2.0f;
        }

        rewardBubbleCreateScrip.CreateRewardLevelBubble(levelId);

    }

    // 游戏结束
    public void PlayGameOver()
    {
        print("-- silent -- game over -- ");
        CancelInvoke("DecreasePlayerLifePerSecond");
    }

    // 游戏暂停
    public void PlayGamePause()
    {
        print("-- silent -- game pause");
    }

    // 游戏恢复
    public void PlayGameResume()
    {
        print("-- silent -- game resume");
    }

   

}
