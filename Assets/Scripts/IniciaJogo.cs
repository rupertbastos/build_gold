using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciaJogo : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        if (Input.anyKey)
        {
            animator.SetBool("saida", true);
        }
    }

}