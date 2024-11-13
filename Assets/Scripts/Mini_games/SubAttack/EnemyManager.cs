using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign your enemy prefab in the Inspector
    public List<GameObject> enemyList = new List<GameObject>();
    public int enemyCount = 3;

    public void Spawn()
    {
        // Spawn and add enemies to the list
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        
            // Spawn an enemy at a random position
            Vector3 spawnPosition = new Vector3(Random.Range(1, 6), Random.Range(-3, 3), 0);
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemyList.Add(newEnemy);
        
    }

    
}
