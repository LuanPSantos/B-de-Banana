using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InlineAttackBehaviour : MonoBehaviour
{
    public float attackSpeed = 15;
    public float timeToAttack = 2;
    public float attackThreshold = 0.99f;
    public float stopAttackThreshold = 1;
    public PlayerBehaviour playerBehaviour;

    private EnemyBehaviour enemyBehaviour;
    private float currentTimeToAttack = 0;
    private bool isAttackLoaded = false;
    private Vector2? currentTarget;

    void Start()
    {
        enemyBehaviour = GetComponent<EnemyBehaviour>();
        currentTarget = null;
    }

    public void AttackPlayer()
    {
        LoadAttack();
        Attack();
    }

    private void LoadAttack()
    {
        isAttackLoaded = currentTimeToAttack > timeToAttack;

        currentTimeToAttack += Time.deltaTime;
    }

    private void Attack()
    {
        if (isAttackLoaded)
        {

            if (enemyBehaviour.isAlignedWithPlayer() && currentTarget == null)
            {
                currentTarget = new Vector2(playerBehaviour.transform.position.x, playerBehaviour.transform.position.y);
            }

            if(currentTarget == null)
            {
                enemyBehaviour.state = EnemyBehaviour.EnemyState.MOVING;
            }

            if (currentTarget != null)
            {
                transform.position = Vector2.Lerp(transform.position, (Vector2)currentTarget, attackSpeed * Time.deltaTime);

                if (Mathf.Abs(transform.position.x - (float)currentTarget?.x) < stopAttackThreshold)
                {
                    currentTarget = null;
                    enemyBehaviour.state = EnemyBehaviour.EnemyState.MOVING;
                    currentTimeToAttack = 0;
                }
            }
        }
    }
}
