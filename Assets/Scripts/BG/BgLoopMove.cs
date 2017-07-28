using UnityEngine;
using System.Collections;

public class BgLoopMove : MonoBehaviour
{

    public float moveSpreed = 2.0f; // 移动速度

    public float bgHight = 0f; // 背景高度

    public Renderer rendererBg; // 为了获取图片的实际大小

	// Use this for initialization
	void Start (){
	    this.rendererBg = this.transform.GetComponent<Renderer>(); // 获取图片的实际大小
        print(this.rendererBg.bounds.extents.x);
        print(this.rendererBg.bounds.extents.y);
	}
	
	// Update is called once per frame
	void Update () {
        // 移动屏幕
	    this.transform.Translate(Vector3.down * moveSpreed * Time.deltaTime);

        // *2 是图片的实际高度，当图片所有都移除屏幕外的时候在将其设置回到屏幕上面，来进行循环
	    if (this.transform.position.y <= -this.rendererBg.bounds.extents.y * 2) 
            // 设置图片的位置，用来循环
	        this.transform.position = new Vector3(this.transform.position.x,
	            this.transform.position.y + this.rendererBg.bounds.extents.y * 2 * 2, this.transform.position.z);
	}
}
