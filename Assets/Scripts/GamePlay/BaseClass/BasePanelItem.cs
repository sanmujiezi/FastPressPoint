using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GamePlay.BaseClass
{
    public class BasePanelItem : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        private const string PanelTag = "GamePlayPanel";
        private const string OprationTag = "GamePlayOpration";
        private const string GamePlayTag = "GamePlay";

        public TextMeshProUGUI text;
        private Vector3 _initPos;
        private Vector3 _soltPos;
        private Vector3 _offsetPos;
        private string _value;
        private bool _inPanel;

        private void Start()
        {
            _initPos = transform.position;
        }

        public void InitData(int value)
        {
            _value = value.ToString();
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
                    Debug.Log("SoltTag is GamePlay");
                    if (gameObject.CompareTag(GamePlayTag))
                    {
                        _soltPos = other.transform.position;
                        _inPanel = false;
                    }

                    break;
                case OprationTag:
                    Debug.Log("SoltTag is GamePlayOpration");
                    if (gameObject.CompareTag(OprationTag))
                    {
                        _soltPos = other.transform.position;
                        _inPanel = false;
                    }
                    break;
                case PanelTag:
                    Debug.Log("SoltTag is GamePlayPanel");

                    _inPanel = true;

                    break;
            }

            Debug.Log("Can use list Add" + other.gameObject.name);
        }
        
        private void OnTriggerStay2D(Collider2D other)
        {
            if (_inPanel)
            {
                _soltPos = transform.position;
                Debug.Log("OnPanel");
            }
        }

        public string GetValue()
        {
            return _value;
        }
    }
}