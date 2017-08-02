using UnityEngine;
using UnityEditor;
using System.Collections;

public static class RewardBubbleCreatePosition {

    [MenuItem("MyTools/CreateOneRewardBubblePosition")]
	static void CreateOneRewardBubblePosition()
    {
        Debug.Log("-- silent -- 开始创建奖励泡泡");

        Sprite spriteRewardBubble = Resources.Load<Sprite>("Player/bubble_02");

        float randomX = Random.Range( -ConstTemplate.screenWith / 2, ConstTemplate.screenWith / 2);
        float randomY = Random.Range(0.0f, ConstTemplate.screenHeight * 1.5f);
        float randomYInterval = Random.Range(0.8f, 2.0f);
        randomY += randomYInterval;


        GameObject goRewardBubble = new GameObject();
        goRewardBubble.transform.localPosition = new Vector3(randomX, randomY);
        goRewardBubble.transform.parent = GameObject.Find("root/reward_bubbles").transform;
        goRewardBubble.name = "rewardBubbleRandom";

        SpriteRenderer spriteRendererRewardBubble = goRewardBubble.AddComponent<SpriteRenderer>();
        spriteRendererRewardBubble.sprite = spriteRewardBubble;
        spriteRendererRewardBubble.sortingLayerName = "other_object";


        Debug.Log("-- silent -- 结束创建奖励泡泡");
    }

    [MenuItem("MyTools/CreateMultiRewardBubblePosition")]
    static void CreateMultiRewardBubblePosition()
    {
        Debug.Log("-- silent -- 开始创建多个奖励泡泡");

        float randomY = Random.Range(0.0f, ConstTemplate.screenHeight * 1.5f);

        int rewardBubbleCount = 100;

        for (int i = 0; i < rewardBubbleCount; i ++)
        {

            Sprite spriteRewardBubble = Resources.Load<Sprite>("Player/bubble_02");

            float randomX = Random.Range(-ConstTemplate.screenWith / 2, ConstTemplate.screenWith / 2);
            float randomYInterval = Random.Range(0.8f, 2.0f);
            randomY += randomYInterval;

            float randomScalc = Random.Range(0.3f, 0.8f);

            GameObject goRewardBubble = new GameObject();
            goRewardBubble.transform.parent = GameObject.Find("root/reward_bubbles").transform;
            goRewardBubble.name = "rewardBubbleRandom" + i.ToString();
            goRewardBubble.tag = "reward_bubble";
            goRewardBubble.transform.localPosition = new Vector3(randomX, randomY);
            goRewardBubble.transform.localScale = new Vector3(randomScalc, randomScalc, randomScalc);

            SpriteRenderer spriteRendererRewardBubble = goRewardBubble.AddComponent<SpriteRenderer>();
            spriteRendererRewardBubble.sprite = spriteRewardBubble;
            spriteRendererRewardBubble.sortingLayerName = "other_object";

            MoveDownTemplate moveDownRewardBubble = goRewardBubble.AddComponent<MoveDownTemplate>();
            moveDownRewardBubble.isAnimation = true;
            moveDownRewardBubble.speedMoveDown = 3.0f;

            CircleCollider2D circleCollider2dRewardBubble = goRewardBubble.AddComponent<CircleCollider2D>();
        }

        Debug.Log("-- silent -- 结束创建多个奖励泡泡");

    }
}
