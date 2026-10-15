using System;
using UnityEngine;

public class PlayerTopDown2DController : MonoBehaviour
{
    [SerializeField] private GetInputs inputs;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float accelerate = .1f;
    [SerializeField] private float decelerate = .1f;
    [SerializeField] private float turnReponse;
    
    
    private float _currentSpeed;
    private bool _isFacingRight = false;
    private Vector2 _moveDirection;
    private Vector2 _previousDirection;

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        _moveDirection = inputs.move;

        if(_moveDirection.SqrMagnitude() > 0.1f)
        {
            _previousDirection = _moveDirection;
        }
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 targetVelocity = Vector2.zero;

        if(inputs.move.sqrMagnitude > 0.01f)
        {
            _currentSpeed = Mathf.MoveTowards(_currentSpeed, moveSpeed, accelerate * Time.fixedDeltaTime);
            targetVelocity = _moveDirection * _currentSpeed;
        }
        else
        {
            _currentSpeed = Mathf.MoveTowards(_currentSpeed, 0f, decelerate * Time.fixedDeltaTime);
            targetVelocity = _previousDirection * _currentSpeed;
        }

        rb.linearVelocity = Vector2.MoveTowards(rb.linearVelocity, targetVelocity, turnReponse * Time.deltaTime);
    }
}
