using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using System.Linq;

public class CommandQueue
{
    Queue<BaseCommand> _commandQueue;

    public static CommandQueue Init() => new CommandQueue { _commandQueue= new Queue<BaseCommand>() };
    public bool IsFinish { get => _commandQueue.Count <= 0; }

    public void Execute()
    {
        var command = _commandQueue.Peek();
        if (command == null) { RemoveQueue(); return; }
        command.Execute();
        if (command.CheckCondition()) { command.ResetVariable(); RemoveQueue(); }
    }

    public void ClearQueue()
    {
        _commandQueue.Clear();
    }

    public void AddCommand(BaseCommand command)
    {
        _commandQueue.Enqueue(command);
    }

    public void AddAction(Action action)
    {
        _commandQueue.Enqueue(ActionCommand.Init(action));
    }

    public int Count()
    {
        return _commandQueue.Count;
    }

    void RemoveQueue()
    {
        _commandQueue.Dequeue();
    }

    public CommandQueue Clone()
    {
        return new CommandQueue { _commandQueue = this._commandQueue.Clone<BaseCommand>() };
    }
}