using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public HealthBehaviour playerHealh;
    public float timeToAttack = 5;
    public float attackDistance = 5;
    public float damage = 30;
    public float aligningThreshold = 0.99f;

    public float thresholdToPlayer = 1;

    private float currentTimeToAttack = 0;
    private HealthBehaviour health;
    private InlineAttackBehaviour attackBehaviour;
    private EnemyMovementBehaviour enemyMovementBehaviour;
    public EnemyState state;

    private Vector3 attackPosition;

    private void Start()
    {
        this.health = GetComponent<HealthBehaviour>();
        this.enemyMovementBehaviour = GetComponent<EnemyMovementBehaviour>();
        this.attackBehaviour = GetComponent<InlineAttackBehaviour>();

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

                enemyMovementBehaviour.Move();

                if(isAlignedWithPlayer())
                {
                    state = EnemyState.ATTACKING;
                }

                break;
            case EnemyState.ATTACKING:

                attackBehaviour.AttackPlayer();

                break;
        }

    }

    public bool isAlignedWithPlayer()
    {
        return
            Vector2.Dot(((Vector2) playerHealh.transform.position - (Vector2)transform.position).normalized, Vector2.right) > aligningThreshold ||
            Vector2.Dot(((Vector2) playerHealh.transform.position - (Vector2)transform.position).normalized, -Vector2.right) > aligningThreshold;
    }

    public enum EnemyState
    {
        MOVING, ATTACKING
    }
}
