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

    [SerializeField] bool _debug;
    private void Start()
    {
        _states = new BaseState[2];

        CommandQueue cq = CommandQueue.Init();
        cq.AddAction(() => DebugSystem.s_Instance.Log(DebugInput.Init(_debug, DebugType.Command, "Timer Start")));
        cq.AddCommand(TimerCommand.Init(5));
        cq.AddAction(() => DebugSystem.s_Instance.Log(DebugInput.Init(_debug, DebugType.Command, "Timer End")));

        _states[0] = StateWithCommandBuffer.Init(cq, true);

        cq = CommandQueue.Init();
        cq.AddAction(() => DebugSystem.s_Instance.Log(DebugInput.Init(_debug, DebugType.Command, "Frame Timer Start")));
        cq.AddCommand(FrameTimerCommand.Init(5));
        cq.AddAction(() => DebugSystem.s_Instance.Log(DebugInput.Init(_debug, DebugType.Command, "Frame Timer End")));

        _states[1] = StateWithCommandBuffer.Init(cq, false);

        _states[0].AddTransitions(Transition.Init(ConditionWithFunc.Init(() => trans), 1));
        _states[1].AddTransitions(Transition.Init(ConditionWithFunc.Init(() => !trans), 0));
        _states[1].AddTransitions(Transition.Init(ConditionWithFunc.Init(() => { if (loop) { loop = false; return true; } return false; }), 1));

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
        
        var stateIndex = _currState.CheckTransitions();
        if (stateIndex != -1) { _currState = _states[stateIndex].Clone(); _currStateIndex = stateIndex; }
    }
}
