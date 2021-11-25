using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

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

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Fireble")
        {
            health.TakeDamage(25f);
        }        
    }

    public void ApplyDamage()
    {
        health.TakeDamage(10f);
    }
    private void Fire()
    {
       
         gun.Fire(this.transform.localScale.x);
        
    }

    private void Die()
    {
        Debug.Log("PLAYER MORREU");
        this.gameObject.SetActive(false);
    }
}
