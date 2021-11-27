using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InlineAttackBehaviour : AttackBehaviour
{
    public float attackSpeed = 15;
    public float stopAttackThreshold = 1;
    public float distanceToAttack = 1;
    public float damage = 15;
    public PlayerBehaviour playerBehaviour;

    private EnemyBehaviour enemyBehaviour;
    private bool isAimed = false;
    private Vector3 target;

    void Start()
    {
        enemyBehaviour = GetComponent<EnemyBehaviour>();
    }

    public override void AttackPlayer()
    {
        if (isAimed)
        {
            transform.position = Vector2.Lerp(transform.position, target, attackSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, target) < stopAttackThreshold)
            {
                isAimed = false;
                enemyBehaviour.StartMoving();
            }

            if(Vector2.Distance(transform.position, playerBehaviour.transform.position) < distanceToAttack)
            {
                playerBehaviour.ApplyDamage(damage);
                isAimed = false;
                enemyBehaviour.StartMoving();
            }

        }
        else
        {
            target = playerBehaviour.transform.position;
            isAimed = true;
        }
    }

    public override void SetPlayerBehaviour(PlayerBehaviour playerBehaviour)
    {
        this.playerBehaviour = playerBehaviour;
    }
}
