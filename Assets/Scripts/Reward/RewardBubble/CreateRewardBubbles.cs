using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// 创建本关卡中的奖励泡泡
public class CreateRewardBubbles : MonoBehaviour
{

    public PlayerDistance scriptPlayerDistance; // 移动距离 脚本

    private RuntimeAnimatorController runtimeAnimatorControllerRewardBubble; // 默认播放的动画，提出来是为了只读取一次
    private Sprite spriteRewardBubble; // 默认的奖励泡泡的图片，不加的话，碰撞盒的大小就有问题，不明白
    private List<ObjectPositionData> listRewardBubblePositionData = new List<ObjectPositionData>(); // 奖励泡泡的位置信息
    private float distanceCreateRewardBubble = 0.0f; // 上次创建奖励泡泡移动的距离

	// Use this for initialization
	void Start () {

        runtimeAnimatorControllerRewardBubble = Resources.Load<RuntimeAnimatorController>(ConstTemplate.resPathAnimatorBubbleMotion);
	    spriteRewardBubble = Resources.Load<Sprite>(ConstTemplate.resPathSpriteDefaultRewardBubble);
	}

    void Update(){

        CreateRewardToolByDistance();
    }

    // 排序，通过Y轴的坐标类排序 大到小
    private int SortRewardBubblePositionY(ObjectPositionData opdL, ObjectPositionData opdR)
    {
        if (opdL.randomY < opdR.randomY)
            return 1;
        else if (opdL.randomY == opdR.randomY)
            return 0;
        else return -1;
    }

    // 创建关卡奖励泡泡
    public void CreateRewardLevelBubble(int levelId)
    {
        // 读取泡泡数据
        RewardBubbleLevelData rewardBubbleLevelData = JsonParseTemplate.LoadRewardBubbleLevelJsonData(levelId);
        listRewardBubblePositionData = rewardBubbleLevelData.reward_bubble_data.ToList();
        listRewardBubblePositionData.Sort(SortRewardBubblePositionY);
        distanceCreateRewardBubble = -ConstTemplate.screenHeight/2;
    }


    // 创建奖励道具，通过距离来创建奖励道具，优化，避免一帧实例化太多，造成卡顿
    private void CreateRewardToolByDistance()
    {
        // 没有数据、没有到下一屏幕，不创建对象
        if (listRewardBubblePositionData.Count <= 0) return;
        if (distanceCreateRewardBubble + ConstTemplate.screenHeight / 2 > scriptPlayerDistance.playerDistance) return;

        distanceCreateRewardBubble = scriptPlayerDistance.playerDistance;
        float maxPosYCreateRewardBubble = scriptPlayerDistance.playerDistance - ConstTemplate.screenHeight / 2 + ConstTemplate.screenHeight * 1.5f;

        // 从后向前遍历，动态删除的哦
        for (int i = listRewardBubblePositionData.Count - 1; i >= 0; i --)
        {
            // 之后的下次在创建
            if(listRewardBubblePositionData[i].randomY > maxPosYCreateRewardBubble)
                break;
            // 创建奖励泡泡
            CreateOneRewardBubble(listRewardBubblePositionData[i], distanceCreateRewardBubble);
            // 删除已经生成过的奖励泡泡
            listRewardBubblePositionData.RemoveAt(i);
        }

    }


    // 创建一个奖励泡泡
    private void CreateOneRewardBubble(ObjectPositionData rewardBubblePositionDate, float distanceMoved = 0.0f)
    {
        // 创建对象，设置属性值
        GameObject goNewRewardBubble = new GameObject();
        goNewRewardBubble.name = "reward_bubble_" + rewardBubblePositionDate.id.ToString();
        goNewRewardBubble.transform.parent = this.transform;
        goNewRewardBubble.tag = "reward_bubble";
        goNewRewardBubble.transform.localPosition = new Vector3(rewardBubblePositionDate.randomX, rewardBubblePositionDate.randomY - distanceMoved, 0.0f);
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
        goNewRewardBubble.AddComponent<CircleCollider2D>();

        // 添加 RewardBubble 组件， 设置其属性
        RewardBubble rewardBubble = goNewRewardBubble.AddComponent<RewardBubble>();
        rewardBubble.hpRewardBubble = randomScale * ConstTemplate.rewardBubbleMaxHp;
        rewardBubble.scoreRewardBubble = randomScale * ConstTemplate.rewardBubbleMaxScore;
        rewardBubble.scaleRewardBubble = randomScale;
        rewardBubble.speedMoveToPlayerByEaten = randomScale * ConstTemplate.rewardBubbleSpeedMoveToPlayerByEatenMax;
        rewardBubble.speedMoveToPlayerByAttract = randomScale > 0.5f ? randomScale * ConstTemplate.rewardBubbleSpeedMoveToPlayerByAttractMax : ConstTemplate.rewardBubbleSpeedMoveToPlayerByAttractMax * 0.5f;
        rewardBubble.isEaten = false;
        rewardBubble.isAttract = false;

        // 添加 Animator 组件， 设置对应的动画
        Animator animatorRewardBubble = goNewRewardBubble.AddComponent<Animator>();
        animatorRewardBubble.runtimeAnimatorController = runtimeAnimatorControllerRewardBubble;

    }


}
