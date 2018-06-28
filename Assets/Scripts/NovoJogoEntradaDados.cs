using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NovoJogoEntradaDados : MonoBehaviour {

    public string nome, sobreNome;


    public void AcaoBotaoNovoJogoEntrada_Dados(string opcao)
    {
        switch (opcao)
        {
            case "Continuar":
                {
                    //SceneManager.LoadScene("03_01_SelectTowers");



                    Debug.LogWarning("Nome: " + nome + " " + sobreNome);
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
