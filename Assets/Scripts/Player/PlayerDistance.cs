using System.Text;
using UnityEngine;
using UnityEngine.UI;

// 玩家走过的距离
// 背景移动的速度 * 每帧的时间 就是每帧移动的距离
public class PlayerDistance : MonoBehaviour {

    public bool isPlaying = true;          // 是否正在游戏

    public float playerDistance = 0.0f;    // 玩家走过的距离

    public Text textPlayerDistance;        // 玩家走过的距离

    public GameManager scriptGameManager;  // 管理类
	
	// Update is called once per frame
	void Update () {

	    if (isPlaying){

	        ShowPlayerDistance();
	    }
	}

    // 显示距离
    private void ShowPlayerDistance()
    {
        playerDistance += Time.deltaTime * scriptGameManager.speedBgMove;

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(playerDistance.ToString("0.00"));
        stringBuilder.Append(" m");
        
        textPlayerDistance.text = stringBuilder.ToString();
    }
} 
