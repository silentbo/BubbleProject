using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Animator animatorPlayer; // 泡泡动画
    public bool isEatFinished; // 是否吃完了
    public GameManager gameManager;

    public float speedMoveByBtn = 5.0f; // 按钮控制其左右移动的速度
    public Vector3 moveDirection = Vector3.zero; // 主角移动的方向

    public bool isAnimation = true; // 是否播放动画

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

    // 2d 碰撞触发函数
    void OnTriggerEnter2D(Collider2D other){
        
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

        //// 获取奖励泡泡增加的生命值
        RewardBubble rewardBubble = other2D.GetComponent<RewardBubble>();
        if (!rewardBubble) return;
        rewardBubble.Eaten(this.gameObject);
        gameManager.IncreasePlayerLife(rewardBubble.hpRewardBubble);

        //// 删除奖励泡泡
        //Destroy(other2D.gameObject);
        //other2D.gameObject.SetActive(false);
    }

    // 吃掉其他泡泡动画
    private void EatRewardBubble()
    {
        animatorPlayer.PlayInFixedTime("player_eat");
    }


    // 左右移动
    public void MovePlayerLeftOrRightByBtn(ConstTemplate.BtnControlDirectionType btnDirectionType)
    {
        if (!isAnimation) return;

        switch (btnDirectionType)
        {
            case ConstTemplate.BtnControlDirectionType.BtnControlDirectionDefault:
                moveDirection = Vector3.zero;
                break;

            case ConstTemplate.BtnControlDirectionType.BtnControlDirectionLeft:
                moveDirection = Vector3.left;
                break;

            case ConstTemplate.BtnControlDirectionType.BtnControlDirectionRight:
                moveDirection = Vector3.right;
                break;
        }
        Vector3 vec3MoveDirection = moveDirection * speedMoveByBtn * Time.deltaTime;

        if (LimitRangeOfPlayerMove(vec3MoveDirection))
            this.transform.Translate(vec3MoveDirection);
    }

    // 限制主角的移动范围
    private bool LimitRangeOfPlayerMove(Vector3 vec3AddValue)
    {
        Vector3 vec3PlayerEndPos = this.transform.position + vec3AddValue;
        float vec3PlayerLimitX = ConstTemplate.screenWith / 2 - ConstTemplate.playerRadius * 1.2f;
        if (vec3PlayerEndPos.x >= vec3PlayerLimitX)
        {
            this.transform.position = new Vector3(vec3PlayerLimitX, this.transform.position.y,this.transform.position.z);
            return false;
        }
        else if (vec3PlayerEndPos.x <= -vec3PlayerLimitX - ConstTemplate.playerRadius)
        {
            this.transform.position = new Vector3(vec3PlayerLimitX, this.transform.position.y, this.transform.position.z);
            return false;
        }
        return true;
    }

}
