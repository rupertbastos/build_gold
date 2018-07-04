using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    //public GameObject listaBtMetodos;
    //public GameObject player;
    //public GameObject[] slots;
    //[SerializeField] Transform slots;

    private Transform slots;
    private Animator animator;
    private GameObject painelInventario;
    private GameObject painelWork;
    private GameObject btPlay;
    
    public EstadosPlayer estadoAtual, estadoPausado;
    //public GameObject audioS;
    //public Slider sliderVelocidadePlayer;

    public string[] metodos;
    public IList<string> comandosFinalList;
    public float pos, speed;
    public bool executaPlay = false;
    public bool delayLiberado = false;
    public int movimentos, totalMovimentos;
    public float countdown;
    public float timeCountdown;
    public float forcaPuloX = 35;
    public float forcaPuloY = 200f;

    public int direcao;

    public IList<int> pintarSlots = new List<int>();

    public Slot[] slotsWork;
    public int jogadaCount = 0;
    public int iniFor = 0;
    public int fimFor = 0;

    public GameObject coletador;

    public AudioSource audioClipFase;
    public AudioClip playClip;

    public AnimatorOverrideController animatorOverrideController;
    
    public AnimationClip acIdle01, acIdle02, acIdle03, acIdle04, acIdle05, acIdle06;
    public AnimationClip acWalk01, acWalk02, acWalk03, acWalk04, acWalk05, acWalk06;
    public AnimationClip acRun01, acRun02, acRun03, acRun04, acRun05, acRun06;
    public AnimationClip acJump01, acJump02, acJump03, acJump04, acJump05, acJump06;
    public AnimationClip acDeath01, acDeath02, acDeath03, acDeath04, acDeath05, acDeath06;
    public AnimationClip acDropAttack01, acDropAttack02, acDropAttack03, acDropAttack04, acDropAttack05, acDropAttack06;
    public AnimationClip acFrontAttack01, acFrontAttack02, acFrontAttack03, acFrontAttack04, acFrontAttack05, acFrontAttack06;
    public AnimationClip acLadder01, acLadder02, acLadder03, acLadder04, acLadder05, acLadder06;
    public int animCont;

    void Start()
    {
        estadoPausado = EstadosPlayer.Parado;
        estadoAtual = EstadosPlayer.Parado;
        animator = GetComponent<Animator>();
        //audioS = GameObject.FindGameObjectWithTag("Audio");
        painelInventario = GameObject.FindGameObjectWithTag("PainelMetodos");
        painelWork = GameObject.FindGameObjectWithTag("PainelBtWorkstation");
        slots = painelWork.GetComponent<Transform>();
        btPlay = GameObject.FindGameObjectWithTag("BtPlay");
        coletador = GameObject.FindGameObjectWithTag("Coletador");
        //sliderVelocidadePlayer = GameObject.FindGameObjectWithTag("SliderVelocidadePlayer").GetComponent<Slider>();
        countdown = timeCountdown;
        direcao = 1;
        audioClipFase = GameObject.FindGameObjectWithTag("AudioClipFase").GetComponent<AudioSource>();
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;
        //Debug.LogWarning(animCont);
        SetCorDoPlayer(animCont);
    }

    void Update()
    {
        metodos = painelInventario.GetComponent<Inventory>().ListarMovimentos();
        if (metodos.Length > 1 && executaPlay == false)
        {
            btPlay.GetComponent<Button>().interactable = true;
        }
        else
        {
            btPlay.GetComponent<Button>().interactable = false;
        }

        if (estadoAtual != EstadosPlayer.Parado)
        {
            countdown -= Time.deltaTime;
        }

        if (executaPlay)
        {
            if(estadoAtual != EstadosPlayer.Pausado)
            {
                if (movimentos <= totalMovimentos + 1)
                {
                    switch (estadoAtual)
                    {
                        case EstadosPlayer.Aguardando:
                            {
                                Debug.Log("Aguardando comando");
                                VerificaProximoMovimento();
                                break;
                            }
                        case EstadosPlayer.Movendo:
                            {
                                animator.SetBool("playerParado", false);
                                animator.SetBool("playerCaminhando", true);
                                Debug.Log("Movimentou o personagem");

                                GetComponent<Rigidbody2D>().AddForce(new Vector2((GetComponent<Transform>().transform.position.x + pos) * direcao, GetComponent<Transform>().transform.position.y));
                                //Debug.Log(GetComponent<Transform>().position.x);

                                VerificaProximoMovimento();
                                break;
                            }
                        case EstadosPlayer.Pulando:
                            {
                                animator.SetBool("playerParado", false);
                                animator.SetBool("playerPulando", true);
                                Debug.Log("Pulou o personagem");
                                GetComponent<Rigidbody2D>().AddForce(new Vector2(forcaPuloX * direcao, forcaPuloY));
                                VerificaProximoMovimento();
                                break;
                            }
                        case EstadosPlayer.Delay:
                            {
                                animator.SetBool("playerParado", true);
                                animator.SetBool("playerCaminhando", false);
                                animator.SetBool("playerPulando", false);

                                if (countdown <= 0.0f)
                                {
                                    delayLiberado = true;
                                    Debug.Log("Deley personagem");
                                }

                                if (delayLiberado)
                                {
                                    Debug.Log("Fim do deley personagem");
                                    delayLiberado = false;
                                    if (coletador.GetComponent<BoxCollider2D>().enabled)
                                    {
                                        coletador.GetComponent<BoxCollider2D>().enabled = false;
                                    }
                                    VerificaProximoMovimento();
                                }

                                break;
                            }
                        /*case EstadosPlayer.Parado:
                            {
                                //Debug.Log("Fim da Rodada");
                                //btPlay.GetComponent<Button>().interactable = true;
                                //executaPlay = false;
                                break;
                            }*/

                        case EstadosPlayer.Pegando:
                            {
                                coletador.GetComponent<BoxCollider2D>().enabled = true;
                                VerificaProximoMovimento();
                                break;
                            }
                        case EstadosPlayer.Morto:
                            {
                                Debug.Log("Merreu");
                                // btPlay.GetComponent<Button>().interactable = true;
                                executaPlay = false;
                                animator.SetBool("playerParado", false);
                                animator.SetBool("playerMorto", true);
                                break;
                            }
                        case EstadosPlayer.Fim:
                            {
                                Debug.Log("Fim da Rodada");
                                executaPlay = false;
                                VerificaFimRodada();
                                break;
                            }
                        case EstadosPlayer.FimCaminhoCompleto:
                            {
                                Debug.Log("Fim do Estagio: " + estadoAtual);
                                executaPlay = false;
                                break;
                            }
                        case EstadosPlayer.VirarDireita:
                            {
                                direcao = 1;
                                GetComponent<SpriteRenderer>().flipX = false;
                                Debug.Log("Virou: Direita");
                                VerificaProximoMovimento();
                                break;
                            }
                        case EstadosPlayer.VirarEsquerda:
                            {
                                direcao = -1;
                                GetComponent<SpriteRenderer>().flipX = true;
                                Debug.Log("Virou: Direita");
                                VerificaProximoMovimento();
                                break;
                            }
                        default:
                            {
                                Debug.Log("Opção inválida: " + estadoAtual);
                                break;
                            }
                    }

                }
            }
            else
            {
                executaPlay = false;
            }

        }


    }

    private void VerificaFimRodada()
    {
        btPlay.GetComponent<Button>().interactable = true;
        //sliderVelocidadePlayer.interactable = true;
    }

    private void VerificaProximoMovimento()
    {
        if (comandosFinalList[movimentos].ToString() == "Mover")
        {
            //Debug.Log("Mover");
            estadoAtual = EstadosPlayer.Movendo;

        }
        else if (comandosFinalList[movimentos].ToString() == "Pular")
        {
            //Debug.Log("Pular");
            estadoAtual = EstadosPlayer.Pulando;
        }
        else if (comandosFinalList[movimentos].ToString() == "Pegar")
        {
            //Debug.Log("Pegar");
            estadoAtual = EstadosPlayer.Pegando;
        }
        else if (comandosFinalList[movimentos].ToString() == "Delay")
        {
            PintarSlot(jogadaCount);
            jogadaCount++;
            countdown = timeCountdown;
            estadoAtual = EstadosPlayer.Delay;
            //Debug.Log("Delay");
        }
        else if (comandosFinalList[movimentos].ToString() == "Fim")
        {
            estadoAtual = EstadosPlayer.Fim;
            //Debug.Log("Fim");
        }
        else if (comandosFinalList[movimentos].ToString() == "Repetir2x")
        {
            estadoAtual = EstadosPlayer.Aguardando;
            //Debug.Log("Parado");
        }
        else if (comandosFinalList[movimentos].ToString() == "FimFor2x")
        {
            estadoAtual = EstadosPlayer.Aguardando;
            //Debug.Log("Parado");
        }
        else if (comandosFinalList[movimentos].ToString() == "Repetir4x")
        {
            estadoAtual = EstadosPlayer.Aguardando;
            //Debug.Log("Parado");
        }
        else if (comandosFinalList[movimentos].ToString() == "FimFor4x")
        {
            estadoAtual = EstadosPlayer.Aguardando;
            //Debug.Log("Parado");
        }
        else if (comandosFinalList[movimentos].ToString() == "VirarDireita")
        {
            estadoAtual = EstadosPlayer.VirarDireita;
            //Debug.Log("Parado");
        }
        else if (comandosFinalList[movimentos].ToString() == "VirarEsquerda")
        {
            estadoAtual = EstadosPlayer.VirarEsquerda;
            //Debug.Log("Parado");
        }
        else
        {
            Debug.LogWarning("Opção Inválida: " + comandosFinalList[movimentos].ToString());
        }

        

        movimentos++;
    }

    public void AcaoBotaoMenuMetodos(GameObject go)
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

    public void AcaoBotaoPlay()
    {
        //sliderVelocidadePlayer.interactable = false;
        btPlay.GetComponent<Button>().interactable = false;
        comandosFinalList = new List<string>();
        for (int i = 0; i < metodos.Length - 1; i++)
        {
            if (metodos[i].Trim().CompareTo("Repetir2x") == 0)
            {

                int primeiroI = i + 1;
                IList<string> listaFor = new List<string>();
                listaFor.Add(metodos[i].Trim());

                while (metodos[primeiroI].Trim().CompareTo("FimFor2x") != 0)
                {
                    listaFor.Add(metodos[primeiroI].Trim());
                    primeiroI++;
                }

                for (int j = 0; j < 2; j++)
                {
                    foreach (string m in listaFor)
                    {
                        comandosFinalList.Add(m);
                        comandosFinalList.Add("Delay");
                    }

                    if (j == 0)
                    {
                        comandosFinalList.Add("FimFor2x");
                    }
                }
                i = primeiroI;
            }
            if (metodos[i].Trim().CompareTo("Repetir4x") == 0)
            {
                int primeiroI = i + 1;
                IList<string> listaFor = new List<string>();
                listaFor.Add(metodos[i].Trim());

                while (metodos[primeiroI].Trim().CompareTo("FimFor4x") != 0)
                {
                    listaFor.Add(metodos[primeiroI].Trim());
                    primeiroI++;
                }

                for (int j = 0; j < 4; j++)
                {
                    foreach (string m in listaFor)
                    {
                        Debug.Log("comandosFinalList.Count:" + comandosFinalList.Count);
                        comandosFinalList.Add(m);
                        comandosFinalList.Add("Delay");
                    }

                    comandosFinalList.Add("FimFor4x");

                }
                i = primeiroI;
            }

            else
            {
                comandosFinalList.Add(metodos[i].Trim());
                comandosFinalList.Add("Delay");
                pintarSlots.Add(i);
            }
        }
        comandosFinalList.Add("Fim");
        movimentos = 0;
        totalMovimentos = comandosFinalList.Count;
        estadoAtual = EstadosPlayer.Aguardando;
        executaPlay = true;

        audioClipFase.clip = playClip;
        audioClipFase.Play();
        slotsWork = painelWork.GetComponentsInChildren<Slot>();


        Debug.Log("Inicio");
    }

    private void PintarSlot(int i)
    {


        if (i < slotsWork.Length)
        {
            Slot st = slotsWork[i];
            Slot stAnterior;

            if (st.item != null)
            {
                //Debug.LogWarning(st.item.name);
                //Debug.LogWarning("FimFor: " + fimFor);
                if (st.item.name.CompareTo("Repetir2x") == 0 || st.item.name.CompareTo("Repetir4x") == 0)
                {
                    iniFor = jogadaCount;
                    st.item.GetComponent<Image>().color = new Color(st.item.GetComponent<Image>().color.r, st.item.GetComponent<Image>().color.g, st.item.GetComponent<Image>().color.b, 0.5f);
                }

                else if (st.item.name.CompareTo("FimFor4x") == 0 && fimFor == 0)
                {
                    Debug.LogWarning(fimFor);
                }

                else if (st.item.name.CompareTo("FimFor2x") == 0 && fimFor == 0)
                {
                    //Debug.LogWarning(st.item.name);

                    fimFor = jogadaCount;

                    int aux = iniFor;

                    //Debug.LogWarning("aux: " + aux + " - FimFor: " + fimFor);
                    while (aux <= fimFor)
                    {
                        stAnterior = slotsWork[aux];
                        //Debug.LogWarning(stAnterior.item.name);
                        stAnterior.item.GetComponent<Image>().color = new Color(stAnterior.item.GetComponent<Image>().color.r, stAnterior.item.GetComponent<Image>().color.g, stAnterior.item.GetComponent<Image>().color.b, 1f);
                        aux++;
                    }

                    jogadaCount = iniFor;
                    stAnterior = slotsWork[iniFor];
                    stAnterior.item.GetComponent<Image>().color = new Color(stAnterior.item.GetComponent<Image>().color.r, stAnterior.item.GetComponent<Image>().color.g, stAnterior.item.GetComponent<Image>().color.b, 0.5f);

                }
                else
                {
                    st.item.GetComponent<Image>().color = new Color(st.item.GetComponent<Image>().color.r, st.item.GetComponent<Image>().color.g, st.item.GetComponent<Image>().color.b, 0.5f);
                }
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ColisorInferior"))
        {
            Debug.LogWarning("entrou2");
            estadoAtual = EstadosPlayer.Morto;
            ChamaFimJogo();
        }
    }

    private void ChamaFimJogo()
    {
        animator.SetBool("playerParado", false);
        animator.SetBool("playerMorto", true);
    }

    

    public void AlteraVelocidade(float vel)
    {
        timeCountdown = vel;
    }
    
    public void Pause()
    {
        estadoPausado = estadoAtual;
        estadoAtual = EstadosPlayer.Pausado;

    }
    public void Despause()
    {
        estadoAtual = estadoPausado;
    }

    public void SetAnimCont(int i)
    {
        Debug.LogWarning("Entrou X: " + i);
        animCont = i;
    }

    public void SetCorDoPlayer(int i)
    {
        //Debug.LogWarning("Entrou");
        switch (i)
        {
            case 1:
                {
                    animatorOverrideController["player_idle_01"] = acIdle01;
                    break;
                }
            case 2:
                {
                    animatorOverrideController["player_idle_01"] = acIdle02;
                    break;
                }
            case 3:
                {
                    animatorOverrideController["player_idle_01"] = acIdle03;
                    break;
                }
            case 4:
                {
                    animatorOverrideController["player_idle_01"] = acIdle04;
                    break;
                }
            case 5:
                {
                    animatorOverrideController["player_idle_01"] = acIdle05;
                    break;
                }
            case 6:
                {
                    animatorOverrideController["player_idle_01"] = acIdle06;
                    break;
                }
            default:
                {
                    animatorOverrideController["player_idle_01"] = acIdle01;
                    break;
                }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FimDeFase"))
        {
            estadoAtual = EstadosPlayer.FimCaminhoCompleto;
        }
    }

}

public enum EstadosPlayer
{
    Movendo,
    Pulando,
    Aguardando,
    Delay,
    Parado,
    Fim,
    FimCaminhoCompleto,
    Morto,
    VirarDireita,
    VirarEsquerda,
    Pegando,
    Pausado
}