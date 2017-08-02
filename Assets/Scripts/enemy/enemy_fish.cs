using UnityEngine;
using System.Collections;

public class enemy_fish : MonoBehaviour {

    public float speedMove = 5.0f;
    public Vector3 directionVec3 = Vector3.left;

    public float speedMoveDown = 2.0f; // 向下的移动速度，跟背景的移动速度相同

    public bool isAnimation = true;

	// Use this for initialization
	void Start () {

        speedMove = Random.Range(2.0f,5.0f);
        float xRandom = Random.Range(-2.0f, -0.5f);
        float yRandom = Random.Range(-0.5f, 1.0f);

        directionVec3 = new Vector3(xRandom, yRandom, 0.0f);
	}
	
	// Update is called once per frame
    private void Update(){
        MoveRandomDirection();
    }

    // 随机方向移动，速度随机最好
    private void MoveRandomDirection(){

        if (!isAnimation) return;


        this.transform.Translate(directionVec3 * speedMove * Time.deltaTime);

    }
}
