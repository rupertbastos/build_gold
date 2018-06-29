﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void AcaoBotaoMainMenu(string opcao)
    {
        switch (opcao)
        {
            case "NovoJogo":
                {
                    GameController.instance.ExecutaSomContinuar();
                    SceneManager.LoadScene("02_NovoJogo_Entrada_Dados");
                    break;
                }

            case "Continuar":
                {
                    GameController.instance.ExecutaSomContinuar();
                    //SceneManager.LoadScene("02_CarregarJogo");
                    break;
                }

            case "Creditos":
                {
                    GameController.instance.ExecutaSomContinuar();
                    Debug.Log("Creditos");
                    break;
                }
            case "Sair":
                {
                    GameController.instance.ExecutaSomVoltar();
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
