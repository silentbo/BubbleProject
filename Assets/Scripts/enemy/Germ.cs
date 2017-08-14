using UnityEngine;
using System.Collections;

public class Germ : MonoBehaviour {

    public bool isPlaying = true; // 是否正在游戏

    public float hpGerm = 0.0f;   // 细菌的生命值，就是玩家减少的生命值
    public float scaleGerm = 1.0f;// 细菌的大小 

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        AutoDestroy();

    }


    // 自动销毁
    private void AutoDestroy()
    {
        if (this.transform.position.y <= -ConstTemplate.screenHeight / 2.0f * 1.5f)
            Destroy(this.gameObject); 
    }


}
