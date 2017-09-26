using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;


    public Vector3 spawnValues;
    public int hazardCount;
   
    
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text liveText;
    public Text waveCounterText;

    private float Level;
    public int playerHealth;

    public GameObject BG;
    public GameObject BG1;
    public GameObject BG2;
    public GameObject BG3;
    public GameObject BG4;

    public GameObject bossPrefab;
    public GameObject bossPrefab1;
    public GameObject bossPrefab2;
    public GameObject bossPrefab3;

    public AudioSource SpaceBGSound;
    public AudioSource SpaceBGSound1;
    public AudioSource SpaceBGSound2;
    public AudioSource SpaceBGSound3;
    public AudioSource SpaceBGSound4;

    public AudioSource HitSound;

    private int score;
    public bool gameOver;
    private bool restart;
    public int WaveCounter = 1;
    public int HazardCountIncrease = 1;
    public float SpawnSpeedIncrease = 0.5f;

    public PowerUpScript powerUpScript;

    void Start()
    {
        playerHealth = 3;

        BG.SetActive(true);
        BG1.SetActive(false);
        BG2.SetActive(false);
        BG3.SetActive(false);
        BG4.SetActive(false);

        bossPrefab.SetActive(false);
        bossPrefab1.SetActive(false);
        bossPrefab2.SetActive(false);
        bossPrefab3.SetActive(false);

        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        liveText.text = "Live:3";
        waveCounterText.text = "Wave:1";


       score = 0;
       
        UpdateScore();

        StartCoroutine(SpawnWaves());
    }
    public void SubLive()
    {
        playerHealth--;
        HitSound.Play();
        UpdateLives();
        if(playerHealth < 1)
        {
            HitSound.Stop();
        }
        if (playerHealth <= 0)
        {
            gameOver = true;
        }
    }

    void UpdateLives()
    {
        liveText.text = "Lives: " + playerHealth;
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            hazardCount += (WaveCounter * HazardCountIncrease);

            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait - (WaveCounter * SpawnSpeedIncrease));
                waveCounterText.text = "Wave:" + WaveCounter;

            }
            yield return new WaitForSeconds(waveWait);
                 WaveCounter++;

                if (gameOver)
                {
                    restartText.text = "Press 'R' for Restart";
                    restart = true;
                    powerUpScript.powerUpCount = 0;
                    break;

                }
                if(WaveCounter == 9)
            {
                bossPrefab.SetActive(true);
                Instantiate(bossPrefab, transform.position, Quaternion.identity);
                
            }
            if (WaveCounter == 10)
            {
                BG.SetActive(false);
                BG1.SetActive(true);
                SpaceBGSound.Stop();
                SpaceBGSound1.Play();
            }
            if(WaveCounter == 19)
            {
                bossPrefab1.SetActive(true);
                Instantiate(bossPrefab1, transform.position, Quaternion.identity);
            }
            if (WaveCounter == 20)
            {
                BG1.SetActive(false);
                BG2.SetActive(true);
                SpaceBGSound1.Stop();
                SpaceBGSound2.Play();
            }
            if(WaveCounter == 29)
            {
                bossPrefab2.SetActive(true);
                Instantiate(bossPrefab2, transform.position, Quaternion.identity);
            }
            if (WaveCounter == 30)
            {
                BG2.SetActive(false);
                BG3.SetActive(true);
                SpaceBGSound2.Stop();
                SpaceBGSound3.Play();
            }
            if(WaveCounter == 39)
            {
                bossPrefab3.SetActive(true);
                Instantiate(bossPrefab3, transform.position, Quaternion.identity);
            }
            if (WaveCounter == 40)
            {
                BG3.SetActive(false);
                BG4.SetActive(true);
                SpaceBGSound3.Stop();
                SpaceBGSound4.Play();
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }


public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;

    }
}
