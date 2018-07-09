using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fase : MonoBehaviour
{

    public GameObject[] listaMoedas;
    //public GameObject[] itensFasesTodos;


    public GameObject player, fimDeFase;
    public Vector3 posInicialPlayer;
    public GameObject c1, c2, c3, c4;
    public GameObject sXP, foto, iconFaceCharacter;
    public Text estrelas, cristais, moedas, total;
    public string estrelasTxt, cristaisTxt, moedasTxt, totalTxt;
    public Text nome, xp, level;
    public Color cor;
    public AudioSource audioFase;
    public AudioSource audioPause;
    public AudioSource audioClipFase;
    public AudioClip btVelocidadeClip;

    public Sprite BTVel1, BTVel2, BTVel3;

    public GameObject canvasStageCompleto, canvasPause, canvasInGame, canvasGameOver;

    public bool mostraMoedas;

    public Slot[] slotsMovimentoIncial;
    public Slot[] slotsMovimentosPlay;
    public Slot[] slotsZerado;

    public GameObject painelWork;
    public GameObject painelInventario;

    public string[] movimentos;

    public GameObject btnPlay, btnVel;

    public float delay;
    public bool entraDelay, podeJogar, fimDeRodada, estaPausado;
    public int movPos;
    public float pos, speed;
    public int direcao;
    public float countdown, countdownIncial;
    public float timeCountdown;
	public float forcaPuloX;
	public float forcaPuloY;
    public GameObject playerColisorFim;
    public GameObject playerColetador;
    public GameObject cristalFim;


    public GameObject txtPontosFim;
    public GameObject txtCristalFim;
    public GameObject txtMoedaFim;
    public GameObject txtPontosTotalFaseFim;
    public GameObject scrollXPEstagioCompleto;
    public GameObject txtLevel;
    public EstadosPlayer estadoAnterior;

    public GameObject ListaBTMetodos, PainelMovimento, PainelRepeticao;

    public GameObject[] coracoes;
    public int vidas;

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
        estadoAnterior = player.GetComponent<Player>().estadoAtual;

        listaMoedas = GameObject.FindGameObjectsWithTag("Coin");

        /*foreach (GameObject m in listaMoedas)
        {
            m.gameObject.SetActive(mostraMoedas);
        }*/
        //audioPause = GameObject.FindGameObjectWithTag("AudioPause").GetComponent<AudioSource>();
        painelWork = GameObject.FindGameObjectWithTag("PainelBtWorkstation");
        painelInventario = GameObject.FindGameObjectWithTag("PainelMetodos");
        
        slotsZerado = painelWork.GetComponentsInChildren<Slot>();
        btnPlay = GameObject.FindGameObjectWithTag("BtPlay");
        btnVel = GameObject.FindGameObjectWithTag("BtVel");
        podeJogar = false;
        direcao = 1;
        countdown = timeCountdown;
        countdownIncial = timeCountdown + 5;
        fimDeRodada = false;
        cristalFim.SetActive(false);
        estaPausado = false;
        coracoes = GameObject.FindGameObjectsWithTag("Coracao");
    }

    

    private void Update()
    {
        if (estaPausado == false){
            movimentos = painelInventario.GetComponent<Inventory>().ListarMovimentos();
            if (movimentos.Length > 1 && podeJogar == false)
            {
                btnPlay.GetComponent<Button>().interactable = true;
            }
            else
            {
                btnPlay.GetComponent<Button>().interactable = false;
            }

            if (MostraCristal())
            {
                cristalFim.SetActive(true);
            }


            VerificaMoedasFases();


            if (entraDelay)
            {
                countdown -= Time.deltaTime;
                if (countdown <= 0.0f)
                {
                    entraDelay = false;
                    if (fimDeRodada)
                    {
                        VerificaResultado();
                    }
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
        }
		
    }

    private void VerificaResultado()
    {
        bool capturado = cristalFim.GetComponent<Item>().capturado;
        if (capturado == true)
        {
            Debug.Log("Cristal foi Capturado - Fim");

            canvasStageCompleto.SetActive(true);
            scrollXPEstagioCompleto = GameObject.FindGameObjectWithTag("ScrollEstagioCompleto");
            txtLevel = GameObject.FindGameObjectWithTag("LevelEstagioCompleto");
            txtPontosFim.GetComponent<Text>().text = (int.Parse(total.text) + 100).ToString();
            txtCristalFim.GetComponent<Text>().text = cristais.text;
            txtMoedaFim.GetComponent<Text>().text = moedas.text;
            int val = int.Parse(txtPontosFim.GetComponent<Text>().text) * 2;
            Debug.Log(val);
            txtPontosTotalFaseFim.GetComponent<Text>().text = val.ToString();

            //GameController.instance.AtualizaXPEstagioCompleto(val, scrollXPEstagioCompleto, txtLevel.GetComponent<Text>());

        }
        else if(capturado == false)
        {
            if(player.GetComponent<Player>().colisorFim == true)
            {
                canvasStageCompleto.SetActive(true);
                scrollXPEstagioCompleto = GameObject.FindGameObjectWithTag("ScrollEstagioCompleto");
                txtLevel = GameObject.FindGameObjectWithTag("LevelEstagioCompleto");
                txtPontosFim.GetComponent<Text>().text = (int.Parse(total.text) + 100).ToString();
                txtCristalFim.GetComponent<Text>().text = cristais.text;
                txtMoedaFim.GetComponent<Text>().text = moedas.text;
                int val = int.Parse(txtPontosFim.GetComponent<Text>().text);
                Debug.Log(val);
                txtPontosTotalFaseFim.GetComponent<Text>().text = val.ToString();

                //GameController.instance.AtualizaXPEstagioCompleto(val, scrollXPEstagioCompleto, txtLevel.GetComponent<Text>());
            }
            else
            {
                ReiniciarFase();
                Debug.Log("Não chegou ao fim da fase!");
                if(GameController.instance.perfilAtivo.GetVidas() == 1)
                {
                    audioFase.Stop();
                    canvasInGame.SetActive(false);
                    canvasGameOver.SetActive(true);
                }
                else
                {
                    GameController.instance.perfilAtivo.DiminuiVida();
                    RemoveCoracao(GameController.instance.perfilAtivo.GetVidas());
                    ReiniciarFase();
                }
            }
        }
    }

    

    private void RemoveCoracao(int v)
    {
        switch (v)
        {
            case 3:
                {
                    foreach(GameObject obj in coracoes)
                    {
                        string[] name = obj.name.Split('-');

                        if (name[3].CompareTo("1") == 0)
                        {
                            obj.SetActive(false);
                        }
                    }
                    break;
                }
            case 2:
                {
                    foreach (GameObject obj in coracoes)
                    {
                        string[] name = obj.name.Split('-');

                        if (name[3].CompareTo("2") == 0)
                        {
                            obj.SetActive(false);
                        }
                    }
                    break;
                }
                case 1:
                {
                    foreach (GameObject obj in coracoes)
                    {
                        string[] name = obj.name.Split('-');

                        if (name[3].CompareTo("3") == 0)
                        {
                            obj.SetActive(false);
                        }
                    }
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    private void ReiniciarFase()
    {
        player.GetComponent<Transform>().position = posInicialPlayer;
        movPos = 0;
        podeJogar = false;
    }

    private void VerificaMoedasFases()
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
    }

    private bool MostraCristal()
    {
        foreach (GameObject go in listaMoedas)
        {
            if (go.GetComponent<Item>().capturado == false)
            {
                return false;
            }
        }
        return true;
    }

    private void ExecutaMovimento(string v)
    {
        switch (v)
        {
            case "Mover":
                {
                    Debug.Log("Mover");
                    //player.GetComponent<Player>().estadoAtual = EstadosPlayer.Movendo;
                    player.GetComponent<Rigidbody2D>().AddForce(new Vector2((GetComponent<Transform>().transform.position.x + pos) * direcao, GetComponent<Transform>().transform.position.y));
                    countdown = timeCountdown;
                    entraDelay = true;
                    break;
                }
		    case "Pular":
			    {
                    Debug.Log("Pular");
                    player.GetComponent<Player>().estadoAtual = EstadosPlayer.Pulando;
				    player.GetComponent<Rigidbody2D>().AddForce(new Vector2((forcaPuloX * direcao), forcaPuloY));
                    countdown = timeCountdown;
                    entraDelay = true;
				    break;
			    }

            case "Pegar":
                {
                    Debug.Log("Pegar");
                    player.GetComponent<Player>().estadoAtual = EstadosPlayer.Pegando;
                    playerColetador.GetComponent<BoxCollider2D>().enabled = true;
                    countdown = timeCountdown;
                    entraDelay = true;
                    break;
                }
            case "Fim":
                {
                    player.GetComponent<Player>().estadoAtual = EstadosPlayer.Parado;
                    Debug.Log("Fim da rodada");
                    countdown = 1.5f;
                    entraDelay = true;
                    fimDeRodada = true;
                    podeJogar = false;
                    break;
                }
            case "Pause":
                {
                    player.GetComponent<Player>().estadoAtual = EstadosPlayer.Pausado;
                    estadoAnterior = player.GetComponent<Player>().estadoAtual;
                    Debug.Log("Entrou em Pause");
                    break;
                }
            case "Resumir":
                {
                    player.GetComponent<Player>().estadoAtual = estadoAnterior;
                    Debug.Log("Entrou em Pause");
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
        ListaBTMetodos.SetActive(false);
        PainelMovimento.SetActive(false);
        PainelRepeticao.SetActive(false);
        podeJogar = true;
        //delayInicial = true;

        //Debug.Log(movimentos[0].ToString());
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

    public void ReiniciarFaseTotal()
    {
        string nomeFase = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(nomeFase);
        
    }

    public void AcaoBotaoPause(GameObject go)
    {
        if (go.activeSelf == false)
        {
            estaPausado = true;
            go.SetActive(true);
            //GameObject player = GameObject.FindGameObjectWithTag("Player");
            audioPause = GameObject.FindGameObjectWithTag("AudioPause").GetComponent<AudioSource>();
            player.GetComponent<Player>().Pause();
            audioPause.Play();
            audioFase.Pause();
        }
    }

    public void AcaoBotaoResume(GameObject go)
    {
        if (go.activeSelf == true)
        {
            estaPausado = false;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Player>().Despause();
            go.SetActive(false);
            audioPause.Stop();
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
            AlteraVelocidade(2);
        }
        else if (go.GetComponent<Button>().GetComponent<Image>().sprite.name.CompareTo("btn-speed-x2") == 0)
        {
            go.GetComponent<Button>().GetComponent<Image>().sprite = BTVel3;
            AlteraVelocidade(1);
        }
        else if (go.GetComponent<Button>().GetComponent<Image>().sprite.name.CompareTo("btn-speed-x3") == 0)
        {
            go.GetComponent<Button>().GetComponent<Image>().sprite = BTVel1;
            AlteraVelocidade(3);
        }

    }

    public void AlteraVelocidade(float vel)
    {
        timeCountdown = vel;
    }

    public void Home()
    {
        SceneManager.LoadScene("03_01_SelectTowers");
        //SceneManager.LoadScene("03_02_SelecaoFases");
    }

    
}
