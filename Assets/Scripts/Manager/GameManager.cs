using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public SpawnManager spawnManager;
    public HealthBehaviour playerHealth;
    public Text readyText;
    public Text healthText;

    private bool isPlaying;
    void Start()
    {
        isPlaying = false;
        spawnManager.enabled = false;
        readyText.enabled = true;
        SetPlayerEnable(false);

    }

    void Update()
    {
        if (isPlaying)
        {
            if (playerHealth.isDead())
            {
                isPlaying = false;
                readyText.enabled = true;
                spawnManager.enabled = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                SetPlayerEnable(false);
            }

            healthText.text = playerHealth.GetCurrentHealth().ToString();
        }
        else
        {
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                readyText.enabled = false;
                isPlaying = true;
                spawnManager.enabled = true;
                SetPlayerEnable(true);
            }
        }
    }

    private void SetPlayerEnable(bool enabled)
    {
        playerHealth.gameObject.GetComponent<PlayerMoviment>().enabled = enabled;
        playerHealth.gameObject.GetComponent<PlayerBehaviour>().enabled = enabled;
        healthText.enabled = enabled;
    }
}
