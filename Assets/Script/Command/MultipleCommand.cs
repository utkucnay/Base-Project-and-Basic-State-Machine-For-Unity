using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class MultipleCommand : BaseCommand
{
    BaseCommand[] _commands;
    int _lenght;

    public static MultipleCommand Init(BaseCommand[] commands) => new MultipleCommand { _commands = commands, _lenght = commands.Length}; 

    internal override void Execute()
    {
        foreach(var command in _commands)
        {
            command?.Execute();
        }
    }

    internal override bool CheckCondition()
    {
        int countNull = 0;
        for (int i = 0; i < _lenght; i++)
        {
            if (_commands[i] == null) { countNull++; continue; }
            if (_commands[i].CheckCondition()) _commands[i] = null;
        }
        if (countNull == _lenght) return true;
        return false;
    }
}
