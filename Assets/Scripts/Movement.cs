using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    [SerializeField] private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;

    private bool isFacingRight = true;


    [SerializeField] Camera cam;

    [SerializeField] private Animator animator;

    private void Update()
    {
        animator.SetFloat("Speed", _rigidbody.velocity.magnitude);
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
    }

    private void SetPlayerVelocity()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
                    _smoothedMovementInput,
                    _movementInput,
                    ref _movementInputSmoothVelocity,
                    0.1f);

        _rigidbody.velocity = _smoothedMovementInput * _speed;
    }



    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale *= -1f;
        transform.localScale = localScale;
    }
}


