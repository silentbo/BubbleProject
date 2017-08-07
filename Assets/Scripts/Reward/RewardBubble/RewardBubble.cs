using UnityEngine;

public class RewardBubble : MonoBehaviour
{

    public float hpRewardBubble = 1.0f; // 泡泡奖励生命值
    public float scaleRandomRewardBubble = 0.0f; // 泡泡缩放比例
    public bool isEaten = false; // 是否被吃
    public float speedMoveToPlayer = 5.0f; // 向主角移动的速度
    public Vector3 vec3Interval = Vector3.zero; // 与主角相差距离

    public GameObject player = null; // 主角

    //public bool isEatenFinish = false; // 是否被吃完了，在动画中直接调用的

    // Use this for initialization
    void Start (){

	}
	
	// Update is called once per frame
	void Update () {
        //EatenFinish();
        MoveToPlayer();
        MoveToPlayerFinish();
    }

    // 泡泡被吃动画
    public void Eaten(GameObject player)
    {
        isEaten = true;
        this.player = player;
    }

    public void MoveToPlayer()
    {
        if (!isEaten) return;

        this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speedMoveToPlayer * Time.deltaTime);
    }

    public void MoveToPlayerFinish()
    {
        if (!isEaten || !player || this.transform.position != player.transform.position) return;

        this.gameObject.SetActive(false);
    }

}
