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

        Debug.LogWarning("Entrou aqui: " + player.GetComponent<Player>().estadoAtual);
        if(player.GetComponent<Player>().estadoAtual == EstadosPlayer.FimCaminhoCompleto)
        {
            Debug.LogWarning("Entrou aqui 2");
            canvasStageCompleto.SetActive(true);
            player.GetComponent<Player>().estadoAtual = EstadosPlayer.Fim;
        }
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
