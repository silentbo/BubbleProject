using UnityEngine;

// 主角吸引buff类
public class PlayerAttract : MonoBehaviour{

    public bool isPlaying = true; // 是否在游戏中

    public GameObject goPlayer; // 主角

    // 碰撞检测
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isPlaying) return;

        switch (other.tag)
        {
            case "reward_bubble":
                ColliderByRewardBubble(other);
                break;
            case "reward_tool":
                ColliderByRewarTool(other);
                break;
        }
    }

    // 碰到了奖励道具泡泡
    private void ColliderByRewarTool(Collider2D other)
    {
        RewardTools rewardTools = other.GetComponent<RewardTools>();
        if (!rewardTools) return;
        rewardTools.AttractByPlayer(goPlayer);
    }

    // 碰撞到了奖励泡泡
    private void ColliderByRewardBubble(Collider2D other)
    {
        RewardBubble rewardBubble = other.GetComponent<RewardBubble>();
        if (!rewardBubble) return;

        rewardBubble.AttractByPlayer(goPlayer);
    }

}
