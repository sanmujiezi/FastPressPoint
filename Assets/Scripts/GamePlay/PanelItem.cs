using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GamePlay
{
    public class PanelItem : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        public TextMeshProUGUI text;
        private Vector3 _initPos;
        private Vector3 _soltPos;
        private Vector3 _offsetPos;
        private int _value;
        private List<GameObject> _canUseSolts;

        private void Start()
        {
            _initPos = transform.position;
            _canUseSolts = new List<GameObject>();
        }

        public void InitData(int value)
        {
            _value = value;
            text.text = _value.ToString();
        }

        private void SetPos(Vector3 pos)
        {
            transform.position = new Vector3(pos.x, pos.y, 0);
        }

        private GameObject GetShotDisSolt()
        {
            if (_canUseSolts.Count == 0)
            {
                return null;
            }
            else if (_canUseSolts.Count == 1)
            {
                return _canUseSolts[0];
            }

            int shotIndex = -1;
            for (int i = 0; i < _canUseSolts.Count - 1; i++)
            {
                var pre = GetDisWithSolt(_canUseSolts[i].transform);
                var next = GetDisWithSolt(_canUseSolts[i + 1].transform);
                if (pre > next)
                {
                    shotIndex = i + 1;
                }
            }

            return _canUseSolts[shotIndex];
        }

        private float GetDisWithSolt(Transform target)
        {
            return Vector3.Distance(target.position, transform.position);
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = (new Vector3(eventData.position.x, eventData.position.y, 0) - _offsetPos);
            var solt = GetShotDisSolt();
            //Debug.Log(solt.gameObject.name);
            Debug.Log(_canUseSolts.Count);
            if (solt != null)
            {
                _soltPos = solt.transform.position;
            }
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

            _canUseSolts.Clear();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(other + " OnEnter");
            if (!other.CompareTag("GamePlay"))
            {
                return;
            }

            if (_canUseSolts.Contains(other.gameObject))
            {
                return;
            }

            Debug.Log("Can use list Add" + other.gameObject.name);
            _canUseSolts.Add(other.gameObject);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log(other + " OnExit");
            if (!other.CompareTag("GamePlay"))
            {
                return;
            }

            if (!_canUseSolts.Contains(other.gameObject))
            {
                return;
            }
            
            Debug.Log("Can use list Remove" + other.gameObject.name);
            _canUseSolts.Remove(other.gameObject);
        }
    }
}