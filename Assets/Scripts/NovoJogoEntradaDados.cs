using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NovoJogoEntradaDados : MonoBehaviour {

    public Text nome, nomeExibicao;
    public GameObject canvasNome, canvasAvatar, canvasConfirmacao;
    public Button btContinuarAvatar, btNovaCena, btPlayer, btCor;
    public Sprite sp, sp1, sp2, sp3, sp4, sp5, sp6;
    public Sprite spI, spI1, spI2, spI3, spI4, spI5, spI6;
    public Sprite spP, spP1, spP2, spP3, spP4, spP5, spP6;
    public Image avatar, icon, player;
    public Perfil p;
    public Color c;
    private int corNumber;

    void Start()
    {
        btPlayer = null;
        btCor = null;
        canvasNome.SetActive(true);
        canvasAvatar.SetActive(false);
        canvasConfirmacao.SetActive(false);
        nome.text = "";
        nomeExibicao.text = "";
        sp = null;
        p = null;
        c = new Color(0,0,0);
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
                    canvasNome.SetActive(false);
                    canvasAvatar.SetActive(true);
                    canvasConfirmacao.SetActive(false);
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
                    canvasConfirmacao.SetActive(false);
                    btPlayer = null;
                    btCor = null;
                    break;
                }
            case "Voltar3":
                {
                    GameController.instance.ExecutaSomVoltar();
                    canvasNome.SetActive(false);
                    canvasAvatar.SetActive(true);
                    canvasConfirmacao.SetActive(false);
                    break;
                }
            case "Avançar":
                {
                    ConfiguraPerfil();
                    GameController.instance.ExecutaSomContinuar();
                    canvasNome.SetActive(false);
                    canvasAvatar.SetActive(false);
                    canvasConfirmacao.SetActive(true);
                    nomeExibicao.text = p.GetNome();
                    avatar.GetComponent<Image>().sprite = sp;
                    icon.GetComponent<Image>().sprite = spI;
                    player.GetComponent<Image>().sprite = spP;
                    
                    break;
                }
            case "Avançar2":
                {
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

        switch (btCor.name)
        {
            case ":: bt - cor (1)":
                {
                    c = new Color(83,109,132);
                    spI = spI1;
                    spP = spP1;
                    corNumber = 1;
                    break;
                }
            case ":: bt - cor (2)":
                {
                    c = new Color(239,199,0);
                    spI = spI2;
                    spP = spP2;
                    corNumber = 2;
                    break;
                }
            case ":: bt - cor (3)":
                {
                    c = new Color(244,67,54);
                    spI = spI3;
                    spP = spP3;
                    corNumber = 3;
                    break;
                }
            case ":: bt - cor (4)":
                {
                    c = new Color(0, 218,243);
                    spI = spI4;
                    spP = spP4;
                    corNumber = 4;
                    break;
                }
            case ":: bt - cor (5)":
                {
                    c = new Color(173, 4, 255);
                    spI = spI5;
                    spP = spP5;
                    corNumber = 5;
                    break;
                }
            case ":: bt - cor (6)":
                {
                    c = new Color(16, 243, 0);
                    spI = spI6;
                    spP = spP6;
                    corNumber = 6;
                    break;
                }
            default:
                {
                    c = new Color(0, 0, 0);
                    spI = null;
                    spP = null;
                    corNumber = 1;
                    break;
                }
        }

        p = new Perfil(nome.text.ToString().ToUpper(), sp, c, spI, spP, corNumber);
    }

    public void SelecionaPlayer(GameObject go)
    {
        btPlayer = (Button) go.GetComponent<Button>();
    }

    public void SelecionaCor(GameObject go)
    {
        btCor = go.GetComponent<Button>();
    }
}
