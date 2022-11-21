using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Transition
{
    public static Transition Init(ConditionWithFunc condition, int stateIndex) =>
        new Transition { _condition = condition, _stateIndex = stateIndex };

    public BaseCondition _condition;
    public int _stateIndex;
}
