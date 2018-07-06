using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventoIniciaJogo : MonoBehaviour {

    public void PrintEvent(string s)
    {
        SceneManager.LoadScene("01_MainMenu");
    }
}
