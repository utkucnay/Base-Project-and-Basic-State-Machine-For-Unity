using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCommmandSystem : MonoBehaviour
{
    CommandQueue _commandQueue;

    private void Awake()
    {
        _commandQueue = CommandQueue.Init();
    }

    private void Start()
    {
        _commandQueue.AddCommand(null);
        _commandQueue.AddAction(() => Debug.Log("Timer begin"));
        _commandQueue.AddCommand(TimerCommand.Init(5));
        _commandQueue.AddAction(() => Debug.Log("Timer finish"));
        _commandQueue.AddAction(() => Debug.Log("Frame Timer begin"));
        _commandQueue.AddCommand(FrameTimerCommand.Init(5));
        _commandQueue.AddAction(() => Debug.Log("Frame Timer finish"));
        _commandQueue.AddCommand(MultipleCommand.Init(new BaseCommand[] { FrameTimerCommand.Init(5), TimerCommand.Init(5),
        ActionCommand.Init(() => Debug.Log("Timer begin")), ActionCommand.Init(() => Debug.Log("Frame Timer begin"))}));
        _commandQueue.AddAction(() => Debug.Log("Frame Timer and Timer finish"));

    }

    private void Update()
    {
        if(!_commandQueue.IsFinish)
            _commandQueue.Execute();
    }

    private void OnDisable()
    {
        _commandQueue.ClearQueue();
    }
}
