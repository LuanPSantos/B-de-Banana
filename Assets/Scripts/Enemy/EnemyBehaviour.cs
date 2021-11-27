using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public PlayerBehaviour playerBehaviour;
    public GameManager gameManager;
    public GameObject potion;
    public int potionPercent = 1;
    public int scoreGiven;
    public float aligningThreshold = 0.99f;
    public float distanceToAction = 5;
    public float timeBetweenAttacks = 2;

    private HealthBehaviour health;
    private AttackBehaviour attackBehaviour;
    private EnemyMovementBehaviour enemyMovementBehaviour;
    private float currentTimeBetweenAttacks = 3;
    private EnemyState state;

    private void Start()
    {
        this.health = GetComponent<HealthBehaviour>();
        this.enemyMovementBehaviour = GetComponent<EnemyMovementBehaviour>();
        this.attackBehaviour = GetComponent<AttackBehaviour>();

        state = EnemyState.MOVING;
    }

    void Update()
    {
        if (health.isDead())
        {
            gameManager.IncreaseScore(scoreGiven);

            if(Random.Range(0, 100) < potionPercent)
            {
                Instantiate(potion, transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }

        currentTimeBetweenAttacks += Time.deltaTime;
    }

    void FixedUpdate()
    {
        switch (state)
        {
            case EnemyState.MOVING:
            enemyMovementBehaviour.FollowPlayer();

            if (Vector2.Distance(transform.position, playerBehaviour.transform.position) < distanceToAction)
            {

                int random = Random.Range(0, 3);
                if (random == 0)
                {
                    StartDodging();
                    Invoke("StartMoving", 1.0f);
                }
                else if (random == 1)
                {
                    StartDeshing();
                    Invoke("StartMoving", 1.0f);

                }
                else if (currentTimeBetweenAttacks > timeBetweenAttacks)
                {
                    StartAttacking();
                    currentTimeBetweenAttacks = 0;
                }
            }

            break;
        case EnemyState.ATTACKING:
            attackBehaviour.AttackPlayer();

            break;
        case EnemyState.DODGING:
            enemyMovementBehaviour.Dodge();

            break;
        case EnemyState.DESHING:

            enemyMovementBehaviour.Desh();

            break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            StartDodging();
            Invoke("StartMoving", 2.0f);
        }
    }

    public void StartMoving()
    {
        state = EnemyState.MOVING;
    }

    private void StartDodging()
    {
        state = EnemyState.DODGING;
    }

    private void StartDeshing()
    {
        enemyMovementBehaviour.ResetDesh();
        state = EnemyState.DESHING;
    }

    private void StartAttacking()
    {
        state = EnemyState.ATTACKING;
    }

    public bool IsAlignedWithPlayer()
    {
        return
            Vector2.Dot(((Vector2) playerBehaviour.transform.position - (Vector2)transform.position).normalized, Vector2.right) > aligningThreshold ||
            Vector2.Dot(((Vector2) playerBehaviour.transform.position - (Vector2)transform.position).normalized, -Vector2.right) > aligningThreshold;
    }

    public enum EnemyState
    {
        MOVING, ATTACKING, DODGING, DESHING
    }
}
