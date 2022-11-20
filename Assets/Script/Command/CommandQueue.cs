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

    public bool Execute()
    {
        if (_commandQueue.Count <= 0) return true;
        var command = _commandQueue.Peek();
        if (command == null) { RemoveQueue(); return false; }
        command.Execute();
        if (command.CheckCondition()) { command.ResetVariable(); RemoveQueue(); }
        return false;
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
        return new CommandQueue { _commandQueue = new Queue<BaseCommand>(this._commandQueue) };
    }
}