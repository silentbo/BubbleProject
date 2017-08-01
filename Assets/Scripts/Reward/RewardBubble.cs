using UnityEngine;
using System.Collections;

public class RewardBubble : MonoBehaviour
{

    public float hpRewardBubble = 1.0f; // 泡泡奖励生命值
    public float scaleRandomRewardBubble = 0.0f; // 泡泡缩放比例

    public float speedMoveDown = 2.0f; // 下落速度，跟背景下落速度一致
    public bool isMoveDown = true; // 是否向下移动

	// Use this for initialization
	void Start (){
	    InitRewardBubble();
	}
	
	// Update is called once per frame
	void Update () {
        MoveDown();
    }

    // 初始化泡泡的生命和scale
    private void InitRewardBubble(){
        scaleRandomRewardBubble = Random.Range(0.2f, 1.0f);
        this.transform.localScale = new Vector3(scaleRandomRewardBubble, scaleRandomRewardBubble, scaleRandomRewardBubble);
        hpRewardBubble = scaleRandomRewardBubble;
    }

    private void MoveDown()
    {
        if (!isMoveDown)
            return;

        this.transform.Translate(Vector3.down * speedMoveDown * Time.deltaTime);
    }
}
