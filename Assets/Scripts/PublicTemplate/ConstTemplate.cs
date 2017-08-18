
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
        public const float playerPlayPosYQuick = -2.5f; // 主角开始动画时加速运动结束的位置
        public const float playerSpeedBeforeGameStart = 1.5f; // 玩家开始动画时向上移动的速度
        public const float playerSpeedBeforeGameStartQuick = 2.5f; // 玩家开始动画时向上移动的速度(快)

    #endregion 主角


    #region 背景
        
        public const float bgSpeedGameStart = 2.0f;        // 正常游戏时背景向下移动的速度
        public const float bgSpeedBeforeGameStart = 0.5f;  // 游戏开始之前背景向下移动的速度
        
    #endregion 背景


    #region 奖励道具

        public const float rewardToolsMaxScore = 50.0f;    // 奖励道具奖励的最大的Score
        public const float rewardToolsDurationTime = 5.0f; // 奖励道具的持续时间
        public const float rewardToolsSpeedMoveToPlayerMax = 5.0f; // 奖励道具被吃之后，向主角移动的速度
        public const float rewardToolsSpeedMoveDown = 1.8f;// 奖励泡泡向下移动的速度
        public const float rewardToolsMaxHp = 2.0f;        // 奖励道具的最大hp

    #endregion 奖励道具

    #region 奖励泡泡
        
        public const float rewardBubbleMaxHp = 2.0f;                 // 奖励泡泡的最大的HP
        public const float rewardBubbleMaxScore = 20.0f;             // 奖励泡泡的最大的Score
        public const float rewardBubbleSpeedMoveDown = 1.8f;         // 奖励泡泡向下移动的速度
        public const float rewardBubbleSpeedMoveToPlayerMax = 5.0f;  // 奖励泡泡被吃后，向主角移动的速度
        
    #endregion 奖励泡泡

    #region germ(细菌)

        public const float germMaxHp = 2.0f;                 // germ(细菌)的最大的HP
        public const float germMaxScore = 20.0f;             // germ(细菌)的最大的Score
        public const float germSpeedMoveDown = 1.8f;         // germ(细菌)向下移动的速度

    #endregion germ(细菌)

        #region PlayerPrefs key值

        public const string keyPlayerPrefsLevelId = "Key_PlayerPrefs_LevelId"; // 玩家第几关卡保存key值
        
    #endregion PlayerPrefs key值


    #region 路径

        #region 关卡路径

            public const string resRewardBubbleLevelPath = "/Resources/Data/RewardBubbleData/"; // 关卡奖励泡泡文件夹路径
            public const string resGermLevelPath = "/Resources/Data/GermData/";                 // 关卡germ(细菌)文件夹路径
            public const string resRewardToolLevelPath = "/Resources/Data/RewardToolsData/";    // 关卡奖励道具文件夹路径

            public const string resRewardBubbleLevelName = "RewardBubbleDataLevel_";            // 关卡奖励泡泡名
            public const string resGermLevelName = "GermDataLevel_";                            // 关卡germ(细菌)名
            public const string resRewardToolLevelName = "RewardToolsDataLevel_";              // 关卡奖励道具名

        #endregion 关卡路径

        #region 动画路径

            public const string resPathAnimatorBubbleMotion = "anim/animator/bubble_motion"; // 泡泡的待机动画路径
            public const string resPathAnimatorGerm = "anim/animator/grem_idle";             // germ(细菌)的待机动画路径

        #endregion 动画路径

        #region 暂停or继续按钮icon

            public const string resPathSpriteBtnPause = "UI/pause_resume/icon_pause";   // 暂停按钮
            public const string resPathSpriteBtnResume = "UI/pause_resume/icon_resume"; // 继续按钮

        #endregion 暂停按钮icon


        #region 图片路径

            public const string resPathSpriteDefaultRewardBubble = "Player/bubble_02_65";   // 奖励泡泡默认图片
            public const string resPathSpriteDefaultGerm = "Player/germ_idle_01_01";        // germ(细菌)默认图片
            public const string resPathSpriteDefaultRewardTool = "Player/bubble_02_65_yellow_dark"; // 奖励道具默认图片

        #endregion 图片路径



    #endregion 路径

    #region enum

        // 控制方向的enum
        public enum BtnControlDirectionType
        {
            BtnControlDirectionDefault = 0, // 默认，没有方向
            BtnControlDirectionLeft = 1, // 左
            BtnControlDirectionRight = 2, // 右
        }

        // 奖励道具的类型
        public enum RewardToolType
        {
            RewardToolNoBuff = 0,    // 无变化，没有buff效果
            RewardToolNoDie = 1,     // 无敌
            RewardToolAttract = 2,   // 吸引
            RewardToolLessen = 3,    // 变小
            RewardToolLargen = 4,    // 变大
            RewardToolAddLife = 5,   // 加命
            RewardToolSpeedDown = 6, // 减速
            RewardToolSpeedUp = 7,   // 加速
        }

    #endregion enum

}
