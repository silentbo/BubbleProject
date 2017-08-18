using UnityEngine;

public class CreateRewardTools : MonoBehaviour
{

    private Sprite spriteRewardTool; // 奖励道具的图片，就一个图片，然后奖励是随机的，不吃到不知道

	// Use this for initialization
	void Start (){

	    spriteRewardTool = Resources.Load<Sprite>(ConstTemplate.resPathSpriteDefaultRewardTool);
	}

    public void CreateRewardLevelTool(int levelId)
    {
        // 读取泡泡数据
        RewardToolsLevelData rewardToolsLevelData = JsonParseTemplate.LoadRewardToolLevelJsonData(levelId);

        for (int i = 0; i < rewardToolsLevelData.reward_tool_data.Length; i++)
        {
            CreateOneRewardTool(rewardToolsLevelData.reward_tool_data[i]);
        }
    }

    // 创建一个奖励工具
    private void CreateOneRewardTool(ObjectPositionData rewardToolPositionDate)
    {
        // 创建对象，设置属性值
        GameObject goNewRewardBubble = new GameObject();
        goNewRewardBubble.name = "reward_bubble_" + rewardToolPositionDate.id.ToString();
        goNewRewardBubble.transform.parent = this.transform;
        goNewRewardBubble.tag = "reward_tool";
        goNewRewardBubble.transform.localPosition = new Vector3(rewardToolPositionDate.randomX, rewardToolPositionDate.randomY, 0.0f);
        float randomScale = Random.Range(0.5f, 1.0f);
        goNewRewardBubble.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

        // 添加 SpriteRenderer 组件， 设置层级
        SpriteRenderer spriteRendererRewardBubble = goNewRewardBubble.AddComponent<SpriteRenderer>();
        spriteRendererRewardBubble.sprite = spriteRewardTool;
        spriteRendererRewardBubble.sortingLayerName = "other_object";

        // 添加 MoveDownTemplate 组件， 设置速度
        MoveDownTemplate moveDownRewardBubble = goNewRewardBubble.AddComponent<MoveDownTemplate>();
        moveDownRewardBubble.isAnimation = true;
        moveDownRewardBubble.speedMoveDown = ConstTemplate.rewardToolsSpeedMoveDown;

        // 添加碰撞盒
        goNewRewardBubble.AddComponent<CircleCollider2D>();

        // 添加 RewardTools 组件， 设置其属性
        RewardTools rewardTools = goNewRewardBubble.AddComponent<RewardTools>();
        rewardTools.hpRewardTools = randomScale * ConstTemplate.rewardToolsMaxHp;
        rewardTools.scoreRewardTools = randomScale * ConstTemplate.rewardToolsMaxScore;
        rewardTools.scaleRewardTools = randomScale;
        rewardTools.speedMoveToPlayer = randomScale * ConstTemplate.rewardToolsSpeedMoveToPlayerMax;
        rewardTools.isEaten = false;


    }

}
