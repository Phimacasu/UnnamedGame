using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimationController : MonoBehaviour
{
    // Reference to the main camera
    public Animation _cameraAnimation;
    public Animation _playerAnimation;
    public Animation _doorAnimation;

    // Flag to track if the player is within interaction range
    private bool _isPlayerInRange = false;

    void OnTriggerStay(Collider p_other)
    {
        // Check if the collider entering the trigger is the player
        if (p_other.CompareTag("Player"))
        {
            _isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider p_other)
    {
        // Check if the collider exiting the trigger is the player
        if (p_other.CompareTag("Player"))
        {
            _isPlayerInRange = false;
        }
    }

    void Update()
    {
        // Check for player input and proximity
        if (_isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            PlayAnimations();
        }
    }

    private void PlayAnimations()
    {
        // Trigger animation to move the camera
        if (_cameraAnimation != null)
        {
            // Play the camera animation
            _cameraAnimation.Play("CameraMoveAnimation");
            _playerAnimation.Play("PlayerTransitionAnimation");
            _doorAnimation.Play("Level1Door");
        }
    }
}
