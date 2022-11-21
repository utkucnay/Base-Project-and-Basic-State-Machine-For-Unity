using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DebugInput
{
    public static DebugInput Init(bool enabled, DebugType debugType, string msg) => 
        new DebugInput { _debugEnabled = enabled, _debugType = debugType, _message = msg};

    public DebugType _debugType;
    public string _message;
    public bool _debugEnabled;
}
