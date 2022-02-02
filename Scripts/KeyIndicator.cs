using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyIndicator : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Image>().enabled = false;
    }

    public void ShowKey() 
    {
        GetComponent<Image>().enabled = true;
    }

}
