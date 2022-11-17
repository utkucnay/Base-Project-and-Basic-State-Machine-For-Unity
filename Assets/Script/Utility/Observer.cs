using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using Unity.VisualScripting;

public static class Observer
{
    public static void RegisterEventFromRoot<T>(Transform root, string methodName, UnityEvent uEvent) where T : IEvent
    {
        var events = root.GetComponentsInChildren<T>();
        foreach (var _event in events)
        {
            var action = (UnityAction)UnityAction.CreateDelegate(typeof(UnityAction), _event, methodName);
            var checkEvent = _event as OMonoBehaviour;
            if (checkEvent == null) continue;
            uEvent.AddListener(action);
            checkEvent.e_OnEnable.AddListener(() => uEvent.AddListener(action));
            checkEvent.e_OnDisable.AddListener(() => uEvent.RemoveListener(action));
        }
    }

    public static void RegisterEventFromTransform<T>(Transform transform, string methodName, UnityEvent uEvent) where T : IEvent
    {
        var _event = transform.GetComponent<T>();
        if (_event == null) return;
        var checkEvent = _event as OMonoBehaviour;
        if (checkEvent == null) return;
        var action = (UnityAction)UnityAction.CreateDelegate(typeof(UnityAction), _event, methodName);
        uEvent.AddListener(action);
        checkEvent.e_OnEnable.AddListener(() => uEvent.AddListener(action));
        checkEvent.e_OnDisable.AddListener(() => uEvent.RemoveListener(action));
    }

    public static void RegisterEventFromRoot<T, TEventType>(Transform root, string methodName, UnityEvent<TEventType> uEvent) where T : IEventWithParam
    {
        var events = root.GetComponentsInChildren<T>();
        foreach (var _event in events)
        {
            var action = (UnityAction<TEventType>)UnityAction.CreateDelegate(typeof(UnityAction<TEventType>), _event, methodName);
            var checkEvent = _event as OMonoBehaviour;
            if (checkEvent == null) continue;
            uEvent.AddListener(action);
            checkEvent.e_OnEnable.AddListener(() => uEvent.AddListener(action));
            checkEvent.e_OnDisable.AddListener(() => uEvent.RemoveListener(action));
        }
    }

    public static void RegisterEventFromTransform<T, TEventType>(Transform transform, string methodName, UnityEvent<TEventType> uEvent) where T : IEventWithParam
    {
        var _event = transform.GetComponent<T>();
        if (_event == null) return;
        var action = (UnityAction<TEventType>)UnityAction.CreateDelegate(typeof(UnityAction<TEventType>), _event, methodName);
        var checkEvent = _event as OMonoBehaviour;
        if (checkEvent == null) return;
        uEvent.AddListener(action);
        checkEvent.e_OnEnable.AddListener(() => uEvent.AddListener(action));
        checkEvent.e_OnDisable.AddListener(() => uEvent.RemoveListener(action));
    }

    public static void RegisterEventFromAllGameObjects<T>(string methodName, UnityEvent uEvent) where T : IEvent
    {
        var objects = (GameObject[])GameObject.FindObjectsOfType(typeof(GameObject));
        objects = objects.Distinct().ToArray();
        List<T> events = new List<T>();
        foreach (var _object in objects)
        {
            var _T = _object.GetComponents<T>();
            if (_T.Length <= 0) continue;
            events.AddRange(_T);
        }
        foreach (var _event in events)
        {
            var action = (UnityAction)UnityAction.CreateDelegate(typeof(UnityAction), _event, methodName);
            var checkEvent = _event as OMonoBehaviour;
            if (checkEvent == null) continue;
            uEvent.AddListener(action);
            checkEvent.e_OnEnable.AddListener(() => uEvent.AddListener(action));
            checkEvent.e_OnDisable.AddListener(() => uEvent.RemoveListener(action));
        }
    }
    public static void RegisterEventFromAllGameObjects<T, TEventType>(string methodName, UnityEvent<TEventType> uEvent) where T : IEventWithParam
    {
        var objects = (GameObject[])GameObject.FindObjectsOfType(typeof(GameObject));
        objects = objects.Distinct().ToArray();
        List<T> events = new List<T>();
        foreach (var _object in objects)
        {
            var _T = _object.GetComponents<T>();
            if (_T.Length <= 0) continue;
            events.AddRange(_T);
        }
        foreach (var _event in events)
        {
            var action = (UnityAction<TEventType>)UnityAction.CreateDelegate(typeof(UnityAction<TEventType>), _event, methodName);
            var checkEvent = _event as OMonoBehaviour;
            if (checkEvent == null) continue;
            uEvent.AddListener(action);
            checkEvent.e_OnEnable.AddListener(() => uEvent.AddListener(action));
            checkEvent.e_OnDisable.AddListener(() => uEvent.RemoveListener(action));
        }
    }
}