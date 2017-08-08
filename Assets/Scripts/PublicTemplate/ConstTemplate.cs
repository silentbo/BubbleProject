
// 游戏常量模板类
public class ConstTemplate {

    public const float playerLifeMax = 10.0f; // 玩家最大生命值
    public const float playerLifeMin = 0.0f;  // 玩家最小生命值

    public const float screenWith = 4.8f; // 屏幕的宽
    public const float screenHeight = 8.52f; // 屏幕的高

    public const float playerRadius = 0.4f; // 主角的半径

    public const float playerPlayPosY = -2.0f; // 主角开始游戏的时候的位置

    public const float playerDefaultPosY = -4.36f; // 主角默认的位置，未开始进行游戏的位置

    public const float speedPlayerGameStart = 1.0f; // 背景向下的移动速度

    public const string keyPlayerPrefsLevelId = "Key_PlayerPrefs_LevelId"; // 玩家第几关卡保存key值

    // 控制方向的enum
    public enum BtnControlDirectionType
    {
        BtnControlDirectionDefault, // 默认，没有方向
        BtnControlDirectionLeft,    // 左
        BtnControlDirectionRight,   // 右
    }

}
