using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpOnWall : MonoBehaviour
{
    private Collider2D _collider2D;
    private Player _player;

    [SerializeField] private LayerMask _groundLayerMask;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
        _player = GetComponentInParent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (_collider2D.IsTouchingLayers(_groundLayerMask))
        {
            _player.Flip();
            _player.MoveSpeed = -_player.MoveSpeed;
        }

    }
}
