using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicStateSystem : MonoBehaviour
{
    BaseState[] _states;
    BaseState _currState;
    int _currStateIndex;

    [SerializeField] bool trans;
    [SerializeField] bool loop;

    private void Start()
    {
        _states = new BaseState[2];

        CommandQueue cq = CommandQueue.Init();
        cq.AddAction(() => Debug.Log("Timer Start"));
        cq.AddCommand(TimerCommand.Init(5));
        cq.AddAction(() => Debug.Log("Timer End"));

        _states[0] = StateWithCommandBuffer.Init(cq, true);

        cq = CommandQueue.Init();
        cq.AddAction(() => Debug.Log("Frame Timer Start"));
        cq.AddCommand(FrameTimerCommand.Init(5));
        cq.AddAction(() => Debug.Log("Frame Timer End"));

        _states[1] = StateWithCommandBuffer.Init(cq, false);

        _states[0].AddTransitions(Transition.Init(ConditionWithFunc.Init(() => trans), _states[1]));
        _states[1].AddTransitions(Transition.Init(ConditionWithFunc.Init(() => !trans), _states[0]));
        _states[1].AddTransitions(Transition.Init(ConditionWithFunc.Init(() => { if (loop) { loop = false; return true; } return false; }), _states[1]));

        _currStateIndex = 0;
        _currState = _states[_currStateIndex].Clone();
    }

    private void Update()
    {
        if (_currState.IsFinish)
        {
            if (_currState.IsLoop) _currState = _states[_currStateIndex].Clone();
        }
        else
            _currState.Execute();
        
        var state = _currState.CheckTransitions();
        if (state != null) { _currState = state.Clone(); }
    }
}
