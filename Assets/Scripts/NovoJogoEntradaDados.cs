using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NovoJogoEntradaDados : MonoBehaviour {

    public Text nome;
    public GameObject canvasNome, canvasAvatar;
    public Button btContinuarAvatar, btNovaCena, btPlayer, btCor;
    public Sprite sp1, sp2, sp3, sp4, sp5, sp6;
    public Perfil p;


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
                    ConfiguraPerfil();
                    GameController.instance.ExecutaSomContinuar();
                    GameController.instance.SetPerfilAtivo(p);
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

    private void ConfiguraPerfil()
    {

        Sprite sp;

        switch (btPlayer.name)
        {
            case ":: bt - avatar 01":
                {
                    sp = sp1;
                    break;
                }
            case ":: bt - avatar 02":
                {
                    sp = sp2;
                    break;
                }
            case ":: bt - avatar 03":
                {
                    sp = sp3;
                    break;
                }
            case ":: bt - avatar 04":
                {
                    sp = sp4;
                    break;
                }
            case ":: bt - avatar 05":
                {
                    sp = sp5;
                    break;
                }
            case ":: bt - avatar 06":
                {
                    sp = sp6;
                    break;
                }
            default:
                {
                    sp = sp1;
                    break;
                }
        }


        Color c;
        switch (btCor.name)
        {
            case ":: bt - cor (1)":
                {
                    c = new Color(0, 0, 0);
                    break;
                }
            case ":: bt - cor (2)":
                {
                    c = new Color(0, 0, 1);
                    break;
                }
            case ":: bt - cor (3)":
                {
                    c = new Color(0, 1, 0);
                    break;
                }
            case ":: bt - cor (4)":
                {
                    c = new Color(0, 1, 1);
                    break;
                }
            case ":: bt - cor (5)":
                {
                    c = new Color(1, 0, 0);
                    break;
                }
            case ":: bt - cor (6)":
                {
                    c = new Color(1, 0, 1);
                    break;
                }
            default:
                {
                    c = new Color(255, 255, 255);
                    break;
                }
        }

        p = new Perfil(nome.text.ToString().ToUpper(), sp, c);
        Debug.LogWarning(p.GetNome());
        Debug.LogWarning(p.GetImagem().name);
        Debug.LogWarning(p.GetCor().r + "," + p.GetCor().g + "," + p.GetCor().b);
    }

    public void SelecionaPlayer(GameObject go)
    {
        btPlayer = (Button) go.GetComponent<Button>();
        Debug.LogWarning(btPlayer.name);
    }

    public void SelecionaCor(GameObject go)
    {
        btCor = go.GetComponent<Button>();
        Debug.LogWarning(btCor.name);
    }
}
