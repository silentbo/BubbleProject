using UnityEngine;

public class MoveDownTemplate : MonoBehaviour
{

    public float speedMoveDown = 2.0f; // 下落速度
    public bool isAnimation = true; // 是否运动
	
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
