
// 游戏常量模板类
public class ConstTemplate
{


    #region 屏幕
    
        public const float screenWith = 4.8f; // 屏幕的宽
        public const float screenHeight = 8.52f; // 屏幕的高

    #endregion 屏幕

    #region 主角

        public const float playerLifeMax = 15.0f;       // 玩家最大生命值
        public const float playerLifeMin = 0.0f;        // 玩家最小生命值
        public const float playerLifeDieValue = 0.3f;   // 玩家生命提醒值
        public const float playerRadius = 0.4f;         // 主角的半径
        public const float playerPlayPosY = -2.0f;      // 主角开始游戏的时候的位置
        public const float playerDefaultPosY = -4.36f;  // 主角默认的位置，未开始进行游戏的位置
        public const float playerSpeedBeforeGameStart = 1.0f; // 玩家开始动画时向上移动的速度

    #endregion 主角


    #region 背景
        
        public const float bgSpeedGameStart = 2.0f;        // 正常游戏时背景向下移动的速度
        public const float bgSpeedBeforeGameStart = 0.5f;  // 游戏开始之前背景向下移动的速度
        
    #endregion 背景


    #region 奖励泡泡
        
        public const float rewardBubbleMaxHp = 2.0f;                 // 奖励泡泡的最大的HP
        public const float rewardBubbleMaxScore = 20.0f;             // 奖励泡泡的最大的Score
        public const float rewardBubbleSpeedMoveToPlayerMax = 5.0f;  // 奖励泡泡被吃后，向主角移动的速度
        
    #endregion 奖励泡泡

    #region PlayerPrefs key值

        public const string keyPlayerPrefsLevelId = "Key_PlayerPrefs_LevelId"; // 玩家第几关卡保存key值
        
    #endregion PlayerPrefs key值


    #region 路径

        #region 关卡路径

            public const string resLevelPath = "/Resources/Data/RewardBubbleData/"; // 关卡文件夹路径
            public const string resLevelName = "RewardBubbleDataLevel_";            // 关卡名

        #endregion 关卡路径

        #region 动画路径

            public const string resPathAnimatorBubbleMotion = "anim/animator/bubble_motion"; // 泡泡的待机动画路径
            public const string resPathAnimatorGerm = "anim/animator/grem_idle";             // germ(细菌)的待机动画路径

        #endregion 动画路径

        #region 暂停or继续按钮icon

            public const string resPathSpriteBtnPause = "UI/pause_resume/icon_pause";   // 暂停按钮
            public const string resPathSpriteBtnResume = "UI/pause_resume/icon_resume"; // 继续按钮

        #endregion 暂停按钮icon

        #endregion 路径

    #region enum

    // 控制方向的enum
    public enum BtnControlDirectionType
        {
            BtnControlDirectionDefault, // 默认，没有方向
            BtnControlDirectionLeft,    // 左
            BtnControlDirectionRight,   // 右
        }

    #endregion enum

}
