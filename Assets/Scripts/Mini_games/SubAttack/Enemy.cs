using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f; // Enemy health

    public void TakeDamage(float damage)
    {
        // Reduce enemy health by damage amount
        health -= damage;

        // Check if enemy health is less than or equal to zero
        if (health <= 0)
        {
            Die(); // Call Die function
        }
    }

    void Die()
    {
        Destroy(gameObject); // Destroy the enemy GameObject
        
    }
}
