using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnRate;
    public GameObject[] enemies;
    public PlayerBehaviour playerBehaviour;
    public GameManager gameManager;

    private Renderer render;

    void Start()
    {
        render = GetComponent<Renderer>();

        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyBehaviour>().playerBehaviour = playerBehaviour;
            enemy.GetComponent<EnemyBehaviour>().gameManager = gameManager;
            enemy.GetComponent<EnemyMovementBehaviour>().playerBehaviour = playerBehaviour;
            enemy.GetComponent<AttackBehaviour>().SetPlayerBehaviour(playerBehaviour);
        }

        InvokeRepeating("Spawn", 0, spawnRate);
    }

    private void Spawn()
    {
        float minX = (render.transform.position.x - render.bounds.size.x / 2);
        float maxX = (render.transform.position.x + render.bounds.size.x / 2);
        float minY = (render.transform.position.y - render.bounds.size.y / 2);
        float maxY = (render.transform.position.y + render.bounds.size.y / 2);

        Instantiate(
            enemies[Random.Range(0, enemies.Length)], 
            new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0), 
            Quaternion.identity
        );
    }
}
