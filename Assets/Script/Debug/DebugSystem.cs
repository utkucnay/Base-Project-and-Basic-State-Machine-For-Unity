using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Flags]
public enum DebugType
{
    Command = 1,
    State = 2,
    Core = 4,
    GameMechanic = 8
}

public class DebugSystem : Singleton<DebugSystem>, IDebug
{
    [SerializeField] DebugType _debugType;
    [SerializeField] bool _hideWarning;
    [SerializeField] bool _hideError;

    public override void Awake()
    {
        base.Awake();
    }

    public void Log(DebugInput msg)
    {
        if (_debugType.HasFlag(msg._debugType) && msg._debugEnabled)
        {
            Debug.Log(msg._message);
        }
    }

    public void LogError(DebugInput msg)
    {
        if (_hideError) return;
        Debug.LogError(msg._message);
    }

    public void LogWarning(DebugInput msg)
    {
        if(_hideWarning) return;
        Debug.LogWarning(msg._message);
    }
}
