using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cristal:MonoBehaviour
{
    private GameObject txt;
    private Text textUI;
    public Vector3 posicaoIni { get; private set; }
    public int valor;
    private string tagAlvo;
    public float x, y, z;

    private void Start()
    {
        switch (tag)
        {
            case "Cristal":
                {
                    tagAlvo = "CountCristal";
                    break;
                }
            case "Coin":
                {
                    tagAlvo = "CountCoin";
                    break;
                }
            case "Star":
                {
                    tagAlvo = "CountStar";
                    break;
                }
            default:
                {
                    Debug.LogWarning("Nome: " + name + " - Tag: " + tag);
                    break;
                }
        }
    }

    private void Update()
    {
        Transform trans = gameObject.GetComponent<Transform>();
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        Debug.LogWarning("X: " + x + ", Y: " + y + ", Z: " + z);
    }

    public Vector3 GeraPosicao()
    {
        Transform trans = gameObject.GetComponent<Transform>();

        return new Vector3(trans.position.x, trans.position.y,-3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            txt = GameObject.FindGameObjectWithTag(tagAlvo);
            textUI = txt.GetComponent<Text>();
            //Debug.Log("1 cristal");

            int valor = int.Parse(textUI.text);
            valor += 1;
            textUI.text = valor.ToString();
            this.gameObject.SetActive(false);
        }
    }
}
