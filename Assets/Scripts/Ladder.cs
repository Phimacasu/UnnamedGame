using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float _climbSpeed;
    public float _idleDrag; // Drag when not climbing

    private Rigidbody _playerRigidbody;
    private Vector3 _climbForce;
    private bool _isClimbing;
    private float _verticalInput;

    void Start ()
    {
        _climbSpeed = 6f;
        _idleDrag = 5f;
    }

    private void OnTriggerEnter(Collider p_other)
    {
        if (p_other.CompareTag("Player"))
        {
            _isClimbing = true;
            _playerRigidbody = p_other.GetComponent<Rigidbody>();
            if (_playerRigidbody != null)
            {
                _playerRigidbody.useGravity = false; // Disable gravity while climbing
                _playerRigidbody.drag = _idleDrag; // Apply idle drag
            }
        }
    }

    private void OnTriggerExit(Collider p_other)
    {
        if (p_other.CompareTag("Player"))
        {
            _isClimbing = false;
            if (_playerRigidbody != null)
            {
                _playerRigidbody.useGravity = true; // Enable gravity when not climbing
                _playerRigidbody.drag = 0f; // Reset drag
                _playerRigidbody = null;
            }
        }
    }

    private void OnTriggerStay(Collider p_other)
    {
        if (_isClimbing)
        {
            _verticalInput = GetVerticalInput();

            if (_playerRigidbody == null)
            {
                return;
            }

            // Calculate climb force
            _climbForce = new Vector3(0f, _verticalInput * _climbSpeed, 0f);

            // Apply climb force
            _playerRigidbody.AddForce(_climbForce);

            // If not moving vertically, reduce the vertical velocity to prevent falling
            if (_verticalInput == 0f)
            {
                _playerRigidbody.velocity = new Vector3(_playerRigidbody.velocity.x, 0f, _playerRigidbody.velocity.z);
            }
        }
    }

    private float GetVerticalInput()
    {
        return Input.GetAxis("Vertical");
    }
}
