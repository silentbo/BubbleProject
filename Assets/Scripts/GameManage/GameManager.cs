using UnityEngine;

// 游戏管理类
public class GameManager : MonoBehaviour {

    public float playerLife = 10.0f; // 玩家生命值(实时更新)
    public float playerLifeDecreasePerSecond = 1.0f; // 玩家每秒减少的生命值

    public PlayerLife playerLifeScript; // 玩家生命改变显示

    public int levelId = 1;

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

    // 游戏结束
    private void PlayGameOver()
    {
        print("-- silent -- game over -- ");
        CancelInvoke("DecreasePlayerLifePerSecond");
    }

    // 游戏暂停
    private void PlayGamePause()
    {
        print("-- silent -- game pause");
    }

    // 游戏恢复
    private void PlayGameResume()
    {
        print("-- silent -- game resume");
    }

   

}
