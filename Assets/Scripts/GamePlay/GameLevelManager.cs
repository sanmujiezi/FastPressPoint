using System;
using GamePlay.Event;
using UnityEngine;

namespace GamePlay
{
    public class GameLevelManager : MonoBehaviour
    {
        public static GameLevelManager Instance;
        private float _limitTime;
        private float _currentTime;
        private int _targetScore;
        private int _currentScore;
        private bool _isRunning;
        private bool _isInit;
        private void Update()
        {
            if (_isRunning)
            {
                if (_currentTime > 0)
                {
                    _currentTime -= Time.deltaTime;
                    GameEventDefine.GameLevelCurTime curTime;
                    curTime.curTime = _currentTime;
                    EventCenter.Instance.TriggerEvent(nameof(GameEventDefine.GameLevelCurTime),curTime);
                }
                else
                {
                    _currentTime = 0;
                    _isRunning = false;
                    Debug.Log("超时结束");
                    EventCenter.Instance.TriggerEvent(nameof(GameEventDefine.LevelTimeOut));
                }
            }
        }

        public void InitLevelData(int levelID,float limiteTime, int targetScore)
        {
            Instance = this;
            _limitTime = limiteTime;
            _currentTime = limiteTime;
            _targetScore = targetScore;
            _currentScore = 0;
            LevelOprationCreater.Instance.CreateLevelOpration(levelID);
        }

        public void AddTime(float time)
        {
            _currentTime += time;
        }

        public void StartLevel()
        {
            _isRunning = true;
        }

        public void PuseLevel()
        {
            _isRunning = false;
        }

        public void Addscore(int score)
        {
            _currentScore += score;
        }

        public float GetLimitTime()
        {
            return _limitTime;
        }

        public float GetCurrentTime()
        {
            return _currentTime;
        }

        public int GetTargetScore()
        {
            return _targetScore;
        }

        public int GetCurrentScore()
        {
            return _currentScore;
        }

        public void SetCurrentScore(int score)
        {
            _currentScore = score;
        }
    }
}