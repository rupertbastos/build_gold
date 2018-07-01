using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fase : MonoBehaviour {

    public GameObject player;
    public GameObject c1, c2, c3, c4;
    public GameObject sXP, foto;
    public Text estrelas, cristais, moedas, total;
    public Text nome, xp, level;
    public Color cor;
    public AudioSource audioFase;
    
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioFase = GameObject.FindGameObjectWithTag("AudioFase").GetComponent<AudioSource>();
        GameController.instance.AtualizaFaseInicio(nome, xp, level, sXP, foto, cor, player);
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
}
