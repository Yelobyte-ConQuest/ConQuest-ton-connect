using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab of the projectile to shoot
    public Transform shootPoint; // Point from where the projectile will be shot
    public float shootSpeed = 10f; // Speed of the projectile

    void Update()
    {
        // Check for player input to shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate a new projectile at the shoot point
        GameObject newProjectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

        // Get the rigidbody of the projectile and set its velocity to shootSpeed
        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * shootSpeed;

    }
}
