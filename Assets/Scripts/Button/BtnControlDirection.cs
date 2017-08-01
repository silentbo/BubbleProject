using UnityEngine;
using System.Collections;

// 控制主角移动方向
public class BtnControlDirection : MonoBehaviour {

    // 控制方向的enum
    public enum BtnControlDirectionType
    {
        BtnControlDirectionDefault, // 默认，没有方向
        BtnControlDirectionLeft,    // 左
        BtnControlDirectionRight,   // 右
    }

    public BtnControlDirectionType btnControlDirectionType = BtnControlDirectionType.BtnControlDirectionDefault; // 按钮类型

    public GameObject player; // 泡泡 主角

    public float playerMoveSpeed = 5.0f; // 移动速度

    //public float speedMoveTemp = 

    public Vector3 moveDirection = Vector3.zero; // 主角移动的方向

    void OnMouseDrag()
    {
        //print("-- silent -- OnMouseDrag ......");

        switch (btnControlDirectionType)
        {
            case BtnControlDirectionType.BtnControlDirectionLeft:
                moveDirection = Vector3.left;
                break;
            case BtnControlDirectionType.BtnControlDirectionRight:
                moveDirection = Vector3.right;
                break;
            case BtnControlDirectionType.BtnControlDirectionDefault:
                moveDirection = Vector3.zero;
                break;
        }

        player.transform.Translate( moveDirection * playerMoveSpeed * Time.deltaTime);
    }
}
