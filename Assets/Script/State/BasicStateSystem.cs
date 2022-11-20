using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicStateSystem : MonoBehaviour
{
    BaseState[] _states;
    BaseState _currState;

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

        _currState = _states[0];
    }

    private void Update()
    {
        _currState.Execute();
        var state = _currState.CheckTransitions();
        if (state != null) { _currState = state; }
    }
}
