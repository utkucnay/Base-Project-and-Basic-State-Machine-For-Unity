using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCommand: ICloneable
{
    internal abstract void Execute();
    internal abstract bool CheckCondition();
    internal abstract void ResetVariable();

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}

