using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public int Hp { get; private set; }

    private Vector2 targetPositionUp = new() { x = -7, y = 2 }; 
    private Vector2 targetPositionDown = new() { x = -7, y = -2 }; 

    public Vector2 TargetPositionUp { get { return targetPositionUp; }}
    public Vector2 TargetPositionDown { get { return targetPositionDown; }}
    public float moveSpeed = 35f;

    private Rigidbody2D rb;

    private bool isMovingUp = false; 
    private bool isMovingDown = false; 
    public float fallSpeed = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isMovingUp = true;
            isMovingDown = false;
            rb.gravityScale = 0; 
            
        }
        else if (Input.GetKeyDown(KeyCode.J) || isMovingDown && rb.position.y > TargetPositionDown.y)
        {
            isMovingDown = true;
            isMovingUp = false;
            rb.gravityScale = 0;
            
        }
    }

    private void FixedUpdate()
    {
        if (isMovingUp)
        {
            Move(TargetPositionUp);
            if (rb.position.y >= TargetPositionUp.y)
            {
                StopMovement();
            }
        }
        else if (isMovingDown)
        {
            Move(TargetPositionDown);
            if (isMovingDown && Vector2.Distance(rb.position, TargetPositionDown) < 0.1f)
            {
                StopMovement();
            }
        }
    }

    /// <summary>
    /// Перемещение объекта к точке передавемой в параметре
    /// </summary>
    /// <param name="targetPosition">Точка для перемещения объекта</param>
    private void Move(Vector2 targetPosition)
    {
        Vector2 direction = Vector2.MoveTowards(rb.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(direction);
    }

    /// <summary>
    /// Остановка объекта 
    /// </summary>
    private void StopMovement()
    {
        isMovingUp = false;
        isMovingDown = false;
        rb.velocity = Vector2.zero;
        rb.gravityScale = fallSpeed; 
    }
}

