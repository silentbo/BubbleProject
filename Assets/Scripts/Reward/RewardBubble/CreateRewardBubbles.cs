using UnityEngine;

// 创建本关卡中的奖励泡泡
public class CreateRewardBubbles : MonoBehaviour
{


    public GameManager gameManager;

	// Use this for initialization
	void Start () {
	    CreateRewardLevelBubble(gameManager.levelId);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // 创建关卡奖励泡泡
    private void CreateRewardLevelBubble(int levelId)
    {
        // 读取泡泡数据
        RewardBubbleLevelData rewardBubbleLevelData = RewardBubbleJsonParse.LoadRewardBubbleLevelJsonData(levelId);

        for (int i = 0; i < rewardBubbleLevelData.reward_bubble_data.Length; i ++)
        {
            CreateOneRewardLevelBubble(rewardBubbleLevelData.reward_bubble_data[i]);
        }

    }

    // 创建一个奖励泡泡
    private void CreateOneRewardLevelBubble(RewardBubbleData rewardBubbleDate)
    {
        GameObject goNewRewardBubble = new GameObject();
        goNewRewardBubble.name = "reward_bubble_" + rewardBubbleDate.id.ToString();
        goNewRewardBubble.transform.parent = this.transform;
        goNewRewardBubble.tag = "reward_bubble";
        goNewRewardBubble.transform.localPosition = new Vector3(rewardBubbleDate.randomX, rewardBubbleDate.randomY, 0.0f);
        goNewRewardBubble.transform.localScale = new Vector3(rewardBubbleDate.randomScale, rewardBubbleDate.randomScale, rewardBubbleDate.randomScale);

        Sprite spriteRewardBubble = Resources.Load<Sprite>("Player/bubble_02_65");
        SpriteRenderer spriteRendererRewardBubble = goNewRewardBubble.AddComponent<SpriteRenderer>();
        spriteRendererRewardBubble.sprite = spriteRewardBubble;
        spriteRendererRewardBubble.sortingLayerName = "other_object";

        MoveDownTemplate moveDownRewardBubble = goNewRewardBubble.AddComponent<MoveDownTemplate>();
        moveDownRewardBubble.isAnimation = true;
        moveDownRewardBubble.speedMoveDown = 1.8f;

        goNewRewardBubble.AddComponent<CircleCollider2D>();

        RewardBubble rewardBubble = goNewRewardBubble.AddComponent<RewardBubble>();
        rewardBubble.hpRewardBubble = rewardBubbleDate.randomScale * 2.0f;
        rewardBubble.scaleRandomRewardBubble = rewardBubbleDate.randomScale;
        rewardBubble.isEaten = false;

    }


}
