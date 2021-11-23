using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehaviour : MonoBehaviour
{
    public float speed = 10;

    public PlayerBehaviour playerBehaviour;

    private Rigidbody2D rb;

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        Vector3 direction = (playerBehaviour.transform.position - transform.position).normalized;
        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);

        if (direction.x > 0)
        {
            this.transform.localScale = new Vector3(-1 * 0.5f, 0.5f, 1);
        }
        else
        {
            this.transform.localScale = new Vector3(1 * 0.5f, 0.5f, 1);
        }
    }
}
