using System;
using DefaultNamespace.UI.Base;
using GamePlay.Event;
using UnityEngine.UI;

namespace UI
{
    public class UIGameStart : BaseWindow
    {
        public Button startBtn;

        private void Start()
        {
            startBtn.onClick.AddListener(OnStartBtnClick);
        }

        private void OnStartBtnClick()
        {
            EventCenter.Instance.TriggerEvent(nameof(GameEventDefine.GameStart));
        }
    }
}