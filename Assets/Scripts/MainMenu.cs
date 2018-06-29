using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public AudioClip audioBotaoClique;


    public void AcaoBotaoMainMenu(string opcao)
    {
        switch (opcao)
        {
            case "NovoJogo":
                {
                    SceneManager.LoadScene("02_NovoJogo_Entrada_Dados");
                    break;
                }

            case "Continuar":
                {
                    //SceneManager.LoadScene("02_CarregarJogo");
                    break;
                }

            case "Creditos":
                {
                    Debug.Log("Creditos");
                    break;
                }
            case "Sair":
                {
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
