using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OMonoBehaviour : MonoBehaviour
{
    [HideInInspector] public UnityEvent e_OnEnable;
    [HideInInspector] public UnityEvent e_OnDisable;

    protected virtual void Awake()
    {
        e_OnEnable= new();
        e_OnDisable= new();
    }

    protected virtual void OnEnable()
    {
        e_OnEnable.Invoke();
    }
    protected virtual void OnDisable()
    {
        e_OnDisable.Invoke();
    }
}
