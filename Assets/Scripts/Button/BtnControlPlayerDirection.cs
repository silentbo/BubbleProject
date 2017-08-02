using UnityEngine;
using System.Collections;

public class BtnControlPlayerDirection : MonoBehaviour {

    public ConstTemplate.BtnControlDirectionType btnControlDirectionType = ConstTemplate.BtnControlDirectionType.BtnControlDirectionDefault; // 按钮类型

    public Player playerScript;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDrag()
    {
        Vector3 vec3Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        print("-- silent -- mousePosition = " + Input.mousePosition);
        print("-- silent -- mousePositionWorld = " + vec3Position);

        if (vec3Position.x < 0)
        {
            btnControlDirectionType = ConstTemplate.BtnControlDirectionType.BtnControlDirectionLeft;
        }
        
        if (vec3Position.x > 0)
        {
            btnControlDirectionType = ConstTemplate.BtnControlDirectionType.BtnControlDirectionRight;
        }
        playerScript.MovePlayerLeftOrRightByBtn(btnControlDirectionType);

    }

}
