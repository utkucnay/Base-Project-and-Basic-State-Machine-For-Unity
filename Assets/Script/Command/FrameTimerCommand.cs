using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class FrameTimerCommand : BaseCommand
{
    int _targetFrame;
    int _curFrame;

    public static FrameTimerCommand Init(int targetFrame) => new FrameTimerCommand { _targetFrame = targetFrame };

    internal override void Execute()
    {
        _curFrame++;
    }

    internal override bool CheckCondition()
    {
        if (_curFrame >= _targetFrame) return true;
        return false;
    }

    internal override void ResetVariable()
    {
        _curFrame= 0;
    }
}
