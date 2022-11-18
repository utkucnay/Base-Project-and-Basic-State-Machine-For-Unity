using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActionCommand : BCommand
{
    Action _action;

    public static ActionCommand Init(Action action) => new ActionCommand { _action = action };

    public override void Execute()
    {
        _action();
    }

    public override bool CheckCondition()
    {
        return true;
    }
}
