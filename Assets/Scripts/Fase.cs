using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fase : MonoBehaviour {

    public GameObject[] listaMoedas;
    public GameObject[] itensFasesTodos;


    public GameObject player, fimDeFase;
    public Vector3 posInicialPlayer;
    public GameObject c1, c2, c3, c4;
    public GameObject sXP, foto, iconFaceCharacter;
    public Text estrelas, cristais, moedas, total;
    public string estrelasTxt, cristaisTxt, moedasTxt, totalTxt;
    public Text nome, xp, level;
    public Color cor;
    public AudioSource audioFase;
    public AudioSource audioClipFase;
    public AudioClip btVelocidadeClip;

    public Sprite BTVel1, BTVel2, BTVel3;

    public GameObject canvasStageCompleto, canvasPause, canvasInGame, canvasGameOVer;

    public bool mostraMoedas;

    public Slot[] slotsMovimentoIncial;
    public Slot[] slotsMovimentosPlay;
    public Slot[] slotsZerado;

    public GameObject painelWork;
    public GameObject painelInventario;

    public string[] movimentos;

    public GameObject btnPlay, btnVel;

    public float delay;
    public Boolean entraDelay, podeJogar, delayInicial;
    public int movPos;
    public float pos, speed;
    public int direcao;
    public float countdown, countdownIncial;
    public float timeCountdown;

    private void Awake()
    {
        estrelasTxt = estrelas.text;
        cristaisTxt = cristais.text;
        moedasTxt = moedas.text;
        totalTxt = total.text;


        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Transform>().position = posInicialPlayer;
        audioFase = GameObject.FindGameObjectWithTag("AudioFase").GetComponent<AudioSource>();
        audioClipFase = GameObject.FindGameObjectWithTag("AudioClipFase").GetComponent<AudioSource>();
        GameController.instance.AtualizaFaseInicio(nome, xp, level, sXP, foto, cor, player, iconFaceCharacter);
    }

    private void Start()
    {
        audioFase.Play();
        

        listaMoedas = GameObject.FindGameObjectsWithTag("Coin");

        /*foreach (GameObject m in listaMoedas)
        {
            m.gameObject.SetActive(mostraMoedas);
        }*/

        painelWork = GameObject.FindGameObjectWithTag("PainelBtWorkstation");
        painelInventario = GameObject.FindGameObjectWithTag("PainelMetodos");
        slotsZerado = painelWork.GetComponentsInChildren<Slot>();
        btnPlay = GameObject.FindGameObjectWithTag("BtPlay");
        btnVel = GameObject.FindGameObjectWithTag("BtVel");
        podeJogar = false;
        direcao = 1;
        countdown = timeCountdown;
        countdownIncial = timeCountdown + 5;
    }

    private void Update()
    {

        if (mostraMoedas)
        {
            foreach (GameObject m in listaMoedas)
            {
                m.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject m in listaMoedas)
            {
                m.gameObject.SetActive(true);
            }
        }

        //Debug.LogWarning("Entrou aqui: " + player.GetComponent<Player>().estadoAtual);
        if(player.GetComponent<Player>().estadoAtual == EstadosPlayer.FimCaminhoCompleto)
        {
            Debug.LogWarning("Entrou aqui 2");
            canvasStageCompleto.SetActive(true);
            player.GetComponent<Player>().estadoAtual = EstadosPlayer.Fim;
        }

        /*if (delayInicial)
        {
            countdownIncial -= Time.deltaTime;
            if (countdownIncial <= 0.0f)
            {
                delayInicial = false;
            }
        }
        else
        {*/
            if (entraDelay)
            {
                countdown -= Time.deltaTime;
                if (countdown <= 0.0f)
                {
                    entraDelay = false;
                }
            }
            else
            {
                if (podeJogar)
                {
                    entraDelay = true;
                    ExecutaMovimento(ProximoMovimento());

                }
            }
        //}
        

        


    }

    private void ExecutaMovimento(string v)
    {
        switch (v)
        {
            case "Mover":
                {
                    player.GetComponent<Player>().estadoAtual = EstadosPlayer.Movendo;
                    player.GetComponent<Rigidbody2D>().AddForce(new Vector2((GetComponent<Transform>().transform.position.x + pos) * direcao, GetComponent<Transform>().transform.position.y));
                    
                    entraDelay = true;
                    break;
                }
            case "Fim":
                {
                    player.GetComponent<Player>().estadoAtual = EstadosPlayer.Parado;
                    Debug.Log("Fim da rodada");
                    podeJogar = false;
                    break;
                }
            default:
                player.GetComponent<Player>().estadoAtual = EstadosPlayer.Parado;
                break;
        }
            
        
    }

    public void Play()
    {
        movimentos = painelInventario.GetComponent<Inventory>().ListarMovimentos();
        btnPlay.GetComponent<Button>().interactable = false;
        btnVel.GetComponent<Button>().interactable = false;

        podeJogar = true;
        //delayInicial = true;

        Debug.Log(movimentos[0].ToString());

        

    }

    

    private string ProximoMovimento()
    {
        string moveTxt = movimentos[movPos].ToString();
        movPos = movPos + 1;

       

        return (moveTxt.Trim());
    }

    public void ReiniciarFase(GameObject go)
    {
        Debug.LogWarning("Reniciou");
        if (go.activeSelf == true)
        {
            audioFase.Play();
            estrelas.text = estrelasTxt;
            cristais.text = cristaisTxt;
            moedas.text = moedasTxt;
            total.text = totalTxt;
            player.GetComponent<Transform>().position = posInicialPlayer;
            foreach (GameObject m in listaMoedas)
            {
                m.gameObject.SetActive(true);
                m.GetComponent<Renderer>().enabled = true;
                m.GetComponent<CircleCollider2D>().enabled = true;
                Debug.LogWarning("Entrou aqui");
            }
        }
        go.SetActive(false);
    }


    public void AcaoBotaoPause(GameObject go)
    {
        if (go.activeSelf == false)
        {
            go.SetActive(true);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Player>().Pause();
            audioFase.Pause();
        }
    }

    public void AcaoBotaoResume(GameObject go)
    {
        if (go.activeSelf == true)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Player>().Despause();
            go.SetActive(false);
            audioFase.Play();
        }
    }

    public void AcaoBotaoOpenTips(GameObject go)
    {
        if (go.activeSelf == false)
        {
            go.gameObject.SetActive(true);
        }
        else
        {
            go.gameObject.SetActive(false);
        }
    }

    public void AcaoBotaoVel(GameObject go)
    {
        audioClipFase.clip = btVelocidadeClip;
        audioClipFase.Play();
        if (go.GetComponent<Button>().GetComponent<Image>().sprite.name.CompareTo("btn-speed-x1") == 0)
        {
            go.GetComponent<Button>().GetComponent<Image>().sprite = BTVel2;
            player.GetComponent<Player>().AlteraVelocidade(2);
        }
        else if (go.GetComponent<Button>().GetComponent<Image>().sprite.name.CompareTo("btn-speed-x2") == 0)
        {
            go.GetComponent<Button>().GetComponent<Image>().sprite = BTVel3;
            player.GetComponent<Player>().AlteraVelocidade(1);
        }
        else if (go.GetComponent<Button>().GetComponent<Image>().sprite.name.CompareTo("btn-speed-x3") == 0)
        {
            go.GetComponent<Button>().GetComponent<Image>().sprite = BTVel1;
            player.GetComponent<Player>().AlteraVelocidade(3);
        }

    }

    public void Home()
    {
        SceneManager.LoadScene("03_01_SelectTowers");
        //SceneManager.LoadScene("03_02_SelecaoFases");
    }
}
