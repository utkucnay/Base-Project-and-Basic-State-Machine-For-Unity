using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputHandler : OMonoBehaviour
{
    Vector2 _oldPos;

    UnityEvent<Vector2> e_move;

    protected override void Awake()
    {
        base.Awake();
        e_move = new UnityEvent<Vector2>();
    }

    private void Start()
    {
        Observer.RegisterEventFromTransform<IMove, Vector2>(transform, "Move", e_move);
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                _oldPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                var deltaMove = touch.position - _oldPos;
                _oldPos = touch.position;
                e_move.Invoke(deltaMove);
            }
        }
    }
}
