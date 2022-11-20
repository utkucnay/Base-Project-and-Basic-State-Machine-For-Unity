using System.Collections;
using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json.Serialization;
using UnityEngine;

public class StateWithCommandBuffer : BaseState
{
    public CommandQueue _commandQueue;

    public bool _isLoop;

    public override bool IsFinish => _commandQueue.IsFinish;

    public override bool IsLoop => _isLoop;

    public static StateWithCommandBuffer Init(CommandQueue commandQueue, bool IsLoop)
    {
        var state = new StateWithCommandBuffer { _commandQueue = commandQueue, _isLoop = IsLoop, _transitions = new List<Transition>() };
        return state;
    }

    public override void Execute()
    {
        _commandQueue.Execute();
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

    public override BaseState Clone()
    {
        return new StateWithCommandBuffer { _commandQueue = this._commandQueue.Clone(), _transitions = new List<Transition>(this._transitions), _isLoop = _isLoop };
    }
}
