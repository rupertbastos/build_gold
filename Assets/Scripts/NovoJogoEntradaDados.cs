using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NovoJogoEntradaDados : MonoBehaviour {

    public Text nome;
    public GameObject canvasNome, canvasAvatar;


    public void AcaoBotaoNovoJogoEntrada_Dados(string opcao)
    {
        switch (opcao)
        {
            case "Continuar":
                {
                    //SceneManager.LoadScene("03_01_SelectTowers");


                    if(nome.text.ToString().Length > 0)
                    {
                        Debug.LogWarning("Nome: " + nome.text.ToString().ToUpper());
                        canvasNome.SetActive(false);
                        canvasAvatar.SetActive(true);
                    }
                    else
                    {
                        Debug.LogWarning("Nome não pode ficar em branco!");
                    }
                    
                    break;
                }
            case "Voltar":
                {
                    SceneManager.LoadScene("01_MainMenu");
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
