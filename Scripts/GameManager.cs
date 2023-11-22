using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject cloudPrefab;
    // Coin, Heart, Shield
    public GameObject[] stuffToSpawn;
    public int score;
    public int cloudsMove;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public int lives;
    private int maxLives = 3;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();
        InvokeRepeating("SpawnEnemyOne", 1f, 2f);
        InvokeRepeating("SpawnEnemyTwo", 4f, 8f);
        // Week 12 Code Liz Thompson
        // Spawn (coin, heart, or shield) 2 seconds after the game starts, then every 10 seconds.
        InvokeRepeating("SpawnStuff", 2f, 10f);
        cloudsMove = 1;
        score = 0;
        scoreText.text = "Score: " + score;
        lives = maxLives;
        livesText.text = "Lives: " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.Euler(0, 0, 180));
    }

    void SpawnEnemyTwo()
    {
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-8, 8), 5.5f, 0), Quaternion.Euler(0, 0, 180));
    }

    void CreateSky()
    {
        for (int i = 0; i < 50; i++) 
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-11f, 11f), Random.Range(-7.5f, 7.5f), 0), Quaternion.identity);
        }
    }

    public void SpawnStuff()
    {
        int tempInt;
        tempInt = Random.Range(0, 3);
        for (int i = 0; i < 1; i++)
        {
            Instantiate(stuffToSpawn[tempInt], new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 0f), 0), Quaternion.identity);
        }
    }

    /*public void SpawnCoin()
    {
        for (int i = 0; i < 1; i++)
        {
            Instantiate(coinPrefab, new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 0f), 0), Quaternion.identity);

        }
    }

    public void SpawnHealth()
    {
        for (int i = 0; i < 1; i++)
        {
            Instantiate(heartPrefab, new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 0f), 0), Quaternion.identity);

        }
    }

    public void SpawnShield()
    {
        for (int i = 0; i < 1; i++)
        {
            Instantiate(shieldPrefab, new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 0f), 0), Quaternion.identity);

        }
    }*/

    public void GameOver()
    {
        CancelInvoke();
        cloudsMove = 0;
    }

    public void EarnScore(int scoreToAdd)
    {
        score = score + scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void LifeLost(int loseALife)
    {
        lives = lives + loseALife;
        livesText.text = "Lives: " + lives;
    }

    public void LifeGained(int gainALife)
    {
        lives = lives + gainALife;
        livesText.text = "Lives: " + lives;
        if (lives > maxLives)
        {
            lives = maxLives;
        }
    }

}
