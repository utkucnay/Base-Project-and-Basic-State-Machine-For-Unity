using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : ReciverMonoBehaviour
{
    [SerializeField] bool _isDebug;

    private void Awake()
    {
        RegisterEventFromTransform<IMove ,Vector2>("e_move", Move);
    }
    public void Move(Vector2 deltaMove)
    {
        DebugSystem.s_Instance.Log(DebugInput.Init(_isDebug,DebugType.GameMechanic, deltaMove.ToString()));
    }
}
