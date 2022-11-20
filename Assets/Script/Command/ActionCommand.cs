using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public sealed class ActionCommand : BaseCommand
{
    Action _action;

    public static ActionCommand Init(Action action) => new ActionCommand { _action = action };

    internal override void Execute()
    {
        _action();
    }

    internal override bool CheckCondition()
    {
        return true;
    }

    internal override void ResetVariable()
    {
    }
}
