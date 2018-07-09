using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IniciaJogo : MonoBehaviour
{
    
    void Update()
    {
        if (Input.anyKey)
        {
            //animator.SetBool("saida", true);
            SceneManager.LoadScene("01_MainMenu");
        }
    }

}