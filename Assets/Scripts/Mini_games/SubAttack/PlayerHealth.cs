using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100f; // Player health
    MenuNav MenuNav;

    public void TakeDamage(float damage)
    {
        // Reduce player health by damage amount
        health -= damage;

        // Check if player health is less than or equal to zero
        if (health <= 0)
        {
            Die(); // Call Die function
        }
    }

    void Die()
    {
        Destroy(gameObject); // Destroy the player GameObject
        // Implement additional game over logic here
        MenuNav.Endgame();
    }
}
