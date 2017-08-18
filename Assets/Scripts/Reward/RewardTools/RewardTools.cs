using UnityEngine;

public class RewardTools : MonoBehaviour{

    public bool isPlaying = true; // 是否正在游戏中
    public bool isEaten = false;  // 是否正在被吃中

    public float hpRewardTools = ConstTemplate.rewardToolsMaxHp; // 奖励道具的生命
    public float scoreRewardTools = ConstTemplate.rewardToolsMaxScore; // 奖励道具的奖励分数
    public float speedMoveToPlayer = ConstTemplate.rewardToolsSpeedMoveToPlayerMax; // 向主角移动的速度
    public float scaleRewardTools = 1.0f; // 奖励道具缩放值

    public ConstTemplate.RewardToolType rewardToolType = ConstTemplate.RewardToolType.RewardToolNoBuff; // 奖励类型

    public GameObject goPlayer = null;        // 主角

    void Update()
    {
        if (isPlaying)
        {
            MoveToPlayer();
        }
        AutoDestroy();
    }

    // 泡泡被吃动画
    public void EatenByPlayer(GameObject player)
    {
        isEaten = true;
        this.goPlayer = player;
    }

    // 被主角吃掉后向主角移动之后再销毁
    public void MoveToPlayer()
    {
        if (!isEaten) return;

        // 边移动位置，边缩小
        this.transform.position = Vector3.MoveTowards(this.transform.position, goPlayer.transform.position, speedMoveToPlayer * Time.deltaTime);
        this.transform.localScale = new Vector3(this.transform.localScale.x - 0.1f, this.transform.localScale.y - 0.1f, this.transform.localScale.z - 0.1f);

        if (this.transform.localScale.x <= 0)
            this.transform.localScale = Vector3.zero;

        MoveToPlayerFinish();
    }

    // 移动到指定的位置了
    public void MoveToPlayerFinish()
    {
        if (!isEaten || !goPlayer || this.transform.position != goPlayer.transform.position) return;
        DestroyRewardTool();
    }

    // 自动销毁
    private void AutoDestroy()
    {
        if (this.transform.position.y <= -ConstTemplate.screenHeight / 2.0f * 1.5f)
            DestroyRewardTool();
    }

    // 奖励道具被销毁了
    private void DestroyRewardTool()
    {
        Destroy(this.gameObject);
    }
}
