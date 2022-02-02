using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            GameManager.Instance.AddKey();
            FindObjectOfType<KeyIndicator>().ShowKey();
            //feel good VFX
            Destroy(gameObject);
        }
    }
}
