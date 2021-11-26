using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public Text healthText;
    public HealthBehaviour health;

    private GunBehaviour gun;

    void Start()
    {
        gun = GetComponent<GunBehaviour>();
    }

    void Update()
    {
        if(health.isDead())
        {
            Die();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }

        healthText.text = health.GetCurrentHealth().ToString();
    }

    public void ApplyDamage(float damage)
    {
        health.TakeDamage(damage);
    }
    private void Fire()
    {
       
         gun.Fire(transform.localScale.x);
        
    }

    private void Die()
    {
        Debug.Log("PLAYER MORREU");
        this.gameObject.SetActive(false);
    }
}
