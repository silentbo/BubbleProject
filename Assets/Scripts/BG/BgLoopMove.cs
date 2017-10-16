using UnityEngine;
using System.Collections;

// 背景移动
public class BgLoopMove : MonoBehaviour
{

    public bool isPlaying = true; // 是否正在游戏中

    // Update is called once per frame
    private void Update()
    {

        if (isPlaying)
        {
            LoopMove();
        }
    }

    // 循环移动背景
    private void LoopMove()
    {
        // *2 是图片的实际高度，当图片所有都移除屏幕外的时候在将其设置回到屏幕上面，来进行循环
        if (this.transform.localPosition.y <= -ConstTemplate.screenHeight)
        {
            // 设置图片的位置，用来循环
            this.transform.localPosition =
                new Vector3(
                    this.transform.localPosition.x,
                    this.transform.localPosition.y + ConstTemplate.screenHeight * 2,
                    this.transform.localPosition.z);

        }
    }
}
