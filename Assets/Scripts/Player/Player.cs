using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Animator animatorPlayer; // 泡泡动画
    public bool isEatFinished; // 是否吃完了

	// Use this for initialization
	void Start () {
        InvokeRepeating("Eat", 2.0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
        if (!isEatFinished)
            animatorPlayer.SetBool("eat", false);
	}


    private void Eat()
    {
        animatorPlayer.SetBool("eat", true);
    }

}
