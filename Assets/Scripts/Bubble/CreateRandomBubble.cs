using UnityEngine;

public class CreateRandomBubble : MonoBehaviour
{

    public bool isPlaying = true;       // 是否正在游戏
    public bool isCreateBubble = true;  // 是否创建泡泡

    public float minXPosition = 0.0f;   // 最小的x轴的值  
    public float maxXPosition = 0.0f;   // 最大的x轴的值 

    public float minTime = 0.0f;        // 最小创建泡泡的时间
    public float maxTime = 0.0f;        // 最大创建泡泡的时间

    public float minScale = 0.0f;       // 最小的缩放值
    public float maxScale = 0.0f;       // 最大的缩放值

    public Sprite sprCreateBubbleTemplate; // 创建的泡泡的模板

	// Use this for initialization
	void Start ()
	{
        CreateRandomeBubble();
    }

    public void CreateRandomeBubble()
    {
        CancelInvoke("CreateRandomeBubble");
        CreateOneBubble();
        float randomTime = Random.Range(minTime, maxTime);
        Invoke("CreateRandomeBubble", randomTime);
    }

    public void CreateOneBubble()
    {
        float randomXPosition = Random.Range(minXPosition, maxXPosition);
        float randomScale = Random.Range(minScale, maxScale);

        GameObject objectRandomBubble = new GameObject();
        objectRandomBubble.transform.parent = this.transform;
        objectRandomBubble.transform.localPosition = new Vector3(randomXPosition, 0.0f, 0.0f);
        objectRandomBubble.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        objectRandomBubble.name = "random_bubble";

        // 设置图片
        SpriteRenderer spriteRenderer = objectRandomBubble.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprCreateBubbleTemplate;
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, Random.Range(ConstTemplate.randomBubbleMinAlpha, ConstTemplate.randomBubbleMaxAlpha));

        // 添加碰撞盒
        objectRandomBubble.AddComponent<CircleCollider2D>().radius -= 0.02f;

        // 添加碰撞检测
        objectRandomBubble.AddComponent<Rigidbody2D>().gravityScale = 0.0f;

        // 设置上升脚本属行
        MoveVirticalAutoDestoryTemplate moveVirtical = objectRandomBubble.AddComponent<MoveVirticalAutoDestoryTemplate>();
        moveVirtical.isPlaying = true;
        moveVirtical.speedMove = Random.Range(ConstTemplate.randomBubbleSpeedMoveMin, ConstTemplate.randomBubbleSpeedMoveMax);
        moveVirtical.minDestoryY = ConstTemplate.randomBubbleMinDestoryY;
        moveVirtical.maxDestoryY = ConstTemplate.randomBubbleMaxDestoryY;
        moveVirtical.vec3Per = new Vector3(Random.Range(ConstTemplate.randomBubbleMinMoveX, ConstTemplate.randomBubbleMaxMoveX), 1.0f, 0.0f);
    }

	
}
