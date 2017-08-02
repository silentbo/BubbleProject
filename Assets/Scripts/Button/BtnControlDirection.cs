using UnityEngine;
using System.Collections;

// 控制主角移动方向
public class BtnControlDirection : MonoBehaviour {

    public ConstTemplate.BtnControlDirectionType btnControlDirectionType = ConstTemplate.BtnControlDirectionType.BtnControlDirectionDefault; // 按钮类型

    public Player playerScript; // 泡泡 主角


    //public float speedMoveTemp = 


    void OnMouseDrag()
    {
        playerScript.MovePlayerLeftOrRightByBtn(btnControlDirectionType);
    }
}
