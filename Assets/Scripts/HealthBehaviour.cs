using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{

    public float totalHealth = 100;
    private float currentHealth = 100;

    public void TakeDamage(float damage)
    {
        this.currentHealth = Mathf.Clamp(currentHealth - damage, 0, totalHealth);
    }

    public void Heal(float health)
    {
        this.currentHealth = Mathf.Clamp(currentHealth + health, 0, totalHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            TakeDamage(10);
        }
    }

    public bool isDead()
    {
        return currentHealth == 0;
    }
}
