using System;
using System.Collections;
using System.Collections.Generic;

public static class EventBus
{
    public delegate void OnEvent<T>(T param);

    private static Dictionary<string, Dictionary<Type, Delegate>> dictByName = new Dictionary<string, Dictionary<Type, Delegate>>();

    public static void Subscribe<T>(string eventName, OnEvent<T> subscriber)
    {
        if(!dictByName.ContainsKey(eventName))
            dictByName.Add(eventName, new Dictionary<Type, Delegate>());
        
        var eventByType = dictByName[eventName];

        var type = typeof(T);
        if (!eventByType.ContainsKey(type))
            eventByType.Add(type, subscriber);
        else
            eventByType[type] = Delegate.Combine(eventByType[type], subscriber);
    }

    public static void Unsubscribe<T>(string eventName, OnEvent<T> subscriber)
    {
        if (!dictByName.ContainsKey(eventName))
            dictByName.Add(eventName, new Dictionary<Type, Delegate>());

        var eventByType = dictByName[eventName];

        var type = typeof(T);
        if (!eventByType.ContainsKey(type))
            return;
        else
            eventByType[type] = Delegate.RemoveAll(eventByType[type], subscriber);
    }

    public static void Publish<T>(string eventName, T param)
    {
        if (!dictByName.ContainsKey(eventName))
            return;

        var type = typeof(T);
        var eventByType = dictByName[eventName];
        if (!eventByType.ContainsKey(type))
            return;

        eventByType[type]?.DynamicInvoke(new object[] {param});
    }
}
