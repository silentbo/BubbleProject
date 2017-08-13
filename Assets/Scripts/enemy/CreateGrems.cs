using UnityEngine;

// 创建本关卡中的germ(细菌)
public class CreateGrems : MonoBehaviour {

    private RuntimeAnimatorController runtimeAnimatorControllerGerm; // 默认播放的动画，提出来是为了只读取一次

    // Use this for initialization
    void Start () {
        runtimeAnimatorControllerGerm = Resources.Load<RuntimeAnimatorController>(ConstTemplate.resPathAnimatorGerm);
        InvokeRepeating("CreateOneGerm", 1.0f, 2.0f);   
    }


    // 创建一个奖励泡泡
    private void CreateOneGerm()
    {
        // 创建对象，设置属性值
        GameObject goNewGerm = new GameObject();
        goNewGerm.name = "germ_";
        goNewGerm.transform.parent = this.transform;
        goNewGerm.tag = "germ";
        goNewGerm.transform.localPosition = Vector3.zero;
        float randomScale = Random.Range(0.5f, 1.1f);
        goNewGerm.transform.localScale = new Vector3(randomScale, randomScale,randomScale);

        // 添加 SpriteRenderer 组件， 设置层级
        SpriteRenderer spriteRendererGerm = goNewGerm.AddComponent<SpriteRenderer>();
        spriteRendererGerm.sprite = null;
        spriteRendererGerm.sortingLayerName = "other_object";

        // 添加 MoveDownTemplate 组件， 设置速度
        MoveDownTemplate moveDownGerm = goNewGerm.AddComponent<MoveDownTemplate>();
        moveDownGerm.isAnimation = true;
        moveDownGerm.speedMoveDown = 2.0f;

        // 添加碰撞盒
        goNewGerm.AddComponent<CircleCollider2D>();

        // 添加 Animator 组件， 设置对应的动画
        Animator animatorGerm = goNewGerm.AddComponent<Animator>();
        animatorGerm.runtimeAnimatorController = runtimeAnimatorControllerGerm;
        int randomGermAnimation = Random.Range(1, 6);
        animatorGerm.PlayInFixedTime("grem_0" + randomGermAnimation.ToString());

        //// 添加 RotateAutoTemplate 组件，设置速度
        //RotateAutoTemplate rotateAutoTemplate = goNewGerm.AddComponent<RotateAutoTemplate>();
        //float randomSpeedRotateZ = Random.Range(10.0f, 50.0f);
        //rotateAutoTemplate.speedRotateZ = randomSpeedRotateZ;

    }



}
