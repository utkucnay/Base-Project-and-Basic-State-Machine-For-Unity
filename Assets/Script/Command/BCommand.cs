using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BCommand
{
    public abstract void Execute();
    public abstract bool CheckCondition();
}

