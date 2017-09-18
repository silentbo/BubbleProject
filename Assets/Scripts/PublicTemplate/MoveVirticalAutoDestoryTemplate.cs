using UnityEngine;

// 竖着移动并且自动删除该对象
public class MoveVirticalAutoDestoryTemplate : MonoBehaviour {

    public bool isPlaying = true; // 是否正在游戏中

    public float speedMove = 10.0f; // 运动速度

    public float minDestoryY = 0.0f; // 最小的自动删除的Y轴值
    public float maxDestoryY = 0.0f; // 最大的自动删除的Y轴值

    public Vector3 vec3Per = Vector3.zero; // 单位速度下的移动距离

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(isPlaying)
        {
            this.transform.Translate(speedMove * vec3Per * Time.deltaTime);
        }

        AutoDestroy();

    }

    // 自动删除对象
    private void AutoDestroy()
    {
        if (this.transform.localPosition.y > maxDestoryY || this.transform.localPosition.y < minDestoryY)
            Destroy(this.transform.gameObject);
    }

}
