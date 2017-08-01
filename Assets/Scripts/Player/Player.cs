using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Animator animatorPlayer; // 泡泡动画
    public bool isEatFinished; // 是否吃完了
    public GameManager gameManager;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Eat", 2.0f, 0.5f);
        Invoke("CanelInvokeTemp", 5.0f);

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

    // 2d 碰撞触发函数
    void OnCollisionEnter2D(Collider2D other)
    {
        print("-- silent -- other tag collision == " + other.tag);
        switch (other.tag)
        {
            case "reward_bubble":
                ColliderByRewardBubble(other);
                break;
        }

    }

    private void ColliderByRewardBubble(Collider2D other2D)
    {
        RewardBubble rewardBubble = other2D.GetComponent<RewardBubble>();
        if (!rewardBubble) return;
        gameManager.IncreasePlayerLife(rewardBubble.hpRewardBubble);
    }


    private void Eat()
    {
        //animatorPlayer.SetBool("eatFinish", true);
        //animatorPlayer.Play("player_eat");
        animatorPlayer.PlayInFixedTime("player_eat");
        //animatorPlayer.SetBool("eatStart", true);
    }

    private void CanelInvokeTemp()
    {
        CancelInvoke("Eat");
        CancelInvoke("CanelInvokeTemp");
    }

}
