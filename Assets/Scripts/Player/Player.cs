using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Animator animatorPlayer; // 泡泡动画
    public bool isEatFinished; // 是否吃完了
    public GameManager gameManager;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

    // 2d 碰撞触发函数
    void OnTriggerEnter2D(Collider2D other){

        print("-- silent -- other tag Trigger == " + other.tag);

        switch (other.tag)
        {
            case "reward_bubble":
                ColliderByRewardBubble(other);
                break;
        }

    }

    // 碰撞奖励泡泡事件
    private void ColliderByRewardBubble(Collider2D other2D)
    {
        // 播放吃东西动画
        EatRewardBubble();

        // 获取奖励泡泡增加的生命值
        RewardBubble rewardBubble = other2D.GetComponent<RewardBubble>();
        if (!rewardBubble) return;
        gameManager.IncreasePlayerLife(rewardBubble.hpRewardBubble);

        // 删除奖励泡泡
        Destroy(other2D.gameObject);
        //other2D.gameObject.SetActive(false);
    }


    private void EatRewardBubble()
    {
        animatorPlayer.PlayInFixedTime("player_eat");
    }

}
