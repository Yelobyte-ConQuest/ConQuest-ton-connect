using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject enemyProjectilePrefab; // Prefab of the enemy projectile
    public Transform shootPoint; // Point from where the projectile will be shot
    public float shootInterval = 2f; // Interval between shots
    public float projectileSpeed = 5f; // Speed of the projectile

    private float shootTimer;
    private Transform player; // Reference to the player


    void Start()
    {
        // Find the player in the scene
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Update the timer and shoot if necessary
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            Shoot();
            shootTimer = shootInterval;
        }
    }

    void Shoot()
    {
        if (player != null)
        {
            // Calculate the direction to the player
            Vector2 direction = (player.position - shootPoint.position).normalized;

            // Instantiate a new projectile at the shoot point
            GameObject newProjectile = Instantiate(enemyProjectilePrefab, shootPoint.position, Quaternion.identity);

            // Set the projectile's velocity to move towards the player
            Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
            rb.velocity = direction * projectileSpeed;
        }
    }
}
