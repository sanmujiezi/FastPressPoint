using System;
using DefaultNamespace;
using GamePlay.BaseClass;
using GamePlay.Event;
using UnityEngine;


namespace GamePlay
{
    public class SoltItem : MonoBehaviour,IContainer
    {
        public Transform continerTrans;
        private BasePanelItem _panelItem;

        public void CheckItem()
        {
            if (!HasItem())
            {
                _panelItem = null;
            }
        }

        public Transform GetContiner()
        {
            return continerTrans;
        }

        public void SetParentWithContiner(Transform child)
        {
            child.SetParent(continerTrans);
            _panelItem = child.GetComponent<PanelItem>();
            EventCenter.Instance.TriggerEvent(nameof(GameEventDefine.PanelSoltOn));
        }

        public bool HasItem()
        {
            return continerTrans.childCount > 0;
        }

        public string GetItemValue()
        {
            if (_panelItem==null)
            {
                return null;
            }
            return _panelItem.GetValue();
        }
    }
}