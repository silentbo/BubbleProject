using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

// 游戏管理类
public class GameManager : MonoBehaviour {

    public float playerLife = 20.0f; // 玩家生命值(实时更新)
    public float playerLifeMax = 20.0f; // 玩家最大生命值
    public float playerLifeMin = 0.0f;  // 玩家最小生命值
    public float playerLifeDecreasePerSecond = 1.0f; // 玩家每秒减少的生命值

    public PlayerLife playerLifeScript; // 玩家生命改变显示

	// Use this for initialization
	void Start () {

        //// 3秒之后开始，每秒减少玩家血量
        //InvokeRepeating("DecreasePlayerLifePerSecond", 3.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {

        if (playerLife >= playerLifeMin)
            DecreasePlayerLifePerSecond();
    }

    // 每秒减少玩家的生命
    private void DecreasePlayerLifePerSecond()
    {
        playerLifeDecreasePerSecond = Time.deltaTime;
        playerLife = playerLife > playerLifeMin ? playerLife - playerLifeDecreasePerSecond : playerLifeMin;
        ChangePlayerLife();
        if (playerLife <= playerLifeMin)
            PlayGameOver();
    }

    // 增加玩家生命(增加的生命值)
    public void IncreasePlayerLife(float increaseLifeNum)
    {
        playerLife = playerLife > playerLifeMax ? playerLifeMax : playerLife + increaseLifeNum;
        ChangePlayerLife();
    }

    private void ChangePlayerLife()
    {
        playerLifeScript.SetPlayerLife(playerLife / playerLifeMax);
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
