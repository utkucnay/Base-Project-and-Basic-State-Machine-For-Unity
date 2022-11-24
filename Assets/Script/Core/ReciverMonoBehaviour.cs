using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DefaultExecutionOrder(10)]
public abstract class ReciverMonoBehaviour : MonoBehaviour
{
     public Action a_OnEnable;
     public Action a_OnDisable;

    protected virtual void OnEnable()
    {
        a_OnEnable?.Invoke();
    }
    protected virtual void OnDisable()
    {
        a_OnDisable?.Invoke();
    }

    protected virtual void OnDestroy()
    {
        a_OnDisable?.Invoke();
    }

    protected void RegisterEventFromTransform<T>(string name, UnityAction action) where T : IEvent
    {
        EventManager<T>.RegisterEventFromTransform(this.transform, action, name, this);
    }

    protected void RegisterEventFromRoot<T>(Transform root,string name, UnityAction action) where T : IEvent
    {
        EventManager<T>.RegisterEventFromRoot(root, action, name, this);
    }

    protected void RegisterEventFromAllGameObjects<T>(string name, UnityAction action) where T : IEvent
    {
        EventManager<T>.RegisterEventFromAllGameObjects(action, name, this);
    }

    protected void RegisterEventFromTransform<T, TEventType>(string name, UnityAction<TEventType> action) where T : IEvent<TEventType>
    {
        EventManager<T, TEventType>.RegisterEventFromTransform(this.transform, action, name, this);
    }

    protected void RegisterEventFromRoot<T, TEventType>(Transform root, string name, UnityAction<TEventType> action) where T : IEvent<TEventType>
    {
        EventManager<T, TEventType>.RegisterEventFromRoot(root, action, name, this);
    }

    protected void RegisterEventFromAllGameObjects<T, TEventType>(string name, UnityAction<TEventType> action) where T : IEvent<TEventType>
    {
        EventManager<T, TEventType>.RegisterEventFromAllGameObjects(action, name, this);
    }
}
