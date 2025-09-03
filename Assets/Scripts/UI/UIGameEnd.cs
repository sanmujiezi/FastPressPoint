using System;
using DefaultNamespace.UI.Base;
using GamePlay;
using TMPro;

namespace UI
{
    public class UIGameEnd : BaseWindow
    {
        public TextMeshProUGUI countText;

        private void OnEnable()
        {
            if (GameLevelManager.Instance != null)
            {
                string countStr = GameLevelManager.Instance.GetCurrentScore().ToString();
                countText.text = "Count: " + countStr;
            }
        }
    }
}