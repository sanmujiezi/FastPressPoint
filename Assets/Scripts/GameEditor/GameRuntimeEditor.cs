using System;
using GamePlay;
using GamePlay.BaseClass;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameEditor
{
    public class GameRuntimeEditor : MonoBehaviour
    {
        public TMP_InputField inputField;
        public Button createBtn;
        public GameObject numSolt;
        public GameObject oprationSolt;
        public Transform panelParent;

        private void Start()
        {
            createBtn.onClick.AddListener(OnClickCreate);
        }

        private string GetInputText()
        {
            return inputField.text;
        }

        private void OnClickCreate()
        {
            var inputText = GetInputText();
            Debug.Log($"OnClick {inputText}");
            if (string.IsNullOrEmpty(inputText))
            {
                return;
            }

            GameObject obj;
            switch (inputText)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    obj = Instantiate(oprationSolt, panelParent);
                    break;
                default:
                    obj = Instantiate(numSolt, panelParent);
                    break;
            }

            obj.GetComponent<BasePanelItem>().InitData(inputText);
        }
    }
}