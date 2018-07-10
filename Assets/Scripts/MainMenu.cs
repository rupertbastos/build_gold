using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private void Start()
    {
        if (GameController.instance.audioS.isPlaying)
        {
            if (GameController.instance.audioS.clip != GameController.instance.audioMenu)
            {
                GameController.instance.audioS.clip = GameController.instance.audioMenu;
                GameController.instance.audioS.loop = true;
                GameController.instance.audioS.Play();
            }
        }
        else
        {
            GameController.instance.audioS.clip = GameController.instance.audioMenu;
            GameController.instance.audioS.loop = true;
            GameController.instance.audioS.Play();
        }
    }

    public void AcaoBotaoMainMenu(string opcao)
    {
        switch (opcao)
        {
            case "NovoJogo":
                {
                    GameController.instance.ExecutaClip("Ir");
                    SceneManager.LoadScene("02_01_NovoJogo");
                    break;
                }

            case "Continuar":
                {
                    GameController.instance.ExecutaClip("Ir");
                    //SceneManager.LoadScene("02_CarregarJogo");
                    break;
                }

            case "Creditos":
                {
                    GameController.instance.ExecutaClip("Ir");
                    SceneManager.LoadScene("02_03_Credits");
                    break;
                }
            case "Sair":
                {
                    GameController.instance.ExecutaClip("Voltar");
                    Debug.Log("Sair");
                    Application.Quit();
                    break;
                }
            default:
                {
                    Debug.Log("Opção Inválida");
                    break;
                }
        }
    }

}
