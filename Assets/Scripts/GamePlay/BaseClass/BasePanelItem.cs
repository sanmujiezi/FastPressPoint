using GamePlay.Event;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GamePlay.BaseClass
{
    public class BasePanelItem : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        private const string PanelTag = "GamePlayPanel";
        private const string OprationTag = "GamePlayOpration";
        private const string OprationItemTag = "GamePlayOprationItem";
        private const string GamePlayItemTag = "GamePlayItem";
        private const string GamePlayTag = "GamePlay";

        public TextMeshProUGUI text;
        private Vector3 _initPos;
        private Vector3 _soltPos;
        private Vector3 _offsetPos;
        private string _value;
        private bool _inPanel;
        private Transform _initParent;

        private void Start()
        {
            _initPos = transform.position;
            _initParent = transform.parent;
        }

        public void InitData(string value)
        {
            _value = value;
            text.text = _value;
        }

        private void SetPos(Vector3 pos)
        {
            transform.position = new Vector3(pos.x, pos.y, 0);
        }


        private float GetDisWithSolt(Transform target)
        {
            return Vector3.Distance(target.position, transform.position);
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = (new Vector3(eventData.position.x, eventData.position.y, 0) - _offsetPos);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _offsetPos = (new Vector3(eventData.position.x, eventData.position.y, 0) - transform.position);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_soltPos != Vector3.zero)
            {
                transform.position = _soltPos;
            }
            else
            {
                transform.position = _initPos;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(other + " OnEnter");

            string tagStr = other.tag;

            if (tagStr != GamePlayTag && tagStr != OprationTag && tagStr != PanelTag)
            {
                return;
            }

            switch (tagStr)
            {
                case GamePlayTag:
                    if (gameObject.CompareTag(GamePlayItemTag))
                    {
                        Debug.Log("SoltTag is GamePlay");
                        var soltItem = other.GetComponent<SoltItem>();
                        if (!soltItem.HasItem())
                        {
                            soltItem.SetParentWithContiner(transform);
                            _soltPos = other.transform.position;
                        }
                    }

                    _inPanel = false;

                    break;
                case OprationTag:
                    if (gameObject.CompareTag(OprationItemTag))
                    {
                        Debug.Log("SoltTag is GamePlayOpration");
                        var soltItem = other.GetComponent<SoltItem>();
                        if (!soltItem.HasItem())
                        {
                            soltItem.SetParentWithContiner(transform);
                            _soltPos = other.transform.position;
                        }
                    }
                    _inPanel = false;

                    break;
                case PanelTag:
                    Debug.Log("SoltTag is GamePlayPanel");
                    _inPanel = true;
                    transform.SetParent(_initParent);
                    EventCenter.Instance.TriggerEvent(nameof(GameEventDefine.PanelSoltOn));
                    break;
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (_inPanel)
            {
                _soltPos = transform.position;
            }
        }

        public string GetValue()
        {
            return _value;
        }
    }
}