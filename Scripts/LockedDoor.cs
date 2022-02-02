using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
     if (GameManager.Instance.PlayerHasKey) UnlockDoor();   
    }

    private void UnlockDoor()
    {
        //play animation
        //play satisfying sound
        Destroy(gameObject);
    }
}
