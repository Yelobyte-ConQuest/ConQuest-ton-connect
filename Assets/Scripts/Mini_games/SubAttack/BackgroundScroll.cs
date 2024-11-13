using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 2f; // Speed at which the background moves
    public GameObject backgroundPrefab; // Prefab of the background to spawn
    public float spawnRate = 10f; // Rate at which backgrounds spawn

    private float nextSpawnTime;
    private float backgroundWidth;

    void Start()
    {
        // Get the width of the background sprite
        backgroundWidth = backgroundPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Check if it's time to spawn a new background
        if (Time.time >= nextSpawnTime)
        {
            SpawnBackground();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }

        // Move all spawned backgrounds to the left
        foreach (Transform child in transform)
        {
            child.Translate(Vector2.left * scrollSpeed * Time.deltaTime);
        }
    }

    void SpawnBackground()
    {
        // Spawn a new background at the spawn point
        GameObject newBackground = Instantiate(backgroundPrefab, transform.position, Quaternion.identity);
        newBackground.transform.parent = transform;

        // Position the new background after the last spawned background
        float spawnXPosition = backgroundWidth * (transform.childCount - 1);
        newBackground.transform.position = new Vector2(spawnXPosition, transform.position.y);
    }
}
