using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasePlayerSpeed : MonoBehaviour
{
    private bool _hasRun;

    private void Start()
    {
        _hasRun = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.TryGetComponent<Player>(out Player player) && !_hasRun)
        {
            GameManager.Instance.AddLightningCounter();
            player.Addspeed(); ;
            _hasRun = true;
        }
    }

}
