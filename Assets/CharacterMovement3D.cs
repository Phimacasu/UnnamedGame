using UnityEngine;

public class CharacterMovement3D : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    private Rigidbody rb;
    private Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Check if the character is grounded
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.8f);

        // Debug log to detect if the character is grounded
        Debug.Log("Grounded: " + isGrounded);

        // Get the input direction relative to the camera's orientation
        Vector3 cameraForward = mainCamera.transform.forward;
        cameraForward.y = 0f; // Ensure the direction is horizontal
        cameraForward.Normalize();

        Vector3 cameraRight = mainCamera.transform.right;
        cameraRight.y = 0f; // Ensure the direction is horizontal
        cameraRight.Normalize();

        // Ignore vertical input axis
        float moveInputHorizontal = Input.GetAxis("Horizontal");

        // Calculate the movement direction relative to the camera
        Vector3 movement = cameraRight * moveInputHorizontal * speed * Time.deltaTime;
        transform.Translate(movement);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}

