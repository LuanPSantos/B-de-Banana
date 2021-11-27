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
    public Text scoreText;
    public Text maxScoreText;

    private bool isPlaying;
    private int score;
    private int maxScore;
    void Start()
    {
        isPlaying = false;
        spawnManager.enabled = false;
        readyText.enabled = true;
        maxScoreText.enabled = true;
        scoreText.enabled = false;
        maxScore = PlayerPrefs.GetInt("Score");
        maxScoreText.text = maxScore.ToString();
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
                maxScoreText.enabled = true;
                scoreText.enabled = false;
                spawnManager.enabled = false;
                SetPlayerEnable(false);

                if(maxScore < score)
                {
                    PlayerPrefs.SetInt("Score", score);
                    maxScore = score;
                    maxScoreText.text = maxScore.ToString();
                }

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            healthText.text = "Vida: " + playerHealth.GetCurrentHealth().ToString();
            scoreText.text = "Pontuação " + score + "/" + maxScore + " Recorde";
        }
        else
        {
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                score = 0;
                readyText.enabled = false;
                maxScoreText.enabled = false;
                scoreText.enabled = true;
                isPlaying = true;
                spawnManager.enabled = true;
                SetPlayerEnable(true);
            }
        }
    }

    public void IncreaseScore(int score)
    {
        this.score += score;
    }

    private void SetPlayerEnable(bool enabled)
    {
        playerHealth.gameObject.GetComponent<PlayerMoviment>().enabled = enabled;
        playerHealth.gameObject.GetComponent<PlayerBehaviour>().enabled = enabled;
        healthText.enabled = enabled;
    }
}
