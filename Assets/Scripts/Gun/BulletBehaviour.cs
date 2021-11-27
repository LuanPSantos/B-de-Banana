using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float horizontalDirection = 1;
    public float speed = 15;
    public Rigidbody2D rb;
    public float damage;

    private void Start()
    {
        this.transform.localScale = new Vector3(horizontalDirection * (-1), 1, 0);
        Destroy(this.gameObject, 5);
    }

    private void FixedUpdate()
    {
        this.rb.MovePosition(transform.position + new Vector3(horizontalDirection, 0, 0) * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthBehaviour health = collision.gameObject.GetComponent<HealthBehaviour>();
        if (health != null)
        {
            health.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }

}
