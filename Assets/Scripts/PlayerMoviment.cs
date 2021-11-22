using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb;
    private GunBehaviour gun;
    private Vector3 direction;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gun = GetComponent<GunBehaviour>();
    }

    void Update()
    {
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            gun.Fire(this.transform.localScale.x);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * Time.deltaTime * speed);

        if(direction.x != 0)
        {
            this.transform.localScale = new Vector3(direction.x * (-1), 1, 1);
        }  
    }
}
