using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class ComputerPaddle : Paddle
{
    public Transform ball;

    private float upDown;
    private Vector2 direction;


    void Start()
    {
        
    }

    // Once the ball passes the half way point the 
    void Update()
    {
        if (Camera.main.WorldToViewportPoint(ball.position).x > 0.5f)
        {
            upDown = transform.position.y - ball.position.y;
            direction = new Vector2(0, (upDown > 0) ? -1 : 1);
        }
        else
        {
            upDown = 0;
            direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        Move(direction);
    }
}
