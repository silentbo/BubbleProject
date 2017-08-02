﻿
// 游戏常量模板类
public class ConstTemplate {

    public const float playerLifeMax = 10.0f; // 玩家最大生命值
    public const float playerLifeMin = 0.0f;  // 玩家最小生命值

    public const float screenWith = 4.8f; // 屏幕的宽
    public const float screenHeight = 4.8f; // 屏幕的高

    // 控制方向的enum
    public enum BtnControlDirectionType
    {
        BtnControlDirectionDefault, // 默认，没有方向
        BtnControlDirectionLeft,    // 左
        BtnControlDirectionRight,   // 右
    }

}