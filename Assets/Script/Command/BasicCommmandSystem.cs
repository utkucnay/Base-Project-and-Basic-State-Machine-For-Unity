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
    }

    private void Update()
    {
        _commandQueue.Execute();
    }

    private void OnDisable()
    {
        _commandQueue.ClearQueue();
    }
}
