using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelecaoFaseMadeira : MonoBehaviour {

    public Text porcentagem, estrelas, cristais, moedas, total, level;
    public Button btStageComplete1, btStageComplete2, btStageComplete3, btStageComplete4, btStageComplete5;
    public Button btStageActive1, btStageActive2, btStageActive3, btStageActive4, btStageActive5;




    private void Start()
    {
        GameController.instance.AtualizaSelectTowers(porcentagem, estrelas, cristais, moedas, total, level);
        
        AtivaFases(btStageComplete1, btStageActive1, GameController.instance.perfilAtivo.GetFase_1_1());
        AtivaFases(btStageComplete2, btStageActive2, GameController.instance.perfilAtivo.GetFase_1_2());
        AtivaFases(btStageComplete3, btStageActive3, GameController.instance.perfilAtivo.GetFase_1_3());
        AtivaFases(btStageComplete4, btStageActive4, GameController.instance.perfilAtivo.GetFase_1_4());
        AtivaFases(btStageComplete5, btStageActive5, GameController.instance.perfilAtivo.GetFase_1_5());
        
    }

    private void AtivaFases(Button btStageComplete, Button btStageActive, int[] aux)
    {
        switch (aux[0])
        {
            case -1:
                {
                    btStageActive.gameObject.SetActive(false);
                    break;
                }
            case 0:
                {
                    btStageActive.gameObject.SetActive(true);
                    break;
                }
            case 1:
                {
                    btStageActive.gameObject.SetActive(false);
                    btStageComplete.gameObject.SetActive(true);
                    Text[] opcoes = btStageComplete.GetComponentsInChildren<Text>();

                    foreach(Text t in opcoes)
                    {
                        switch (t.name)
                        {
                            case "count-coin":
                                {
                                    t.text = aux[1].ToString();
                                    break;
                                }
                            case "count-cristal":
                                {
                                    t.text = aux[2].ToString();
                                    break;
                                }
                            case "number-stage":
                                {
                                    Debug.Log("Não fazer nada");
                                    break;
                                }
                            default:
                                {
                                    Debug.Log("Erro");
                                    break;
                                }
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

    public void AcaoBotaoSelecaoFaseWood(int i)
    {
        switch (i)
        {
            case 1:
                {
                    GameController.instance.ExecutaClip("Fases");
                    GameController.instance.perfilAtivo.mundoAtual = MundoPlayer.Madeira;
                    GameController.instance.perfilAtivo.faseAtual = FasePlayer.Um;

                    if (GameController.instance.ativaTutorial)
                    {
                        SceneManager.LoadScene("04_00_towerWood");
                    }
                    else
                    {
                        SceneManager.LoadScene("04_01_towerWood");
                    }

                    
                    break;
                }

            case 2:
                {
                    GameController.instance.ExecutaClip("Fases");
                    GameController.instance.perfilAtivo.mundoAtual = MundoPlayer.Madeira;
                    GameController.instance.perfilAtivo.faseAtual = FasePlayer.Dois;
                    SceneManager.LoadScene("04_02_towerWood");
                    break;
                }
            case 3:
                {
                    GameController.instance.ExecutaClip("Fases");
                    GameController.instance.perfilAtivo.mundoAtual = MundoPlayer.Madeira;
                    GameController.instance.perfilAtivo.faseAtual = FasePlayer.Tres;
                    SceneManager.LoadScene("04_03_towerWood");
                    break;
                }
            case 4:
                {
                    GameController.instance.ExecutaClip("Fases");
                    GameController.instance.perfilAtivo.mundoAtual = MundoPlayer.Madeira;
                    GameController.instance.perfilAtivo.faseAtual = FasePlayer.Quatro;
                    SceneManager.LoadScene("04_04_towerWood");
                    break;
                }
            case 5:
                {
                    GameController.instance.ExecutaClip("Fases");
                    GameController.instance.perfilAtivo.mundoAtual = MundoPlayer.Madeira;
                    GameController.instance.perfilAtivo.faseAtual = FasePlayer.Cinco;
                    SceneManager.LoadScene("04_05_towerWood");
                    break;
                }
            case -1:
                {
                    GameController.instance.ExecutaClip("Voltar");
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
