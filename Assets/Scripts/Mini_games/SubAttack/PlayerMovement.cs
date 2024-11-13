using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the player moves
    public float minYPosition = -3f; // Minimum y-position the player can reach
    public float maxYPosition = 3f; // Maximum y-position the player can reach

    void Update()
    {
        // Get input for vertical movement (up/down)
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the player's movement amount based on input and speed
        float movementAmount = verticalInput * moveSpeed * Time.deltaTime;

        // Calculate the new y-position for the player
        float newYPosition = Mathf.Clamp(transform.position.y + movementAmount, minYPosition, maxYPosition);

        // Update the player's position
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }
}
