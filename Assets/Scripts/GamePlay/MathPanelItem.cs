using TMPro;
using UnityEngine;

namespace GamePlay
{
    public class MathPanelItem : MonoBehaviour
    {
        public SoltItem numItem1;
        public SoltItem numItem2;
        public SoltItem oprationItem;
        public TextMeshProUGUI resultText;

        private void SetResultText(string content)
        {
            resultText.text = content;
        }

        private int ComputeNum()
        {
            var num1 = numItem1.GetItemValue();
            var num2 = numItem2.GetItemValue();
            var opration = oprationItem.GetItemValue();
            
        }
        
        
        
    }
}