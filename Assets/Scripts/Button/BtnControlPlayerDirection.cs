using UnityEngine;
using System.Collections;

public class BtnControlPlayerDirection : MonoBehaviour {

    // 按钮类型
    public ConstTemplate.BtnControlDirectionType btnControlDirectionType = ConstTemplate.BtnControlDirectionType.BtnControlDirectionDefault; 

    public Player scriptPlayer;

    // 点击事件
    void OnMouseDrag()
    {
        Vector3 vec3Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (vec3Position.x < 0)
            btnControlDirectionType = ConstTemplate.BtnControlDirectionType.BtnControlDirectionLeft;
        
        if (vec3Position.x > 0)
            btnControlDirectionType = ConstTemplate.BtnControlDirectionType.BtnControlDirectionRight;

        scriptPlayer.MovePlayerLeftOrRightByBtn(btnControlDirectionType);
    }

}
