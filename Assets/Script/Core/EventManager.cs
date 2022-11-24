using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using Unity.VisualScripting;

public static class EventManager<T> where T : IEvent
{
    public static void RegisterEventFromRoot(Transform root, UnityAction action, string name, ReciverMonoBehaviour monoBehaviour) 
    {
        var events = root.GetComponentsInChildren<T>();
        foreach (var _eventObj in events)
        {
            var _event = (UnityEvent)_eventObj.GetType().GetField(name).GetValue(_eventObj);
            monoBehaviour.a_OnEnable = () => _event.AddListener(action);
            monoBehaviour.a_OnDisable = () => _event.RemoveListener(action);
        }
    }

    public static void RegisterEventFromTransform(Transform transform, UnityAction action, string name, ReciverMonoBehaviour monoBehaviour)
    {
        var _eventObj = transform.GetComponent<T>();
        if (_eventObj == null) return;
        var _event = (UnityEvent)_eventObj.GetType().GetField(name).GetValue(_eventObj);
        monoBehaviour.a_OnEnable = () => _event.AddListener(action);
        monoBehaviour.a_OnDisable = () => _event.RemoveListener(action);
    }

    public static void RegisterEventFromAllGameObjects(UnityAction action, string name, ReciverMonoBehaviour monoBehaviour) 
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
        foreach (var _eventObj in events)
        {
            var _event = (UnityEvent)_eventObj.GetType().GetField(name).GetValue(_eventObj);
            monoBehaviour.a_OnEnable = () => _event.AddListener(action);
            monoBehaviour.a_OnDisable = () => _event.RemoveListener(action);
        }
    }
}

public static class EventManager<T, TEventType> where T : IEvent<TEventType>
{
    public static void RegisterEventFromRoot(Transform root, UnityAction<TEventType> action, string name, ReciverMonoBehaviour monoBehaviour) 
    {
        var events = root.GetComponentsInChildren<T>();
        foreach (var _eventObj in events)
        {
            var _event = (UnityEvent<TEventType>)_eventObj.GetType().GetField(name).GetValue(_eventObj);
            monoBehaviour.a_OnEnable = () => _event.AddListener(action);
            monoBehaviour.a_OnDisable = () => _event.RemoveListener(action);
        }
    }

    public static void RegisterEventFromTransform(Transform transform,UnityAction<TEventType> action, string name, ReciverMonoBehaviour monoBehaviour)
    {
        var _eventObj = transform.GetComponent<T>();
        if (_eventObj == null) return;
        var _event = (UnityEvent<TEventType>)_eventObj.GetType().GetField(name).GetValue(_eventObj);
        monoBehaviour.a_OnEnable = () => _event.AddListener(action);
        monoBehaviour.a_OnDisable = () => _event.RemoveListener(action);
    }

    public static void RegisterEventFromAllGameObjects(UnityAction<TEventType> action, string name, ReciverMonoBehaviour monoBehaviour)
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
        foreach (var _eventObj in events)
        {
            var _event = (UnityEvent<TEventType>)_eventObj.GetType().GetField(name).GetValue(_eventObj);
            monoBehaviour.a_OnEnable = () => _event.AddListener(action);
            monoBehaviour.a_OnDisable = () => _event.RemoveListener(action);
        }
    }
}