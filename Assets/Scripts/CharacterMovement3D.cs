using UnityEngine;

public class CharacterMovement3D : MonoBehaviour
{
    public float _speed = 5f;
    public float _jumpForce = 5f;
    public float _cameraDistanceX = 1f;
    public float _cameraDistanceZ = 2f;
    public float _cameraDistanceY = -9f;
    public float _cameraLerpSpeed = 10f;

    private Rigidbody _rb;
    private Camera _mainCamera;
    private Vector3 _cameraRight;
    private Vector3 _movement;
    private Vector3 _cameraTargetPosition;
    private bool _isGrounded;
    private float _moveInputHorizontal;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
    }

    void Update()
    {
        // Check if the character is grounded
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.8f);

        _cameraRight = _mainCamera.transform.right;
        _cameraRight.y = 0f; // Ensure the direction is horizontal
        _cameraRight.Normalize();

        // Ignore vertical input axis
        _moveInputHorizontal = Input.GetAxis("Horizontal");

        // Calculate the movement direction relative to the camera
        _movement = _cameraRight * _moveInputHorizontal * _speed * Time.deltaTime;
        transform.Translate(_movement);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
     
        _cameraTargetPosition = transform.position + new Vector3(0f, 1f, -12f);
        _mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position, _cameraTargetPosition, Time.deltaTime * _cameraLerpSpeed);
    }
    }

