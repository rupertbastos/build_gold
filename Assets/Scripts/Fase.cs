using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fase : MonoBehaviour {

    public GameObject player, fimDeFase;
    public GameObject c1, c2, c3, c4;
    public GameObject sXP, foto, iconFaceCharacter;
    public Text estrelas, cristais, moedas, total;
    public Text nome, xp, level;
    public Color cor;
    public AudioSource audioFase;
    public AudioSource audioClipFase;
    public AudioClip btVelocidadeClip;

    public Sprite BTVel1, BTVel2, BTVel3;

    public GameObject StageCompleto;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioFase = GameObject.FindGameObjectWithTag("AudioFase").GetComponent<AudioSource>();
        audioClipFase = GameObject.FindGameObjectWithTag("AudioClipFase").GetComponent<AudioSource>();
        GameController.instance.AtualizaFaseInicio(nome, xp, level, sXP, foto, cor, player, iconFaceCharacter);
    }

    private void Update()
    {
        Debug.LogWarning("Entrou aqui: " + player.GetComponent<Player>().estadoAtual);
        if(player.GetComponent<Player>().estadoAtual == EstadosPlayer.FimCaminhoCompleto)
        {
            Debug.LogWarning("Entrou aqui 2");
            StageCompleto.SetActive(true);
        }
    }

    private void Start()
    {
        audioFase.Play();
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
}
