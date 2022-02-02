using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGoal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Player>().FreezeMovement();
        GameManager.Instance.StartCoroutine("LoadNextScene");

    }

}
