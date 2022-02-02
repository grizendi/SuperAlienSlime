using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : MonoBehaviour
{

    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _movementSpeed = 1.5f;

    [SerializeField] private Collider2D _leftGroundChecker;
    [SerializeField] private Collider2D _rightGroundChecker;
    [SerializeField] private Collider2D _weakSpot;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private LayerMask _playerLayerMask;

    private bool _canMove = true;
    private bool _harmless = false;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _leftGroundChecker.transform.parent = null;
        _rightGroundChecker.transform.parent = null;
    }

    private void FixedUpdate()
    {
        if(_canMove)
        _rigidbody2D.velocity = new Vector2(_movementSpeed, _rigidbody2D.velocity.y);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == _leftGroundChecker || collision.collider == _rightGroundChecker)
        {
            transform.Rotate(0f, 180f, 0f);
            _movementSpeed = -_movementSpeed;
        }

        if(collision.gameObject.TryGetComponent<Player>(out Player player) && !_harmless) 
        {
            player.KillPlayer();
        }
    
    }

    public void Die()
    {
        //play death animation
        _harmless = true;
        GameManager.Instance.AddScore();
        _canMove = false;
        //GetComponent<Collider2D>().enabled = false;
        transform.transform.position = new Vector3(transform.position.x, -0.5f, transform.position.z);
        transform.localScale = new Vector3(transform.localScale.x, 0.1f, transform.position.z);

        Destroy(gameObject,1f);
    }
}
