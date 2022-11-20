using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public List<Transition> _transitions;

    public void AddTransitions(Transition transition)
    {
        _transitions.Add(transition);
    }

    public abstract void Execute();
    public abstract BaseState CheckTransitions();
    public abstract void OnCreate();
    public abstract void OnDestroy();
}
