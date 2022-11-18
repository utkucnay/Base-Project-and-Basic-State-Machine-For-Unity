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
        a_OnEnable();
    }
    protected virtual void OnDisable()
    {
        a_OnDisable();
    }
}
