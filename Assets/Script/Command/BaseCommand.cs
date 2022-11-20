using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCommand
{
    internal abstract void Execute();
    internal abstract bool CheckCondition();
    internal abstract void ResetVariable();
}

