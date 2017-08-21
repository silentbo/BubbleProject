using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// 创建本关卡中的germ(细菌)
public class CreateGrems : MonoBehaviour {

    public PlayerDistance scriptPlayerDistance; // 移动距离 脚本

    private RuntimeAnimatorController runtimeAnimatorControllerGerm; // 默认播放的动画，提出来是为了只读取一次
    private Sprite spriteGerm; // 默认的germ图片

    private List<ObjectPositionData> listGermPositionData = new List<ObjectPositionData>(); // 奖励泡泡的位置信息
    private float distanceCreateGerm = 0.0f; // 上次创建奖励泡泡移动的距离


    // Use this for initialization
    void Start () {
        runtimeAnimatorControllerGerm = Resources.Load<RuntimeAnimatorController>(ConstTemplate.resPathAnimatorGerm);
        spriteGerm = Resources.Load<Sprite>(ConstTemplate.resPathSpriteDefaultGerm);
    }

    void Update(){

        CreateGermByDistance();
    }

    // 排序，通过Y轴的坐标类排序 大到小
    private int SortGermPositionY(ObjectPositionData opdL, ObjectPositionData opdR)
    {
        if (opdL.randomY < opdR.randomY)
            return 1;
        else if (opdL.randomY == opdR.randomY)
            return 0;
        else return -1;
    }

    // 创建关卡Germ(细菌)
    public void CreateGermLevel(int levelId)
    {
        // 读取germ(细菌)数据
        GermLevelData germLevelData = JsonParseTemplate.LoadGermLevelJsonData(levelId);

        listGermPositionData = germLevelData.germ_data.ToList();
        listGermPositionData.Sort(SortGermPositionY);
        distanceCreateGerm = -ConstTemplate.screenHeight / 2;
    }

    // 创建奖励道具，通过距离来创建奖励道具，优化，避免一帧实例化太多，造成卡顿
    private void CreateGermByDistance()
    {
        // 没有数据、没有到下一屏幕，不创建对象
        if (listGermPositionData.Count <= 0) return;
        if (distanceCreateGerm + ConstTemplate.screenHeight / 2 > scriptPlayerDistance.playerDistance) return;

        distanceCreateGerm = scriptPlayerDistance.playerDistance;
        float maxPosYCreateGerm = scriptPlayerDistance.playerDistance - ConstTemplate.screenHeight / 2 + ConstTemplate.screenHeight * 1.5f;

        // 从后向前遍历，动态删除的哦
        for (int i = listGermPositionData.Count - 1; i >= 0; i--)
        {
            // 之后的下次在创建
            if (listGermPositionData[i].randomY > maxPosYCreateGerm)
                break;
            // 创建germ
            CreateOneGerm(listGermPositionData[i], distanceCreateGerm);
            // 删除已经生成过的germ
            listGermPositionData.RemoveAt(i);
        }

    }

    // 创建一个germ(细菌)
    private void CreateOneGerm(ObjectPositionData germPositionData, float distanceMoved = 0.0f)
    {
        // 创建对象，设置属性值
        GameObject goNewGerm = new GameObject();
        goNewGerm.name = "germ_" + germPositionData.id.ToString();
        goNewGerm.transform.parent = this.transform;
        goNewGerm.tag = "germ";
        goNewGerm.transform.localPosition = new Vector3(germPositionData.randomX, germPositionData.randomY - distanceMoved, 0.0f);
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
        goNewGerm.AddComponent<CircleCollider2D>();


        // 添加 Animator 组件， 设置对应的动画
        Animator animatorGerm = goNewGerm.AddComponent<Animator>();
        animatorGerm.runtimeAnimatorController = runtimeAnimatorControllerGerm;
        int randomGermAnimation = Random.Range(1, 5);
        string strGerm = string.Format("germ_{0:D2}", randomGermAnimation);
        //print("-- silent -- germ animator " + strGerm);
        animatorGerm.PlayInFixedTime(strGerm);

        // 添加 Germ 组件，设置生命
        Germ germ = goNewGerm.AddComponent<Germ>();
        germ.scaleGerm = randomScale;
        germ.hpGerm = randomScale * ConstTemplate.germMaxHp;
        germ.animator = animatorGerm;
        germ.scoreGerm = randomScale * ConstTemplate.germMaxScore;

        //// 添加 RotateAutoTemplate 组件，设置速度
        //RotateAutoTemplate rotateAutoTemplate = goNewGerm.AddComponent<RotateAutoTemplate>();
        //float randomSpeedRotateZ = Random.Range(10.0f, 50.0f);
        //rotateAutoTemplate.speedRotateZ = randomSpeedRotateZ;

    }



}
