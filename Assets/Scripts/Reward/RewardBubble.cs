using UnityEngine;
using System.Collections;

public class RewardBubble : MonoBehaviour
{

    public float hpRewardBubble = 1.0f; // 泡泡奖励生命值
    public float scaleRandomRewardBubble = 0.0f; // 泡泡缩放比例

	// Use this for initialization
	void Start (){
	    InitRewardBubble();
	}
	
	// Update is called once per frame
	void Update () {

    }

    // 初始化泡泡的生命和scale
    private void InitRewardBubble(){
        scaleRandomRewardBubble = Random.Range(0.2f, 1.0f);
        this.transform.localScale = new Vector3(scaleRandomRewardBubble, scaleRandomRewardBubble, scaleRandomRewardBubble);
        hpRewardBubble = scaleRandomRewardBubble;
    }
}
