using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimationController : MonoBehaviour
{
    // Reference to the main camera
    public Transform mainCamera;

    // Destination position for the camera (X, Y, Z)
    public float cameraDestinationX;
    public float cameraDestinationY;
    public float cameraDestinationZ;

    // Destination rotation for the camera (X, Y, Z)
    public float cameraRotationX;
    public float cameraRotationY;
    public float cameraRotationZ;

    // Flag to track if the player is within interaction range
    private bool isPlayerInRange = false;

    void OnTriggerStay(Collider other)
    {
        // Check if the collider entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the collider exiting the trigger is the player
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    void Update()
    {
        // Check for player input and proximity
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Trigger animation to move the camera
            if (mainCamera != null)
            {
                // Set the camera's position
                mainCamera.position = new Vector3(2.4f, 6.9f, -51.4f);

                // Set the camera's rotation
                mainCamera.rotation = Quaternion.Euler(5.921f, -0.518f, -0.419f);
            }
        }
    }
}
