using UnityEngine;

// 创建本关卡中的奖励泡泡
public class CreateRewardBubbles : MonoBehaviour{

    private RuntimeAnimatorController runtimeAnimatorControllerRewardBubble; // 默认播放的动画，提出来是为了只读取一次
    private Sprite spriteRewardBubble; // 默认的奖励泡泡的图片，不加的话，碰撞盒的大小就有问题，不明白

	// Use this for initialization
	void Start () {

        runtimeAnimatorControllerRewardBubble = Resources.Load<RuntimeAnimatorController>(ConstTemplate.resPathAnimatorBubbleMotion);
	    spriteRewardBubble = Resources.Load<Sprite>(ConstTemplate.resPathSpriteDefaultRewardBubble);
	}
	
    // 创建关卡奖励泡泡
    public void CreateRewardLevelBubble(int levelId)
    {
        // 读取泡泡数据
        RewardBubbleLevelData rewardBubbleLevelData = JsonParseTemplate.LoadRewardBubbleLevelJsonData(levelId);

        for (int i = 0; i < rewardBubbleLevelData.reward_bubble_data.Length; i ++)
        {
            CreateOneRewardBubble(rewardBubbleLevelData.reward_bubble_data[i]);
        }
    }

    // 创建一个奖励泡泡
    private void CreateOneRewardBubble(ObjectPositionData rewardBubblePositionDate)
    {
        // 创建对象，设置属性值
        GameObject goNewRewardBubble = new GameObject();
        goNewRewardBubble.name = "reward_bubble_" + rewardBubblePositionDate.id.ToString();
        goNewRewardBubble.transform.parent = this.transform;
        goNewRewardBubble.tag = "reward_bubble";
        goNewRewardBubble.transform.localPosition = new Vector3(rewardBubblePositionDate.randomX, rewardBubblePositionDate.randomY, 0.0f);
        float randomScale = Random.Range(0.3f, 1.0f);
        goNewRewardBubble.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

        // 添加 SpriteRenderer 组件， 设置层级
        SpriteRenderer spriteRendererRewardBubble = goNewRewardBubble.AddComponent<SpriteRenderer>();
        spriteRendererRewardBubble.sprite = spriteRewardBubble;
        spriteRendererRewardBubble.sortingLayerName = "other_object";

        // 添加 MoveDownTemplate 组件， 设置速度
        MoveDownTemplate moveDownRewardBubble = goNewRewardBubble.AddComponent<MoveDownTemplate>();
        moveDownRewardBubble.isAnimation = true;
        moveDownRewardBubble.speedMoveDown = ConstTemplate.rewardBubbleSpeedMoveDown;

        // 添加碰撞盒
        CircleCollider2D circleCollider2D = goNewRewardBubble.AddComponent<CircleCollider2D>();
        //circleCollider2D.radius = ConstTemplate.playerRadius * randomScale;

        // 添加 RewardBubble 组件， 设置其属性
        RewardBubble rewardBubble = goNewRewardBubble.AddComponent<RewardBubble>();
        rewardBubble.hpRewardBubble = randomScale * ConstTemplate.rewardBubbleMaxHp;
        rewardBubble.scoreRewardBubble = randomScale * ConstTemplate.rewardBubbleMaxScore;
        rewardBubble.scaleRewardBubble = randomScale;
        rewardBubble.speedMoveToPlayer = randomScale * ConstTemplate.rewardBubbleSpeedMoveToPlayerMax;
        rewardBubble.isEaten = false;

        // 添加 Animator 组件， 设置对应的动画
        Animator animatorRewardBubble = goNewRewardBubble.AddComponent<Animator>();
        animatorRewardBubble.runtimeAnimatorController = runtimeAnimatorControllerRewardBubble;

    }


}
