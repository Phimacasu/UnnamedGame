using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimationController : MonoBehaviour
{
    // Reference to the main camera
    public Animation cameraAnimation;
    public Animation playerAnimation;
    public Animation doorAnimation;

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
            if (cameraAnimation != null)
            {
                // Play the camera animation
                cameraAnimation.Play("CameraMoveAnimation");
                playerAnimation.Play("PlayerTransitionAnimation");
                doorAnimation.Play("Level1Door");
            }
        }
    }
}
