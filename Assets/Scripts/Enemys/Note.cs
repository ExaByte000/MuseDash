using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{

    public int Damage{get; private set;}
    private Rigidbody2D rb;
    private Vector2 targetOfMovment = new() { x = -12 };
    public float moveSpeed = 1.0f;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        targetOfMovment.y = rb.position.y;
    }

    protected virtual void FixedUpdate()
    {
        Move(targetOfMovment);
        if (rb.position.x <= targetOfMovment.x)
        {
            Destroy(this.gameObject);
        }
    }
    private void Move(Vector2 targetPosition)
    {
        Vector2 direction = Vector2.MoveTowards(rb.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(direction);
    }
}
