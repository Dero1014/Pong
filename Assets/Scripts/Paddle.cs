using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float Speed = 150.0f;
    protected Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected void Move(Vector2 direction)
    {
        if (direction.magnitude != 0)
        {
            rb.AddForce(direction * Speed * Time.deltaTime);
        }
    }

}
