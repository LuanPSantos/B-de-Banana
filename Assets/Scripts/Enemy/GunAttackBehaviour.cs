using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAttackBehaviour : AttackBehaviour
{
    public PlayerBehaviour playerBehaviour;

    public float attackSpeed = 15;
    public float stopAttackThreshold = 1;
    public float distanceToAttack = 1;

    private GunBehaviour gunBehaviour;
    private EnemyBehaviour enemyBehaviour;
    private bool isAimed = false;
    private Vector3 target;

    void Start()
    {
        gunBehaviour = GetComponent<GunBehaviour>();
        enemyBehaviour = GetComponent<EnemyBehaviour>();
    }

    public override void AttackPlayer()
    {
        if (isAimed)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, target.y, attackSpeed * Time.deltaTime), transform.position.z);

            if (Mathf.Abs(transform.position.y - target.y) < stopAttackThreshold)
            {
                isAimed = false;
                gunBehaviour.Fire(transform.localScale.x);
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
