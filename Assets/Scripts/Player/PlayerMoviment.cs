using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb;
    private Vector3 inputDirection;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        GetInputDirection();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move() 
    {
        rb.MovePosition(transform.position + inputDirection * Time.deltaTime * speed);

        LookToDirection(inputDirection);
    }

    private void LookToDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            this.transform.localScale = new Vector3(-1 * 0.5f, 0.5f, 1);
        }
        else
        {
            this.transform.localScale = new Vector3(1 * 0.5f, 0.5f, 1);
        }
    }

    private void GetInputDirection()
    {
        inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
    }
}