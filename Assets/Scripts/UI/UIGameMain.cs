using System;
using DefaultNamespace.UI.Base;
using GamePlay.BaseClass;
using GamePlay.Event;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class UIGameMain : BaseWindow
    {
        public TextMeshProUGUI timeText;
        public TextMeshProUGUI targetText;
        public Slider scoreSlider;
        private float _sliderMoveSpeed;

        private void Start()
        {
            ListenerEvent();
        }

        private void OnDestroy()
        {
            RemoveEvent();
        }
        private void ListenerEvent()
        {
            EventCenter.Instance.AddListenerEvent(nameof(GameEventDefine.GameLevelCurTime),OnGameLevelCurTime);
            EventCenter.Instance.AddListenerEvent(nameof(GameEventDefine.GameLevelInfo),OnGameLevelInfo);
        }

        private void OnGameLevelInfo(object obj)
        {
            if (obj is GameEventDefine.GameLevelInfo)
            {
                var levelInfo = (GameEventDefine.GameLevelInfo)obj;
                string timeStr = FormatTime(levelInfo.time + 1);
                SetTimeText(timeStr);
                SetSoreText(levelInfo.score.ToString());
            }
        }

        private void RemoveEvent()
        {
            EventCenter.Instance.RemoveListenerEvent(nameof(GameEventDefine.GameLevelCurTime),OnGameLevelCurTime);
            EventCenter.Instance.RemoveListenerEvent(nameof(GameEventDefine.GameLevelInfo),OnGameLevelInfo);
        }

        private void OnGameLevelCurTime(object obj)
        {
            if (obj is GameEventDefine.GameLevelCurTime)
            {
                var timeTemp = (GameEventDefine.GameLevelCurTime)obj;
                string timeStr = FormatTime(timeTemp.curTime+1);
                SetTimeText(timeStr);
            }   
        }
        private void SetTimeText(string str)
        {
            timeText.text = str;
        }

        private void SetSoreText(string str)
        {
            targetText.text = "Target: " + str;
        }

        private void SetSliderProgress(float progress)
        {
            scoreSlider.value = Mathf.Lerp(scoreSlider.value,progress,_sliderMoveSpeed * Time.deltaTime);
        }
        
        public string FormatTime(float seconds)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
            return string.Format("{0:00}:{1:00}:{2:00}", 
                (int)timeSpan.TotalHours, 
                timeSpan.Minutes, 
                timeSpan.Seconds);
        }

    }
}