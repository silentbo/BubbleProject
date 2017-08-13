using UnityEngine;

// 物体自动旋转类 (本游戏时2d游戏，所以旋转只需要改变z轴就好)
public class RotateAutoTemplate : MonoBehaviour {

    public bool isAnimation = true;    // 是否播放动画
    public bool isPositive = true;     // 是否是正方向(顺时针)

    public float speedRotateZ = 10.0f;  // 旋转z轴的速度
	
	// Update is called once per frame
	void Update () {

        if (isAnimation)
            RotateZ();

	}

    // 旋转z轴
    private void RotateZ()
    {
        this.transform.Rotate(Vector3.forward * speedRotateZ * Time.deltaTime);
    }

}
