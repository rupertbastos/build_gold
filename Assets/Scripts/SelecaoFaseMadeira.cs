using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelecaoFaseMadeira : MonoBehaviour {

    public void AcaoBotaoSelecaoFaseWood(int i)
    {
        switch (i)
        {
            case 1:
                {
                    //SceneManager.LoadScene("04_01_towerWood");
                    GameController.instance.ExecutaSomContinuar();
                    SceneManager.LoadScene("04_01_towerWood_TESTE");
                    break;
                }

            case 2:
                {
                    GameController.instance.ExecutaSomContinuar();
                    SceneManager.LoadScene("04_02_towerWood");
                    break;
                }
            case -1:
                {
                    GameController.instance.ExecutaSomVoltar();
                    SceneManager.LoadScene("03_01_SelectTowers");
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
