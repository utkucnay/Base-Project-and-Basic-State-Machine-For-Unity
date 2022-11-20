using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Transition
{
    public static Transition Init(ConditionWithFunc condition, BaseState state) => new Transition { _condition = condition, _state= state };

    public BaseCondition _condition;
    public BaseState _state;
}
