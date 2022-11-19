using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCommand : BaseCommand
{
    public float _time;
    float _currtime;

    public static TimerCommand Init(float time) => new TimerCommand { _time = time };

    internal override void Execute()
    {
        _currtime += Time.deltaTime;
    }

    internal override bool CheckCondition()
    {
        if(_currtime >= _time) return true;
        return false;
    }
}
