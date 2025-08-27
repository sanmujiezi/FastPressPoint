using DefaultNamespace;
using GamePlay.BaseClass;
using UnityEngine;
using UnityEngine.Serialization;

namespace GamePlay
{
    public class SoltItem : MonoBehaviour,IContainer
    {
        public Transform continerTrans;
        private BasePanelItem _panelItem;
        
        public Transform GetContiner()
        {
            return continerTrans;
        }

        public void SetParentWithContiner(Transform child)
        {
            child.SetParent(continerTrans);
            _panelItem = child.GetComponent<PanelItem>();
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