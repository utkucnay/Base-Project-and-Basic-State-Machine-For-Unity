using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public struct CommandQueue
{
    Queue<BCommand> _commandQueue;

    public static CommandQueue Init() => new CommandQueue { _commandQueue= new Queue<BCommand>() }; 

    public void Execute()
    {
        BCommand command;
        _commandQueue.TryPeek(out command);
        if (command == null) 
        {
            _commandQueue.TryDequeue(out command);
            return; 
        }
        command.Execute();
        if (command.CheckCondition()) RemoveQueue();
    }

    public void ClearQueue()
    {
        _commandQueue.Clear();
    }

    public void AddCommand(BCommand command)
    {
        _commandQueue.Enqueue(command);
    }

    public void AddAction(Action action)
    {
        _commandQueue.Enqueue(ActionCommand.Init(action));
    }

    void RemoveQueue()
    {
        _commandQueue.Dequeue();
    }
}