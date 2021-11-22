using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviement : MonoBehaviour
{
    public float attackSpeed = 10;

    private Rigidbody2D rb;

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(Vector3 finalPosition)
    {
        transform.position = Vector3.Lerp(transform.position, finalPosition, attackSpeed * Time.deltaTime);
    }
}
