using System.Collections;
using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json.Serialization;
using UnityEngine;

public class StateWithCommandBuffer : BaseState
{
    public CommandQueue _commandQueue;
    public CommandQueue _currCommandQueue;
    public bool _isLoop;

    public static StateWithCommandBuffer Init(CommandQueue commandQueue, bool IsLoop)
    {
        var state = new StateWithCommandBuffer { _commandQueue = commandQueue, _isLoop = IsLoop, _transitions = new List<Transition>() };
        state.CloneCommandQueue();
        return state;
    }

    public override void Execute()
    {
        if (_currCommandQueue.Execute() && _isLoop)
        {
            CloneCommandQueue();
        }
    }

    public void OnDisable()
    {
        _currCommandQueue = null;
    }

    void CloneCommandQueue()
    {
        _currCommandQueue = _commandQueue.Clone();
    }

    public override BaseState CheckTransitions()
    {
        for (int i = 0; i < _transitions.Count; i++)
        {
            var transition = _transitions[i];
            if (transition._condition.CheckCondition()) return transition._state;
        }
        return null;
    }
}
