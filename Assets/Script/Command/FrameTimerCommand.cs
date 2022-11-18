using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class FrameTimerCommand : BCommand
{
    int _targetFrame;
    int _curFrame;

    public static FrameTimerCommand Init(int targetFrame) => new FrameTimerCommand { _targetFrame = targetFrame };

    public override void Execute()
    {
        _curFrame++;
    }

    public override bool CheckCondition()
    {
        if (_curFrame >= _targetFrame) return true;
        return false;
    }
}
