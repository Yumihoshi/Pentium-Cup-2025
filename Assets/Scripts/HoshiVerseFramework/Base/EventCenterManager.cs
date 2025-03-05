// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/03 19:03
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using System.Collections.Generic;

namespace HoshiVerseFramework.Base
{
    public class EventCenterManager : Singleton<EventCenterManager>
    {
        private readonly Dictionary<Type, Delegate> _eventHandlers = new();

        // 订阅事件
        public void AddListener<T>(Action<T> handler)
        {
            Type type = typeof(T);
            if (!_eventHandlers.TryAdd(type, handler))
                _eventHandlers[type] =
                    Delegate.Combine(_eventHandlers[type], handler);
        }

        // 触发事件
        public void TriggerEvent<T>(T eventData)
        {
            Type type = typeof(T);
            if (_eventHandlers.TryGetValue(type, out Delegate handler))
                (handler as Action<T>)?.Invoke(eventData);
        }

        // 取消订阅
        public void RemoveListener<T>(Action<T> handler)
        {
            Type type = typeof(T);
            if (!_eventHandlers.TryGetValue(type, out Delegate existing))
                return;
            Delegate newDelegate = Delegate.Remove(existing, handler);
            if (newDelegate != null)
                _eventHandlers[type] = newDelegate;
            else
                _eventHandlers.Remove(type);
        }
    }
}
