using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed at which the enemy moves
    public float moveChangeInterval = 2f; // Time interval to change movement direction

    private Vector2 moveDirection;
    private float moveChangeTimer;

    private float minX, maxX, minY, maxY;

    void Start()
    {
        // Calculate the screen boundaries
        Camera mainCamera = Camera.main;
        Vector2 screenBottomLeft = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 screenTopRight = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));

        minX = 1f;
        maxX = 6f;
        minY = -3f;
        maxY = 3f;

        ChangeDirection();
    }

    void Update()
    {
        // Move the enemy
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Check if the enemy is outside the boundaries and adjust position and direction
        if (transform.position.x < minX || transform.position.x > maxX || transform.position.y < minY || transform.position.y > maxY)
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, minX, maxX),
                Mathf.Clamp(transform.position.y, minY, maxY),
                transform.position.z
            );
            ChangeDirection();
        }

        // Update the timer and change direction if necessary
        moveChangeTimer -= Time.deltaTime;
        if (moveChangeTimer <= 0f)
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        // Randomly change the movement direction
        moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        moveChangeTimer = moveChangeInterval;
    }
}
