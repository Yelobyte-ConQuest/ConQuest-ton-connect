using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 50f; // Damage dealt by the projectile

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the projectile collides with an enemy
        Enemy enemy = other.GetComponent<Enemy>();
        if (other.CompareTag("Enemy"))
        {
            enemy.TakeDamage(damage); // Call TakeDamage function of the enemy
            Destroy(gameObject); // Destroy the projectile GameObject
            Debug.Log("hit");
        }
    }
}
