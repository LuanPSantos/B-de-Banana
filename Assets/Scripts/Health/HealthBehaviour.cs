using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBehaviour : MonoBehaviour
{
    public float totalHealth = 100;
    public ParticleSystem blood;

    private float currentHealth = 100;

    void Start()
    {

    }

    public void TakeDamage(float damage)
    {
        this.currentHealth = Mathf.Clamp(currentHealth - damage, 0, totalHealth);
        blood.Play();
    }

    public void Heal(float health)
    {
        this.currentHealth = Mathf.Clamp(currentHealth + health, 0, totalHealth);
    }

    public bool isDead()
    {
        return currentHealth == 0;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
