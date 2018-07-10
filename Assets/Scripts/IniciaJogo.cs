using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IniciaJogo : MonoBehaviour
{

    private void Start()
    {
        if (GameController.instance.audioC.isPlaying)
        {
            if(GameController.instance.audioC.clip != GameController.instance.audioMenu)
            {
                GameController.instance.audioC.clip = GameController.instance.audioMenu;
                GameController.instance.audioC.loop = true;
                GameController.instance.audioC.Play();
            }
        }
        else
        {
            GameController.instance.audioC.clip = GameController.instance.audioMenu;
            GameController.instance.audioC.loop = true;
            GameController.instance.audioC.Play();
        }
    }

    void Update()
    {
        if (Input.anyKey)
        {
            //animator.SetBool("saida", true);
            SceneManager.LoadScene("01_MainMenu");
        }
    }

}