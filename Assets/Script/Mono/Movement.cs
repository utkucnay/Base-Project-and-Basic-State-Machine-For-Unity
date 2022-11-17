using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : OMonoBehaviour, IMove
{
    public void Move(Vector2 deltaMove)
    {
        Debug.Log(deltaMove);
    }
}
