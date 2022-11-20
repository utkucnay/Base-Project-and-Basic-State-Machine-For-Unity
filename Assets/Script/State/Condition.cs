using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition
{
    public System.Func<bool> _condition;

    public static Condition Init(System.Func<bool> condition) => new Condition { _condition = condition };

    public bool CheckCondition() => _condition();
}
