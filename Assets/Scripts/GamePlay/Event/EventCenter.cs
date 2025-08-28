using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Event
{
    public class EventCenter : MonoBehaviour
    {
        private static EventCenter instance;
        public static EventCenter Instance => instance;

        private Dictionary<string, Action<object>> eventDictionary;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                eventDictionary = new Dictionary<string, Action<object>>();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // 注册事件
        public void AddListenerEvent(string eventName, Action<object> listener)
        {
            if (Instance.eventDictionary.ContainsKey(eventName))
            {
                Instance.eventDictionary[eventName] += listener;
            }
            else
            {
                Instance.eventDictionary.Add(eventName, listener);
            }
        }

        // 取消注册事件
        public void RemoveListenerEvent(string eventName, Action<object> listener)
        {
            if (Instance != null && Instance.eventDictionary.ContainsKey(eventName))
            {
                Instance.eventDictionary[eventName] -= listener;
                if (Instance.eventDictionary[eventName] == null)
                {
                    Instance.eventDictionary.Remove(eventName);
                }
            }
        }

        // 触发事件
        public void TriggerEvent(string eventName, object eventParam = null)
        {
            if (Instance.eventDictionary.TryGetValue(eventName, out Action<object> thisEvent))
            {
                thisEvent?.Invoke(eventParam);
            }
        }

        // 清除所有事件
        public void ClearAllEvents()
        {
            if (Instance != null)
            {
                Instance.eventDictionary.Clear();
            }
        }

        // 当对象被销毁时清除所有事件
        private void OnDestroy()
        {
            if (instance == this)
            {
                ClearAllEvents();
            }
        }
    }
}