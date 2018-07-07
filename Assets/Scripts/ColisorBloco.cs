using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisorBloco : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogWarning("OnTriggerEnter2D");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        this.gameObject.SetActive(false);
        Debug.LogWarning("OnTriggerExit2D: " + this.gameObject.tag);
        if (this.gameObject.tag == "ColisorInicial")
        {
            Debug.LogWarning("Entrou");
            collision.GetComponent<Player>().ChamaPrimeiraAnimacao();
        }
    }
}
