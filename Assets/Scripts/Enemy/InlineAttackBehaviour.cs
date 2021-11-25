using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InlineAttackBehaviour : MonoBehaviour
{
    public float attackSpeed = 15;
    public float stopAttackThreshold = 1;
    public float distanceToAttack = 1;
    public PlayerBehaviour playerBehaviour;

    private EnemyBehaviour enemyBehaviour;
    private BoxCollider2D collider2d;
    private bool isAimed = false;
    private Vector3 target;

    void Start()
    {
        enemyBehaviour = GetComponent<EnemyBehaviour>();
        collider2d = GetComponent<BoxCollider2D>();
    }

    public void AttackPlayer()
    {
        if (isAimed)
        {
            transform.position = Vector2.Lerp(transform.position, target, attackSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, target) < stopAttackThreshold)
            {
                collider2d.enabled = false;
                isAimed = false;
                enemyBehaviour.StartMoving();
            }

            if(Vector2.Distance(transform.position, playerBehaviour.transform.position) < distanceToAttack)
            {
                playerBehaviour.ApplyDamage();
                collider2d.enabled = false;
                isAimed = false;
                enemyBehaviour.StartMoving();
            }

        }
        else
        {
            target = playerBehaviour.transform.position;
            collider2d.enabled = true;
            isAimed = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(target, Vector3.one);
    }
}
