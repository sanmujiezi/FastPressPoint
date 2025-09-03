using DefaultNamespace.UI.Base;
using UnityEngine;

namespace UI
{
    public class UIManager
    {
        private const string UIPath = "Assets/Resources/Prefabs/UI";
        private const string UICanvasName = "UICanvas";

        private static UIManager _instance;

        public static UIManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UIManager();
                }

                return _instance;
            }
        }

        public void ShowWindow<T>() where T : BaseWindow
        {
            string windowName = nameof(T);

            var windowPrefab = Resources.Load(UIPath + "/" + windowName);
            if (windowPrefab == null)
            {
                Debug.LogError("Window prefab not found: " + windowName);
                return;
            }

            var canvasTrans = GameObject.Find(UICanvasName).transform;
            if (canvasTrans == null)
            {
                Debug.LogError("Canvas not found: " + UICanvasName);
                return;
            }
            
            var window = GameObject.Instantiate(windowPrefab, canvasTrans);
            
            
        }
    }
}