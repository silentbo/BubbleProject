using UnityEngine;

// 物体自动下移类
public class MoveDownTemplate : MonoBehaviour
{

    public bool isAnimation = true; // 是否运动
    public float speedMoveDown = 2.0f; // 下落速度

    private GameManager scriptGameManager; // 游戏场景中 游戏管理类 脚本

    void Start()
    {
        GameObject gameManager = GameObject.FindGameObjectWithTag("game_manager");
        if (gameManager) scriptGameManager = gameManager.GetComponent<GameManager>();
    }

    // Update() FixedUpdate() LateUpdate()
    void FixedUpdate()
	{
	    MoveDown();
	}

    private void MoveDown()
    {
        if (!isAnimation) return;

        speedMoveDown = scriptGameManager ? scriptGameManager.speedBgMove : speedMoveDown;
        this.transform.Translate(Vector3.down * speedMoveDown * Time.deltaTime);
    }

}
