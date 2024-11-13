using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FruitFall : MonoBehaviour
{
    public GameObject PlayerUI;
    public GameObject PauseMenuUI;
    public GameObject topPanel;
    public GameObject startPanel;
    public GameObject gameOverUI;


    public GameObject[] fruitPrefabs; // Array of fruit prefabs
    public GameObject[] powerPrefabs; // Array of power prefabs
    public Transform[] spawnPoints; // Array of spawn points
    public float spawnInterval = 1f; // Time interval between fruit spawns
    public float powerSpawnInterval = 1f; // Time interval between spawns spawns
    public float spawnSpeedIncrease = 0.1f; // Speed increase per level
    public int fruitsPerLevel = 20; // Number of fruits per level

    private int currentLevel = 1; // Current level
    private int fruitsSpawned = 0; // Number of fruits spawned in the current level


    public FruityMixPlayer FMP;
    

    private void Start()
    {
        //Time.timeScale = 1f;
    }
    private void Update()
    {
        if (spawnInterval <= 0.3f)
        {
            spawnInterval = 0.3f;
        }
    }


    public void Play()
    {
        
        StartCoroutine(SpawnFruits());
        StartCoroutine(SpawnPowers());
        PlayerUI.SetActive(true);
        topPanel.SetActive(true);
        startPanel.SetActive(false);
    }

    public void GameOver()
    {
        
        gameOverUI.SetActive(true);
        
        topPanel.SetActive(false);
        PlayerUI.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        PauseMenuUI.SetActive(true);
        topPanel.SetActive(false);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
        topPanel.SetActive(true);
    }

    public void Exit()
    {
        SceneManager.LoadScene("Main");
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }


    IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            if (fruitsSpawned < fruitsPerLevel)
            {
                SpawnFruit();
                fruitsSpawned++;
            }
            else
            {
                // Move to the next level
                currentLevel++;
                fruitsSpawned = 0;
                spawnInterval -= spawnSpeedIncrease; // Increase speed for the next level
            }
            
            if (FMP.life <= 0)
            {
                yield break;

            }
        }
                
    }

    IEnumerator SpawnPowers()
    {
        while (true)
        {
            yield return new WaitForSeconds(powerSpawnInterval);
            if (fruitsSpawned < fruitsPerLevel)
            {
                SpawnPower();
                
            }
           
            if (FMP.life <= 0)
            {
                yield break;

            }
        }

    }

    void SpawnFruit()
    {
        // Choose a random spawn point
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Choose a random fruit prefab
        GameObject fruitPrefab = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];

        // Spawn the fruit at the chosen spawn point
        Instantiate(fruitPrefab, spawnPoint.position, Quaternion.identity);
    }


    void SpawnPower()
    {
        // Choose a random spawn point
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Choose a random power prefab
        GameObject powerPrefab = powerPrefabs[Random.Range(0, powerPrefabs.Length)];

        // Spawn the power at the chosen spawn point
        Instantiate(powerPrefab, spawnPoint.position, Quaternion.identity);
    }

}
