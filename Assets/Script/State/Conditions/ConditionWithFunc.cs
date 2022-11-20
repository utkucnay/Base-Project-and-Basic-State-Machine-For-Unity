using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionWithFunc : BaseCondition
{
    public System.Func<bool> _condition;

    public static ConditionWithFunc Init(System.Func<bool> condition) => new ConditionWithFunc { _condition = condition };

    public override bool CheckCondition() => _condition();
}
