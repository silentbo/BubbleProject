using UnityEngine;

// 游戏管理类
public class GameManager : MonoBehaviour {

    public bool isPlaying = false; // 是否正在游戏中

    public int levelId = 1; // 第几个关卡

    public float speedBgMove = 0.0f; // 游戏中背景移动速度，动态改变的哦

    public GameObject goRewardBubbleCreate;    // 创建奖励泡泡的root
    public GameObject goGermCreate;            // 创建germ(细菌)的root
    public GameObject goRewardToolCreate;      // 创建奖励道具的root

    public MoveDownTemplate[] scriptBgMoveDownTemplates;     // 背景的移动效果，有几个背景就拖过来几个
    public PlayerLife scriptPlayerLife;                      // 玩家生命 脚本
    public Player scriptPlayer;                              // 玩家主角 脚本
    public PlayerScore scriptPlayerScore;                    // 玩家分数 脚本
    public PlayerDistance scriptPlayerDistance;              // 玩家距离 脚本
    public PlayerTime scriptPlayerTime;                      // 玩家时间 脚本
    public BtnGamePauseOrResume scriptBtnGamePauseOrResume;  // 暂停or继续按钮 脚本
    public CreateRewardBubbles scriptRewardBubbleCreate;     // 创建奖励泡泡 脚本
    public CreateGrems scriptGermCreate;                     // 创建germ(细菌) 脚本
    public CreateRewardTools scriptRewardToolsCreate;        // 创建奖励道具 脚本
    public GameResult scripteGameResult;                     // 游戏结果 脚本


	// Use this for initialization
	void Start (){

	    InitDataBeforeGameStart();
	}

    // 初始化数据 游戏开始之前
    private void InitDataBeforeGameStart()
    {
        levelId = PlayerPrefs.GetInt(ConstTemplate.keyPlayerPrefsLevelId, 1);
        ChangeSpeedBgMove(ConstTemplate.bgSpeedBeforeGameStart);
    }

    // 改变游戏中的背景的移动速度
    public void ChangeSpeedBgMove(float speedMoveChanged)
    {
        speedBgMove = speedMoveChanged;
        for (int i = 0; i < scriptBgMoveDownTemplates.Length; i++)
        {
            scriptBgMoveDownTemplates[i].isAnimation = true;
            //scriptBgMoveDownTemplates[i].speedMoveDown = speedMoveChanged;
        }
    }

    // 开始游戏
    public void PlayGameStart()
    {
        print("-- silent -- game start -- ");

        isPlaying = true;

        ChangeSpeedBgMove(ConstTemplate.bgSpeedGameStart);

        scriptPlayer.PlayGameStartPlayer();

        scriptRewardBubbleCreate.CreateRewardLevelBubble(levelId);
        scriptGermCreate.CreateGermLevel(levelId);
        scriptRewardToolsCreate.CreateRewardLevelTool(levelId);

        scriptPlayerLife.PlayGameStartPlayerLife();

        scriptBtnGamePauseOrResume.PlayGameStartBtnGamePauseOrResume();

    }

    // 游戏结束
    public void PlayGameOver()
    {
        print("-- silent -- game over -- ");

        for (int i = 0; i < scriptBgMoveDownTemplates.Length; i++)
            scriptBgMoveDownTemplates[scriptBgMoveDownTemplates.Length - i - 1].isAnimation = false;

        scriptPlayer.GameOverPlayer();
        scriptPlayerLife.GameOverPlayerLife();
        scriptPlayerDistance.GameOverPlayerDistance();
        scriptPlayerTime.GameOverPlayerTime();
        scriptPlayerScore.GameOverPlayerScore();
        scriptBtnGamePauseOrResume.GameOverBtnGamePauseOrResume();
        scripteGameResult.GameOverGameResult();

        PauseOrResumeAllMoveObejct(false);

    }

    // 游戏暂停or继续 false 暂停游戏， true 继续游戏
    public void PlayGamePauseOrResume(bool pauseOrResume)
    {
        print("-- silent -- game pause");
        PauseOrResumeAllMoveObejct(pauseOrResume);

        scriptPlayer.GamePauseOrResumePlayer(pauseOrResume);
        scriptPlayerLife.GamePauseOrResumePlayerLife(pauseOrResume);
        scriptPlayerDistance.GamePauseOrResumePlayerDistance(pauseOrResume);
        scriptPlayerTime.GamePauseOrResumePlayerTime(pauseOrResume);
        scriptPlayerScore.GamePauseOrResumePlayerScore(pauseOrResume);

    }

    // 暂停 or 继续， bg、奖励泡泡、奖励道具、germ
    private void PauseOrResumeAllMoveObejct(bool pauseOrResume)
    {
        // 背景
        for (int i = 0; i < scriptBgMoveDownTemplates.Length; i++)
            scriptBgMoveDownTemplates[scriptBgMoveDownTemplates.Length - i - 1].isAnimation = pauseOrResume;
        // 暂停奖励泡泡
        MoveDownTemplate[] rewardBubbles = goRewardBubbleCreate.GetComponentsInChildren<MoveDownTemplate>();
        for (int i = 0; i < rewardBubbles.Length; i++)
            rewardBubbles[i].isAnimation = pauseOrResume;

        // germ
        MoveDownTemplate[] germs = goGermCreate.GetComponentsInChildren<MoveDownTemplate>();
        for (int i = 0; i < germs.Length; i++)
            germs[i].isAnimation = pauseOrResume;

        // 奖励道具
        MoveDownTemplate[] rewardTools = goRewardToolCreate.GetComponentsInChildren<MoveDownTemplate>();
        for (int i = 0; i < rewardTools.Length; i++)
            rewardTools[i].isAnimation = pauseOrResume;
    }

    // 重新开始游戏
    public void PlayGameReset(){
        print("-- silent -- game reset -- ");

        DestoryAllChild(goRewardBubbleCreate);
        DestoryAllChild(goGermCreate);
        DestoryAllChild(goRewardToolCreate);

        InitDataBeforeGameStart();

        scriptBtnGamePauseOrResume.PlayerGameResetBtnGamePauseOrResume();
        scriptPlayer.PlayGameResetPlayer();
        scriptPlayerDistance.PlayGameResetPlayerDistance();
        scriptPlayerTime.PlayGameResetPlayerTime();
        scriptPlayerLife.PlayGameResetPlayerLife();
        scriptPlayerScore.PlayGameResetPlayerSocre();
        scripteGameResult.PlayGameResetGameResult();

    }

    // 清理root下的所有子物体
    public void DestoryAllChild(GameObject goRoot)
    {
        for (int i = 0; i < goRoot.transform.childCount; i ++)
        {
            GameObject.Destroy(goRoot.transform.GetChild(i).gameObject);
            //goRoot.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

}
