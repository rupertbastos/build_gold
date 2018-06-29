using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectTowers : MonoBehaviour {

    public void AcaoBotaoSelectTowers(string opcao)
    {
        switch (opcao)
        {

            case "Voltar":
                {
                    SceneManager.LoadScene("02_CarregarJogo");
                    break;
                }

            case "Madeira":
                {
                    SceneManager.LoadScene("03_02_SelecaoFases");
                    break;
                }
            
            case "Concreto":
                {
                    Debug.LogWarning("Concreto");
                    break;
                }
            case "Jade":
                {
                    Debug.LogWarning("Jade");
                    break;
                }
            case "Gelo":
                {
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
