using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : ReciverMonoBehaviour, IMove
{
    [SerializeField] bool _isDebug;
    public void Move(Vector2 deltaMove)
    {
        DebugSystem.s_Instance.Log(DebugInput.Init(_isDebug,DebugType.GameMechanic, deltaMove.ToString()));
    }
}
