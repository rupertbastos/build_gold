using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisorBlocoFalso : MonoBehaviour {

    public bool ativo;
    public GameObject blocoPai;

        private void Start()
    {
        ativo = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Player") == 0)
        {
            collision.GetComponent<Player>().estadoAtual = EstadosPlayer.Parado;
            ativo = true;
            gameObject.SetActive(false);
            
        }
    }
}
