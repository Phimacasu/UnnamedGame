using UnityEngine;

public class CharacterMovement3D : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public float cameraDistanceX = 1f;
    public float cameraDistanceZ = 2f;
    public float cameraDistanceY = -9f;
    public float cameraLerpSpeed = 10f;

    private Rigidbody rb;
    private Camera mainCamera;
    private Animation playerAnimation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        playerAnimation = GetComponent<Animation>();
    }

    void Update()
    {
        // Check if the character is grounded
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.8f);

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
 
            
            Vector3 cameraTargetPosition = transform.position + new Vector3(0f, 1f, -12f);
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, cameraTargetPosition, Time.deltaTime * cameraLerpSpeed);
    }
    }

