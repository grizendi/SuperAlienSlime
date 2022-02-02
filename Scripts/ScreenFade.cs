using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFade : MonoBehaviour
{
    public Animator Animator;

    public static ScreenFade Instance;

    private void Awake()
    {
        Animator = GetComponent<Animator>();

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }




}
