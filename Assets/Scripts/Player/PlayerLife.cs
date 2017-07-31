using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{

    public Image playerLifeChange; // 玩家生命改变值
    public Image playerLifeChangeMark; // 玩家生命改变mark

    public float vec2PlayerLifeChangeHeight = 0.0f; // 生命改变图片的Rect Transform 坐标
    public Vector3 vec3PlayerLifeChangeMark = Vector3.zero; // 生命改变图片Mark的Rect Transform 坐标

    void Start()
    {
        vec2PlayerLifeChangeHeight = playerLifeChange.rectTransform.rect.height;
        vec3PlayerLifeChangeMark = playerLifeChangeMark.rectTransform.localPosition;
    }

    // 设置当前玩家生命值
    public void SetPlayerLife(float ratioLife)
    {
        playerLifeChange.fillAmount = ratioLife;
        SetPlayerLifeChangeMarkPosY(ratioLife);
    }

    // 设置当前mark的Y轴的位置
    private void SetPlayerLifeChangeMarkPosY(float ratioLife)
    {
        float yPosMark = vec3PlayerLifeChangeMark.y - (1 - ratioLife)*vec2PlayerLifeChangeHeight;
        playerLifeChangeMark.rectTransform.localPosition = new Vector3(vec3PlayerLifeChangeMark.x, yPosMark, vec3PlayerLifeChangeMark.z);
    }

}
