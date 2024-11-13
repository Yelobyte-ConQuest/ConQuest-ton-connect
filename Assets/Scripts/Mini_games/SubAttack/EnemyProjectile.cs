using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 5f; // Speed of the projectile
    public float damage = 10f; // Damage dealt by the projectile

    void Update()
    {
        // Move the projectile to the left
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the projectile collides with the player
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (other.CompareTag("Player"))
        {
            player.TakeDamage(damage); // Call TakeDamage function of the player
            Destroy(gameObject); // Destroy the projectile GameObject
        }

        // Destroy the projectile when it collides with any object
        //Destroy(gameObject);
    }
}
