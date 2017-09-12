using UnityEngine;

// 物体绕着目标物体旋转类
public class RotateAroundTemplate : MonoBehaviour
{
    public bool isAnimation = true;    // 是否播放动画
    public bool isPositive = true;     // 是否是正方向(顺时针)

    public float speedRotateAround = 30.0f;  // 旋转的速度

    public Transform targetRotateAround; // 绕着旋转的物体

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	    if (isAnimation)
	    {
            this.transform.RotateAround(targetRotateAround.position, isPositive ? Vector3.forward : Vector3.back, speedRotateAround * Time.deltaTime);
	    }
	}
}
