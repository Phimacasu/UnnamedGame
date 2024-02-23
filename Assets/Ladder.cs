using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float climbSpeed = 3f;

    private bool isClimbing;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isClimbing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isClimbing = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isClimbing)
        {
            float verticalInput = Input.GetAxis("Vertical");
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();

            if (playerRigidbody != null)
            {
                Vector3 climbVelocity = new Vector3(0f, verticalInput * climbSpeed, 0f);
                playerRigidbody.velocity = climbVelocity;
            }
        }
    }
}
