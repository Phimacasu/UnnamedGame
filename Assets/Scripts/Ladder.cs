using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float climbSpeed = 3f;
    public float idleDrag = 5f; // Drag when not climbing

    private bool isClimbing;
    private Rigidbody playerRigidbody;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isClimbing = true;
            playerRigidbody = other.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                playerRigidbody.useGravity = false; // Disable gravity while climbing
                playerRigidbody.drag = idleDrag; // Apply idle drag
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isClimbing = false;
            if (playerRigidbody != null)
            {
                playerRigidbody.useGravity = true; // Enable gravity when not climbing
                playerRigidbody.drag = 0f; // Reset drag
                playerRigidbody = null;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isClimbing)
        {
            float verticalInput = Input.GetAxis("Vertical");

            if (playerRigidbody != null)
            {
                // Calculate climb velocity
                Vector3 climbVelocity = new Vector3(0f, verticalInput * climbSpeed, 0f);

                // Apply climb force
                playerRigidbody.velocity = climbVelocity;

                // If not moving vertically, reduce the vertical velocity to prevent falling
                if (verticalInput == 0f)
                {
                    playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, 0f, playerRigidbody.velocity.z);
                }
            }
        }
    }
}
