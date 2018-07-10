using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectTowers : MonoBehaviour {

    public Text porcentagem, estrelas, cristais, moedas, total, level;

    

    private void Start()
    {
        GameController.instance.AtualizaSelectTowers(porcentagem, estrelas, cristais, moedas, total, level);

        
    }

    public void AcaoBotaoSelectTowers(string opcao)
    {
        switch (opcao)
        {

            case "Voltar":
                {
                    GameController.instance.ExecutaClip("Voltar");
                    SceneManager.LoadScene("02_02_Continue");
                    break;
                }

            case "Madeira":
                {
                    GameController.instance.ExecutaClip("Torres");
                    SceneManager.LoadScene("03_02_SelecaoFases");
                    break;
                }
            
            case "Concreto":
                {
                    GameController.instance.ExecutaClip("Torres");
                    Debug.LogWarning("Concreto");
                    break;
                }
            case "Jade":
                {
                    GameController.instance.ExecutaClip("Torres");
                    Debug.LogWarning("Jade");
                    break;
                }
            case "Gelo":
                {
                    GameController.instance.ExecutaClip("Torres");
                    Debug.LogWarning("Gelo");
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
