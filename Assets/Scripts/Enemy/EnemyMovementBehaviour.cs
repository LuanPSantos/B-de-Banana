using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehaviour : MonoBehaviour
{
    public float speed = 10;
    public PlayerBehaviour playerBehaviour;

    private Rigidbody2D rb;
    private Vector3? deshDirection;
    private EnemyBehaviour enemyBehaviour;

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.enemyBehaviour = GetComponent<EnemyBehaviour>();
        deshDirection = null;
    }

    public void FollowPlayer()
    {
        Vector3 direction = (playerBehaviour.transform.position - transform.position).normalized;
        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);

        LookToDirection(direction);
    }

    public void Dodge()
    {
        Vector3 direction = Vector2.Perpendicular((playerBehaviour.transform.position - transform.position).normalized);

        rb.MovePosition(transform.position + direction * speed * 1.5f * Time.deltaTime);
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

    public void Desh()
    {
        if(deshDirection == null)
        {
            Vector3 directionToPlayer = (playerBehaviour.transform.position - transform.position).normalized;

            Quaternion rotation = Quaternion.AngleAxis(30, Vector3.forward);

            deshDirection = rotation * directionToPlayer;
        }
        

        rb.MovePosition(transform.position + (Vector3)deshDirection * speed * 1.5f * Time.deltaTime);
    }

    public void ResetDesh()
    {
        deshDirection = null;
    }
}
