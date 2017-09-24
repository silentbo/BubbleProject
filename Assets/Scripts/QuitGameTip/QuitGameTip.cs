using UnityEngine;
using System.Collections;

public class QuitGameTip : MonoBehaviour {

    public bool isPlaying = true; // 是否正在游戏中

    public float quitGameTimeInterval = 2.0f; // 退出游戏两次按键间隔时间
    public float quitGameTimeOld = -3.0f;     // 退出游戏两次按键间隔时间

    public Animator animatorQuitGame; // 退出游戏提示对象
	
	// Update is called once per frame
	void Update () {
        if (isPlaying)
            QuitGameKey();
	}

    // 退出按键
    public void QuitGameKey()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Time.time - quitGameTimeOld <= quitGameTimeInterval)
                Application.Quit();
            else
            {
                animatorQuitGame.enabled = true;
                animatorQuitGame.PlayInFixedTime("quit_game_tip");
                quitGameTimeOld = Time.time;
            }
        }
    }

}
