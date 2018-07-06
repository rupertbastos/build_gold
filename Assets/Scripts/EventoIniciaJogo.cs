using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventoIniciaJogo : MonoBehaviour {

    public void ChamaMenu()
    {
        SceneManager.LoadScene("01_MainMenu");
    }
}
