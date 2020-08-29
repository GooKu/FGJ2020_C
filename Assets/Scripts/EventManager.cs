using System.Collections.Generic;
using System;

public static class EventManager
{
    static Dictionary<string, Action<object[]>> _eventMap = new Dictionary<string, Action<object[]>>();

    public static void AddListen(string eventType, Action<object[]> callBack)
    {
        if (!_eventMap.ContainsKey(eventType))
        {
            _eventMap.Add(eventType, callBack);
        }
        else
        {
            _eventMap[eventType] += callBack;
        }
    }

    public static void SendEvent(string eventType, params object[] datas)
    {
        if (!_eventMap.TryGetValue(eventType, out Action<object[]> callBack))
        {
            return;
        }

        callBack(datas);
    }

    public static void RemoveListen(string eventType, Action<object[]> callBack)
    {
        if (!_eventMap.ContainsKey(eventType))
        {
            return;
        }
        else
        {
            _eventMap[eventType] -= callBack;
        }

        if (_eventMap[eventType] == null)
        {
            _eventMap.Remove(eventType);
        }
    }
}
