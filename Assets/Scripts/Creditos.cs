using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour {

    public void AcaoBotaoVoltar()
    {
        GameController.instance.ExecutaClip("Voltar");
        SceneManager.LoadScene("01_MainMenu");
    }
}
