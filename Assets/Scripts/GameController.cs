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

    private bool isNewGame = false;

    private const string FILE_PATH = "saveGameData.dat";
    private SaveGameData saveGame;
    

    //Variaver para save
    public int vidas, save;
    public int estrelas, cristais, moedas, xp;
    public string nome;

    public AudioSource audioS, audioC;
    public AudioClip audioVoltar, audioContinuar;

    public Perfil perfilAtivo;

    public GameObject player;


    /*public GameState State { set; get; }
    public Stack<GameScreens> Screens = new Stack<GameScreens>();
    public GameScreens currentScreen;

    public enum GameState
    {
        None,
        Title,
        Playing,
        Paused,
        GameOver
    };

    //public enum GameScreens
    {
        MainMenu,
        Options,
        Credits,
        Game
    };*/


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
    public void SaveGame()
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
    }

    public void SaveGame(int val)
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
    }

    public void LoadGame()
    {
        if (File.Exists(Path.Combine(Application.streamingAssetsPath, FILE_PATH)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Path.Combine(Application.streamingAssetsPath, FILE_PATH), FileMode.Open);

            SaveGameData save = (SaveGameData)bf.Deserialize(file);
            saveGame = save;

            file.Close();
        }
    }

    public void NovoJogo()
    {
        isNewGame = true;
        LoadStage(0);
    }

    public void CarregaGame()
    {
        isNewGame = false;
        LoadGame();
        LoadStage(saveGame.save);
    }

    public void LoadStage(int stage)
    {
        SceneManager.LoadScene(stage);
    }

    //Quando fechar o jogo ele salva
    private void OnApplicationQuit()
    {
        SaveGame();
    }

    void OnStageLoad(Scene scene, LoadSceneMode mode)
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
    }

    public void ExecutaSomVoltar()
    {
        audioC.clip = audioVoltar;
        audioC.Play();
    }

    public void ExecutaSomContinuar()
    {
        audioC.clip = audioContinuar;
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

    internal void AtualizaFaseInicio(Text nome, Text xp, Text level, GameObject sXp, GameObject foto, Color c, GameObject player, GameObject icon)
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
        audioS.Stop();
    }

}

[Serializable]
class SaveGameData
{
    public int lifes, coins, save;
    //public float positionX, positionY, positionZ;
}