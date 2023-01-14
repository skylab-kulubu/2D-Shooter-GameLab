using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Movement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 move;
    private Rigidbody2D rb;
    [SerializeField] private InputAction moveAction;
    private Animator animator;

    private void OnEnable()
    {
        moveAction.Enable();
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    private void Update()
    {
        move = moveAction.ReadValue<Vector2>();
        animator.SetFloat("Speed", rb.velocity.magnitude);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(move.x * speed, move.y * speed);
    }
}
