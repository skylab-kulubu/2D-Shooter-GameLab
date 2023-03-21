using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    [SerializeField] private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    public Vector2 MovementInput { get { return _movementInput; } set { _movementInput = value; } }

    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    public MobileJoystick joystickInput;

    private bool isFacingRight = true;

    [SerializeField] Camera cam;

    [SerializeField] private Animator animator;
    float dalga;
    
   

    private void Update()
    {
        
        animator.SetFloat("Speed", _rigidbody.velocity.magnitude);
        _movementInput = FindObjectOfType<MobileJoystick>().CalculateMovementInput(FindObjectOfType<MobileJoystick>().offset);
        //_movementInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if(Input.GetAxisRaw("Horizontal") == 1 && !isFacingRight)
        {
            Flip();
        }
        else if (Input.GetAxisRaw("Horizontal") == -1 && isFacingRight)
        {
            Flip();
        }

        Debug.Log(MovementInput);
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




    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}


