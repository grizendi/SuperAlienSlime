using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuInput : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.StartCoroutine("LoadNextScene");
        }
    }


}
