using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    //private bool IsNewGame = false;

    private const string FILE_PATH = "saveGameData.dat";
    private SaveGameData saveGame;
    

    //Variaver para save
    //public int vidas, save;
    //public int estrelas, cristais, moedas, xp;

    /*public string nome;
    public Sprite imagem, spI, spP;
    public Color cor;
    public int xp, level, limite, vidas;
    public int moedas, cristais, estrelas, corNumber;
    public int dia, mes, ano, hora, minuto, segundo;
    public int[] fase_1_1, fase_1_2, fase_1_3, fase_1_4, fase_1_5;*/

    public AudioSource audioS, audioC;
    public AudioClip audioMenu, audioIr, audioVoltar, audioSetas, audioPause, audioBotaoTorres, audioBotaoFases, audioBotaoAvatar, audioBotaoCor;
    public AudioClip audioErro;

    public Perfil perfilAtivo;

    public GameObject player;

    public Sprite imagem1, imagem2, imagem3, imagem4, imagem5, imagem6;
    public Sprite spI1, spI2, spI3, spI4, spI5, spI6;
    public Sprite spP1, spP2, spP3, spP4, spP5, spP6;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

       
        

        /*State = GameState.None;
        currentScreen = GameScreens.MainMenu;*/
    }

    private void Start()
    {
        //audioS = GetComponent<AudioSource>();

        if (audioS.isPlaying == false)
        {
            audioS.Play();
        }
    }
    /*public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Path.Combine(Application.streamingAssetsPath, FILE_PATH));

        SaveGameData save = new SaveGameData
        {
            lifes = vidas,
            coins = moedas
        };

        bf.Serialize(file, save);

        file.Close();
    }*/

    /*public void SaveGame(int val)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Path.Combine(Application.streamingAssetsPath, FILE_PATH));

        SaveGameData save = new SaveGameData
        {
            lifes = vidas,
            coins = moedas
        };

        bf.Serialize(file, save);

        file.Close();
    }*/

    

    /*public void NovoJogo()
    {
        isNewGame = true;
        LoadStage(0);
    }*/

    /*public void CarregaGame()
    {
        isNewGame = false;
        LoadGame();
        LoadStage(saveGame.save);
    }*/

    /*public void LoadStage(int stage)
    {
        SceneManager.LoadScene(stage);
    }*/

    //Quando fechar o jogo ele salva
    private void OnApplicationQuit()
    {
        //SaveGame();
    }

    /*void OnStageLoad(Scene scene, LoadSceneMode mode)
    {
        if (!isNewGame && saveGame != null && scene.name != "Menu")
        {
            vidas = saveGame.lifes;
            moedas = saveGame.coins;
            save = saveGame.save;

            //Player.instance.transform.position = new Vector3(saveGame.positionX, saveGame.positionY, saveGame.positionZ);

            isNewGame = true;

            //UIManager.instace.UpdateUI();
        }
    }*/

    /*public void ExecutaSomVoltar()
    {
        audioC.clip = audioVoltar;
        audioC.Play();
    }*/

    public void ExecutaClip(string nome)
    {
        switch (nome)
        {
            case "Ir":
                {
                    audioC.clip = audioIr;
                    break;
                }
            case "Voltar":
                {
                    audioC.clip = audioVoltar;
                    break;
                }
            case "Setas":
                {
                    audioC.clip = audioSetas;
                    break;
                }
            case "Pause":
                {
                    audioC.clip = audioPause;
                    break;
                }
            case "Torres":
                {
                    audioC.clip = audioBotaoTorres;
                    break;
                }
            case "Fases":
                {
                    audioC.clip = audioBotaoFases;
                    break;
                }
            case "Avatar":
                {
                    audioC.clip = audioBotaoAvatar;
                    break;
                }
            case "Cor":
                {
                    audioC.clip = audioBotaoCor;
                    break;
                }
            case "Metodos":
                {
                    audioC.clip = audioIr;
                    break;
                }
            default:
                {
                    audioC.clip = audioErro;
                    break;
                }
            
        }

        audioC.loop = false;
        audioC.Play();
    }

    public void SetPerfilAtivo(Perfil p)
    {
        perfilAtivo = p;
    }

    public void AtualizaSelectTowers(Text porcentagem, Text estrelas, Text cristais, Text moedas, Text total, Text level)
    {
        porcentagem.GetComponent<Text>().text = "0%";
        estrelas.GetComponent<Text>().text = perfilAtivo.GetEstrelas().ToString();
        cristais.GetComponent<Text>().text = perfilAtivo.GetCristais().ToString();
        moedas.GetComponent<Text>().text = perfilAtivo.GetMoedas().ToString();
        total.GetComponent<Text>().text = perfilAtivo.GetXp().ToString();
        level.GetComponent<Text>().text = perfilAtivo.GetLevel().ToString();
    }

    public void AtualizaFaseInicio(Text nome, Text xp, Text level, GameObject sXp, GameObject foto, GameObject player, GameObject icon)
    {
        nome.GetComponent<Text>().text = perfilAtivo.GetNome().ToString();
        xp.GetComponent<Text>().text = perfilAtivo.GetXp().ToString() + "/" + perfilAtivo.GetLimite().ToString();
        level.GetComponent<Text>().text = perfilAtivo.GetLevel().ToString();
        foto.GetComponent<Image>().sprite = perfilAtivo.GetImagem(); //cara do player
        icon.GetComponent<Image>().sprite = perfilAtivo.GetSpI(); //icone do player
        //icon.GetComponent<Image>().sprite = perfilAtivo.GetSpP(); //personagem do player
        player.GetComponent<SpriteRenderer>().sprite = perfilAtivo.GetSpP();
        sXp.GetComponent<Slider>().maxValue = perfilAtivo.GetLimite();
        sXp.GetComponent<Slider>().value = perfilAtivo.GetXp();
        player.GetComponent<SpriteRenderer>().sprite = perfilAtivo.GetSpP();
        player.GetComponent<Player>().SetAnimCont(perfilAtivo.corNumber);
        player.GetComponent<Player>().SetCorDoPlayer(perfilAtivo.corNumber);
        perfilAtivo.RenovaVidas();
        audioS.Stop();
    }

    public void AtualizaXPEstagioCompleto(int val, GameObject sXp, Text level, Text atual, Text limite, int mundo, int fase)
    {
        perfilAtivo.AumentaXp(val);
        sXp.GetComponent<Slider>().maxValue = int.Parse(perfilAtivo.GetLimite().ToString());
        sXp.GetComponent<Slider>().value = perfilAtivo.GetXp();
        level.GetComponent<Text>().text = perfilAtivo.GetLevel().ToString();
        atual.GetComponent<Text>().text = perfilAtivo.GetXp().ToString();
        limite.GetComponent<Text>().text = "/   " + perfilAtivo.GetLimite().ToString();
        perfilAtivo.SalvaFases(mundo, fase, perfilAtivo.GetMoedas(), perfilAtivo.GetCristais(),1);
        SaveGame();
    }

    private void SaveGame()
    {
        
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Path.Combine(Application.streamingAssetsPath, FILE_PATH));

        SaveGameData save = new SaveGameData
        {
            SGDnome = perfilAtivo.GetNome(),
            SGDimagem = perfilAtivo.GetImagemNumero(),
            SGDspI = perfilAtivo.GetSpINumero(),
            SGDspP = perfilAtivo.GetSpPNumero(),
            SGDa = perfilAtivo.GetCor().a,
            SGDr = perfilAtivo.GetCor().r,
            SGDg = perfilAtivo.GetCor().g,
            SGDb = perfilAtivo.GetCor().b,
            SGDxp = perfilAtivo.GetXp(),
            SGDlevel = perfilAtivo.GetLevel(),
            SGDlimite = perfilAtivo.GetLimite(),
            SGDvidas = perfilAtivo.GetVidas(),
            SGDmoedas = perfilAtivo.GetMoedas(),
            SGDcristais = perfilAtivo.GetCristais(),
            SGDestrelas = perfilAtivo.GetEstrelas(),
            SGDcorNumber = perfilAtivo.GetCorNumber(),
            SGDdia = DateTime.Now.Day,
            SGDmes = DateTime.Now.Month,
            SGDano = DateTime.Now.Year,
            SGDhora = DateTime.Now.Hour,
            SGDminuto = DateTime.Now.Minute,
            SGDsegundo = DateTime.Now.Second,
            SGDfase_1_1 = perfilAtivo.GetFase_1_1(),
            SGDfase_1_2 = perfilAtivo.GetFase_1_2(),
            SGDfase_1_3 = perfilAtivo.GetFase_1_3(),
            SGDfase_1_4 = perfilAtivo.GetFase_1_4(),
            SGDfase_1_5 = perfilAtivo.GetFase_1_5(),
            SGDmundoPlayer = perfilAtivo.GetMundoPlayer(),
            SGDfaseplayer = perfilAtivo.GetFasePlayer()
        };

        bf.Serialize(file, save);

        file.Close();
    }

    public void LoadGame()
    {
        if (File.Exists(Path.Combine(Application.streamingAssetsPath, FILE_PATH)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Path.Combine(Application.streamingAssetsPath, FILE_PATH), FileMode.Open);

            SaveGameData save = (SaveGameData)bf.Deserialize(file);
            saveGame = save;

            Color c = new Color(saveGame.SGDr, saveGame.SGDg, saveGame.SGDb, saveGame.SGDa);

            perfilAtivo = new Perfil(saveGame.SGDnome, saveGame.SGDimagem, c, saveGame.SGDxp, saveGame.SGDlevel, saveGame.SGDlimite, saveGame.SGDvidas, saveGame.SGDmoedas, saveGame.SGDcristais, saveGame.SGDestrelas, saveGame.SGDspI, saveGame.SGDspP, saveGame.SGDcorNumber, saveGame.SGDmundoPlayer, saveGame.SGDfaseplayer ,saveGame.SGDfase_1_1, saveGame.SGDfase_1_2, saveGame.SGDfase_1_3, saveGame.SGDfase_1_4, saveGame.SGDfase_1_5);

            file.Close();
        }
    }
}

[Serializable]
class SaveGameData
{
    

    public string SGDnome;
    public int SGDimagem, SGDspI, SGDspP;
    public int SGDxp, SGDlevel, SGDlimite, SGDvidas;
    public int SGDmoedas, SGDcristais, SGDestrelas, SGDcorNumber;
    public int SGDdia, SGDmes, SGDano, SGDhora, SGDminuto, SGDsegundo;
    public int[] SGDfase_1_1, SGDfase_1_2, SGDfase_1_3, SGDfase_1_4, SGDfase_1_5;
    public float SGDr, SGDg, SGDb, SGDa;
    public MundoPlayer SGDmundoPlayer;
    public FasePlayer SGDfaseplayer;
}
