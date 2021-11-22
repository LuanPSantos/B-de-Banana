using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public HealthBehaviour playerHealh;
    public float timeToAttack = 5;
    public float attackDistance = 5;
    public float damage = 30;

    public float thresholdToPlayer = 1;

    private float currentTimeToAttack = 0;
    private HealthBehaviour health;
    private EnemyMoviement movement;
    private EnemyState state;

    private Vector3 attackPosition;

    private void Start()
    {
        this.health = GetComponent<HealthBehaviour>();
        this.movement = GetComponent<EnemyMoviement>();

        state = EnemyState.MOVING;
    }

    void Update()
    {
        if (health.isDead())
        {
            Destroy(this.gameObject);
        }

        switch(state)
        {
            case EnemyState.MOVING:
                DetectAttack();
                break;
            case EnemyState.ATTACKING:

                Attack();

                break;
        }
    }

    private void DetectAttack()
    {

        if (currentTimeToAttack > timeToAttack)
        {
            this.state = EnemyState.ATTACKING;
            currentTimeToAttack = 0;      
        }
        else
        {
            currentTimeToAttack += Time.deltaTime;
        }

        if (playerHealh.transform.position.y < this.transform.position.y + thresholdToPlayer && playerHealh.transform.position.y > this.transform.position.y - thresholdToPlayer)
        {
            float direction = playerHealh.transform.position.x > this.transform.position.x ? attackDistance : -attackDistance;

            attackPosition = new Vector3(direction, 0, 0) + transform.position;
        }
    }

    private void Attack()
    {
        movement.Attack(attackPosition);

        if (Mathf.Abs(transform.position.x - attackPosition.x) < 0.1f)
        {
            this.state = EnemyState.MOVING;
        }
    }

    private void Move()
    {

    }

    enum EnemyState
    {
        MOVING, ATTACKING
    }
}
