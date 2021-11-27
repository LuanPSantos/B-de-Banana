using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{

    public float speed;

    private Vector3 inputDirection;

    void Update()
    {
        GetInputDirection();
        Move();
    }

    private void Move() 
    {
        transform.Translate(inputDirection * Time.deltaTime * speed);

        if(inputDirection.x != 0)
        {
            this.transform.localScale = new Vector3(inputDirection.x, 1, 1);
        }
    }

    private void GetInputDirection()
    {
        inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
    }
}
