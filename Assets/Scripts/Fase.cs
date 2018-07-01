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
    
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GameController.instance.AtualizaFaseInicio(nome, xp, level, sXP, foto, cor, player);
    }
}
