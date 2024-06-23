using UnityEngine;

[RequireComponent(typeof(CharacterController))] 
public class Character : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float gravity = -9.89f;
    [SerializeField] Transform _groundChecker;
    [SerializeField] private float _checkGroundRadius = 0.3f;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private float _jumpHeight;

    private CharacterController _characterController;
    private float _velocity;
    private bool _isGrounded;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        _isGrounded = IsOnTheGround();

        if (_isGrounded && _velocity < 0f)
        {
            _velocity = -2f;
        }

        Move();
        DoGravity();
    }

    private void Update()
    {
        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private bool IsOnTheGround()
    {
        var result = Physics.CheckSphere(_groundChecker.position, _checkGroundRadius, _groundLayerMask);
        return result;
    }

    private void Move()
    {
        var direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        _characterController.Move(-direction * (_speed * Time.fixedDeltaTime));
    }

    private void Jump()
    {
        _velocity = Mathf.Sqrt(_jumpHeight * -2 * gravity);
    }

    private void DoGravity()
    {
        _velocity += gravity * Time.fixedDeltaTime;

        _characterController.Move(new Vector3(0f, _velocity * Time.fixedDeltaTime, 0f));
    }
}
