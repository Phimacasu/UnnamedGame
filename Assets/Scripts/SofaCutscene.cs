using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTriggerScript : MonoBehaviour
{
    public Animation nearSofaCutsceneAnimation;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Play the NearSofaCutscene animation
            nearSofaCutsceneAnimation.Play("NearSofaCutscene");
        }
    }
}
