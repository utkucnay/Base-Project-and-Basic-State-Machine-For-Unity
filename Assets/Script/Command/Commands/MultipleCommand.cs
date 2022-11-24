using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using static PlasticPipe.PlasticProtocol.Messages.NegotiationCommand;

public class MultipleCommand : BaseCommand
{
    BaseCommand[] _commands;
    BaseCommand[] _currCommands;
    int _lenght;

    public static MultipleCommand Init(BaseCommand[] commands) {
        var command = new MultipleCommand { _commands = commands, _lenght = commands.Length };
        command._currCommands = new BaseCommand[commands.Length];
        Array.Copy(commands, command._currCommands, commands.Length);
        return command;
    }

    internal override void Execute()
    {
        foreach(var command in _currCommands)
        {
            command?.Execute();
        }
    }

    internal override bool CheckCondition()
    {
        int countNull = 0;
        for (int i = 0; i < _lenght; i++)
        {
            if (_currCommands[i] == null) { countNull++; continue; }
            if (_currCommands[i].CheckCondition()) _currCommands[i] = null;
        }
        if (countNull == _lenght) return true;
        return false;
    }

    internal override void ResetVariable()
    {
        Array.Copy(_commands, _currCommands, _commands.Length);
    }
}
