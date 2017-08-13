using UnityEngine;

// 物体自动下移类
public class MoveDownTemplate : MonoBehaviour
{

    public bool isAnimation = true; // 是否运动
    public float speedMoveDown = 2.0f; // 下落速度
	
	void Update ()
	{
	    MoveDown();
	}

    private void MoveDown()
    {
        if (!isAnimation) return;

        this.transform.Translate(Vector3.down * speedMoveDown * Time.deltaTime);
    }

}
