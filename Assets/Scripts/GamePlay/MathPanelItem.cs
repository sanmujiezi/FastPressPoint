using System;
using GamePlay.Event;
using TMPro;
using UnityEngine;
using Untility;

namespace GamePlay
{
    public class MathPanelItem : MonoBehaviour
    {
        public SoltItem numItem1;
        public SoltItem numItem2;
        public SoltItem oprationItem;
        public TextMeshProUGUI resultText;
        private int _value;

        private void Start()
        {
            UpdateResultText();
        }

        public int GetItemValue()
        {
            return _value;
        }

        public void OnPanelSoltOn()
        {
            numItem1.CheckItem();
            numItem2.CheckItem();
            oprationItem.CheckItem();
            UpdateResultText();
        }

        private void UpdateResultText()
        {
            var result = ComputeNum();
            if (result == -1)
            {
                SetResultText("0");
                return;
            }

            SetResultText(result.ToString());
        }

        private void SetResultText(string content)
        {
            try
            {
                _value = int.Parse(content);
            }
            catch (Exception e)
            {
                Debug.LogError("类型转换错误" + e);
                throw;
            }

            resultText.text = content;
        }

        private int ComputeNum()
        {
            var num1S = numItem1.GetItemValue();
            var num2S = numItem2.GetItemValue();
            var oprationS = oprationItem.GetItemValue();
            if (oprationS == null)
            {
                oprationS = "+";
            }

            if (num1S == null)
            {
                num1S = "0";
            }

            if (num2S == null)
            {
                num2S = "0";
            }

            int num1Int = int.Parse(num1S);
            int num2Int = int.Parse(num2S);
            return PanelMath.Instance.Compute(num1Int, num2Int, oprationS);
        }
    }
}