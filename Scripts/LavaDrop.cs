using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDrop : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private Vector3 _initPosition;
    private Quaternion _initRotation;

    private Collider2D _collider;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _initPosition = transform.position;
        _initRotation = transform.rotation;


    }


    private void OnDestroy()
    {
        Instantiate(gameObject, _initPosition, _initRotation);
    }
}
