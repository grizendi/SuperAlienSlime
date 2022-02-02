using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private KeyCode _inputButton = KeyCode.Space;
   
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private Collider2D _groundchecker;
    //[SerializeField] private Collider2D _leftwallchecker;
    //[SerializeField] private Collider2D _rightwallchecker;

    public float MoveSpeed;

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _maxFallSpeed;

    private int _maxJumpFrames = 5;
    private int _currentJumpFrames = 0;

    //private int _bugCounter = 0;
    //private int _maxBugCounter = 0;
    private Vector2 _lastFramePosition = new Vector2();
    private Vector2 _thisFramePosition = new Vector2();


    private bool _enableMovement;
    public bool IsJumping;
    private bool _canMove;
//    private bool _isWallSliding;

    public bool IsGrounded { get; private set; }

    [SerializeField] private float _fallMultiplier = 2.5f;
    [SerializeField] private float _lowFallMultiplier = 1.5f;
    //[SerializeField] private float _wallSlideFallMultiplier = -0.5f;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.isKinematic = false;
        _enableMovement = false;
        IsJumping = false;
        _canMove = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(_inputButton))
        {
            TryJump();
            BeginMoving();
        }
    }

    

    private void BeginMoving()
    {
        if (!_enableMovement) _enableMovement = !_enableMovement;
    }

    private void TryJump()
    {
        if (IsGrounded && _enableMovement)
        {
            IsJumping = true;
        }
        else
        {
            IsJumping = false;
            _currentJumpFrames = 0;
        }

    }

    private void FixedUpdate()
    {
        CheckGround();
        PhysicsUpdate();
        CheckForBugs();
    }

    private void CheckForBugs()
    {
        _thisFramePosition = transform.position;

        if (_lastFramePosition == _thisFramePosition && _enableMovement)
        {
            Debug.Log("Show bugs");
        }

        _lastFramePosition = transform.position;
    }

    private void CheckGround()
    {
        if (_groundchecker.IsTouchingLayers(_groundLayer))
            IsGrounded = true;
        else
            IsGrounded = false;
    }

    private void PhysicsUpdate()
    {
        if (!_enableMovement) return;

        if (IsJumping) 
        {
            Jump();

            if (_currentJumpFrames >= _maxJumpFrames)
            {
                IsJumping = false;
            }
            else
            {
                _currentJumpFrames++;
            }
        }

        if (_canMove) 
        {
            _rigidbody2D.velocity = new Vector2(MoveSpeed, _rigidbody2D.velocity.y);
        } 
      
        ApplyGravity();

        ClampFallSpeed();
    }

    private void Jump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
        
    }

    private void ApplyGravity() 
    {
        if (_rigidbody2D.velocity.y < 0)
        {
            _rigidbody2D.velocity += Vector2.up * Physics2D.gravity * _fallMultiplier * Time.fixedDeltaTime;
        }
        else if (_rigidbody2D.velocity.y > 0 && !Input.GetKey(_inputButton))
        {
            _rigidbody2D.velocity += Vector2.up * Physics2D.gravity * _lowFallMultiplier * Time.fixedDeltaTime;
        }
    }

    private void ClampFallSpeed()
    {
        if (_rigidbody2D.velocity.y < _maxFallSpeed)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _maxFallSpeed);
        }
    }

    public void FreezeMovement() 
    {
        _canMove = false;
        _rigidbody2D.velocity = new Vector2();
        _rigidbody2D.isKinematic = true;
    }

    public void KillPlayer() 
    { 
        FreezeMovement();
        GameManager.Instance.StartCoroutine("ResetScene");
    }

    public void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }

    public void Addspeed() 
    {
        if (MoveSpeed > 0) ++MoveSpeed;
        if (MoveSpeed < 0) --MoveSpeed;
    }
}
