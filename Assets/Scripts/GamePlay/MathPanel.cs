using GamePlay.Event;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay
{
    public class MathPanel : MonoBehaviour
    {
        public ScrollRect scrollRect;
        public Button addPanelItemBtn;
        public GameObject mathPanelItemTemplate;
        private int _tolate;

        private void Start()
        {
            EventCenter.Instance.AddListenerEvent(nameof(GameEventDefine.PanelSoltOn), OnPanelSoltOn);
            addPanelItemBtn.onClick.AddListener(OnAddPanelItemBtnClick);
        }

        private void OnAddPanelItemBtnClick()
        {
            CreatePanelItem();
        }

        private void CreatePanelItems(int count)
        {
            for (int i = 0; i < count; i++)
            {
                CreatePanelItem();
            }
        }

        private GameObject CreatePanelItem()
        {
            if (mathPanelItemTemplate == null)
            {
                Debug.LogError("mathPanelItemTemplate is null");
                return null;
            }

            var content = scrollRect.content;
            var item = Instantiate(mathPanelItemTemplate, content);
            item.SetActive(true);
            item.transform.SetSiblingIndex(content.childCount - 2);
            return item;
        }
        
        

        private void OnPanelSoltOn(object obj)
        {
            GetContentItem();
        }

        private void OnDestroy()
        {
            EventCenter.Instance.RemoveListenerEvent(nameof(GameEventDefine.PanelSoltOn), OnPanelSoltOn);
        }

        private void GetContentItem()
        {
            InitTolate();
            var content = scrollRect.content;
            for (int i = 0; i < content.childCount; i++)
            {
                MathPanelItem panelItem;
                if (content.GetChild(i).TryGetComponent(out panelItem))
                {
                    panelItem.OnPanelSoltOn();
                    _tolate += panelItem.GetItemValue();
                }
            }

            if (GameLevelManager.Instance!=null)
            {
                GameLevelManager.Instance.SetCurrentScore(_tolate);
            }
        }

        public void InitTolate()
        {
            _tolate = 0;
        }

        public int GetTolate()
        {
            return _tolate;
        }
    }
}