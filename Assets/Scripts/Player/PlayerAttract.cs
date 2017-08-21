using UnityEngine;

// 主角吸引buff类
public class PlayerAttract : MonoBehaviour{

    public GameObject goPlayer; // 主角

    // 碰撞检测
    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "reward_bubble":
            case "reward_tool":
                ColliderByRewardBubble(other);
                break;
        }
    }

    // 碰撞到了奖励泡泡
    private void ColliderByRewardBubble(Collider2D other)
    {
        RewardBubble rewardBubble = other.GetComponent<RewardBubble>();
        if (!rewardBubble) return;

        rewardBubble.AttractByPlayer(goPlayer);
    }

}
