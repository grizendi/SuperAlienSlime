using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float _trampolineForce;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            //player.IsJumping = true;
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, _trampolineForce));


        }
    }



}
