using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NovoJogoEntradaDados : MonoBehaviour {

    public Text nome;
    public GameObject canvasNome, canvasAvatar;
    public Button btContinuarAvatar, btNovaCena, btPlayer, btCor;
    
    void Start()
    {
        btPlayer = null;
        btCor = null;
    }

    void Update() {
        if (nome.text.ToString().Length > 0)
        {
            btContinuarAvatar.interactable = true;
        }
        else
        {
            btContinuarAvatar.interactable = false;
        }

        if (btPlayer != null && btCor != null)
        {
            btNovaCena.interactable = true;
        }
        else
        {
            btNovaCena.interactable = false;
        }

    }

    public void AcaoBotaoNovoJogoEntrada_Dados(string opcao)
    {
        switch (opcao)
        {
            case "Continuar":
                {
                    GameController.instance.ExecutaSomContinuar();
                    Debug.LogWarning("Nome: " + nome.text.ToString().ToUpper());
                    canvasNome.SetActive(false);
                    canvasAvatar.SetActive(true);
                    
                    
                    break;
                }
            case "Voltar":
                {
                    GameController.instance.ExecutaSomVoltar();
                    SceneManager.LoadScene("01_MainMenu");
                    break;
                }
            case "Voltar2":
                {
                    GameController.instance.ExecutaSomVoltar();
                    canvasNome.SetActive(true);
                    canvasAvatar.SetActive(false);
                    btPlayer = null;
                    btCor = null;
                    break;
                }
            case "Avançar":
                {
                    GameController.instance.ExecutaSomContinuar();
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

    public void SelecionaPlayer(GameObject go)
    {
        btPlayer = (Button) go.GetComponent<Button>();
        Debug.LogWarning(btPlayer.name);
    }

    public void SelecionaCor(GameObject go)
    {
        btCor = (Button)go.GetComponent<Button>();
        Debug.LogWarning(btPlayer.name);
    }
}
