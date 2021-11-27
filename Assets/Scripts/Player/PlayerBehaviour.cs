using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehaviour : MonoBehaviour
{
    
    public HealthBehaviour health;
    public AudioClip potionCollect;

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Potion")
        {
            AudioSource.PlayClipAtPoint(potionCollect, transform.position);
            health.Heal(30);
            Destroy(collision.gameObject);
        }
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
        this.gameObject.SetActive(false);
    }
}
