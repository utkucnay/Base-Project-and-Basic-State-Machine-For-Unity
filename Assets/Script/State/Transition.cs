using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Transition
{
    public static Transition Init(Condition condition, BaseState state) => new Transition { _condition = condition, _state= state };

    public Condition _condition;
    public BaseState _state;
}
