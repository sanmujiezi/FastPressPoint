using DefaultNamespace.UI;
using GamePlay;
using GamePlay.Event;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public GameObject uiGameMain;
        public GameObject uiGamePanel;
        public GameObject uiGameStart;
        public GameObject uiGameEnd;
        public GameObject uiFinishGamePopup;
        [Header("编辑器UI")] public GameObject uiEditorGame;

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            StartGame();
            EventInit();
        }

        private void EventInit()
        {
            EventCenter.Instance.AddListenerEvent(nameof(GameEventDefine.GameStart),OnGameEnter);
            EventCenter.Instance.AddListenerEvent(nameof(GameEventDefine.LevelTimeOut),OnTimeOut);
        }

        private void OnTimeOut(object obj)
        {
            FinishGame();
        }

        private void OnGameEnter(object obj)
        {
            EnterGame();
        }

        private void StartGame()
        {
            CloseAllUI();
            uiGameStart.SetActive(true);
           
        }

        private void EnterGame()
        {
            CloseAllUI();
            uiGameMain.SetActive(true);
            uiGamePanel.SetActive(true);
            
            var levelInfo = LoadLevelInfo(0);
            if (levelInfo == null)
            {
                Debug.LogError("LevelInfo is null");
                return;
            }
            
            var levelManager = new GameObject("[Runtime]GameLevelManager");
            var levelManager_S = levelManager.AddComponent<GameLevelManager>();
            levelManager_S.InitLevelData(levelInfo.timeLimit,levelInfo.scoreLimit);
            levelManager_S.StartLevel();
            EventCenter.Instance.TriggerEvent(nameof(GameEventDefine.GameLevelInfo),new GameEventDefine.GameLevelInfo{ time = levelInfo.timeLimit ,score = levelInfo.scoreLimit});
        }

        private void FinishGame()
        {
            CloseAllUI();
            uiGameEnd.SetActive(true);
        }
        
        private LevelInfo LoadLevelInfo(int levelId)
        {
            LevelConfigOS levelConfigOS = Resources.Load<LevelConfigOS>("Config/Level/LevelConfigOS");
            if (levelConfigOS==null)
            {
                return null; 
            }

            return levelConfigOS.levelInfos[0];
        }

        private void CloseAllUI()
        {
            uiGameMain.SetActive(false);
            uiGameEnd.SetActive(false);
            uiGamePanel.SetActive(false);
            uiGameStart.SetActive(false);
            uiFinishGamePopup.SetActive(false);
            uiEditorGame.SetActive(false);
        }
        
    }
}