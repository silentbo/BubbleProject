using UnityEngine;

// 创建本关卡中的germ(细菌)
public class CreateGrems : MonoBehaviour {

    private RuntimeAnimatorController runtimeAnimatorControllerGerm; // 默认播放的动画，提出来是为了只读取一次
    private Sprite spriteGerm; // 默认的germ图片
    // Use this for initialization
    void Start () {
        runtimeAnimatorControllerGerm = Resources.Load<RuntimeAnimatorController>(ConstTemplate.resPathAnimatorGerm);
        spriteGerm = Resources.Load<Sprite>(ConstTemplate.resPathSpriteDefaultGerm);
    }

    // 创建关卡Germ(细菌)
    public void CreateRewardLevelBubble(int levelId)
    {
        // 读取germ(细菌)数据
        GermLevelData germLevelData = JsonParseTemplate.LoadGermLevelJsonData(levelId);

        for (int i = 0; i < germLevelData.germ_data.Length; i++)
        {
            CreateOneGerm(germLevelData.germ_data[i]);
        }
    }

    // 创建一个germ(细菌)
    private void CreateOneGerm(ObjectPositionData germPositionData)
    {
        // 创建对象，设置属性值
        GameObject goNewGerm = new GameObject();
        goNewGerm.name = "germ_" + germPositionData.id.ToString();
        goNewGerm.transform.parent = this.transform;
        goNewGerm.tag = "germ";
        goNewGerm.transform.localPosition = new Vector3(germPositionData.randomX, germPositionData.randomY, 0.0f);
        float randomScale = Random.Range(0.5f, 1.1f);
        goNewGerm.transform.localScale = new Vector3(randomScale, randomScale,randomScale);

        // 添加 SpriteRenderer 组件， 设置层级
        SpriteRenderer spriteRendererGerm = goNewGerm.AddComponent<SpriteRenderer>();
        spriteRendererGerm.sprite = spriteGerm;
        spriteRendererGerm.sortingLayerName = "other_object";

        // 添加 MoveDownTemplate 组件， 设置速度
        MoveDownTemplate moveDownGerm = goNewGerm.AddComponent<MoveDownTemplate>();
        moveDownGerm.isAnimation = true;
        moveDownGerm.speedMoveDown = ConstTemplate.germSpeedMoveDown;

        // 添加碰撞盒
        CircleCollider2D circleCollider2D = goNewGerm.AddComponent<CircleCollider2D>();
        //circleCollider2D.radius = randomScale * ConstTemplate.germRadius;


        // 添加 Animator 组件， 设置对应的动画
        Animator animatorGerm = goNewGerm.AddComponent<Animator>();
        animatorGerm.runtimeAnimatorController = runtimeAnimatorControllerGerm;
        int randomGermAnimation = Random.Range(1, 6);
        animatorGerm.PlayInFixedTime(string.Format("germ_{0:D2}", randomGermAnimation));

        // 添加 Germ 组件，设置生命
        Germ germ = goNewGerm.AddComponent<Germ>();
        germ.scaleGerm = randomScale;
        germ.hpGerm = randomScale * ConstTemplate.playerLifeMax;

        //// 添加 RotateAutoTemplate 组件，设置速度
        //RotateAutoTemplate rotateAutoTemplate = goNewGerm.AddComponent<RotateAutoTemplate>();
        //float randomSpeedRotateZ = Random.Range(10.0f, 50.0f);
        //rotateAutoTemplate.speedRotateZ = randomSpeedRotateZ;

    }



}
