using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDebug : IEventWithParam
{
    public void Log(DebugInput msg);
    public void LogWarning(DebugInput msg);
    public void LogError(DebugInput msg);
}