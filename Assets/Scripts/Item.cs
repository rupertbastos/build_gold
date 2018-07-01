using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

    private GameObject txt;
    private Text textUI;
    public Vector3 posicaoIni { get; private set; }
    public int valor;
    private string tagAlvo;
    public float x, y, z;
    private Transform trans;
    //public AudioSource audioS;
    //public AudioClip audioC;

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
        trans = gameObject.GetComponent<Transform>();
        x = trans.position.x;
        y = trans.position.y;
        z = trans.position.z;
        //Debug.LogWarning("X: " + x + ", Y: " + y + ", Z: " + z);
    }

    public Vector3 GeraPosicao()
    {
        trans = gameObject.GetComponent<Transform>();

        return new Vector3(trans.position.x, trans.position.y, -3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coletador"))
        {
            txt = GameObject.FindGameObjectWithTag(tagAlvo);
            textUI = txt.GetComponent<Text>();

            GetComponent<AudioSource>().Play();
            GetComponent<Renderer>().enabled = false;
            if (tagAlvo.CompareTo("CountCoin") == 0)
            {
                GetComponent<CircleCollider2D>().enabled = false;
            }
            else
            {
                GetComponent<PolygonCollider2D>().enabled = false;
            }
            Destroy(gameObject, 3);

            if (tagAlvo.CompareTo("CountStar") == 0)
            {

                var array = textUI.text.Split('/');
                int val = int.Parse(array[0]);
                val += 1;
                textUI.text = val.ToString() + "/" + array[1];
                //this.gameObject.SetActive(false);
            }
            else
            {
                int val = int.Parse(textUI.text);
                val += valor;
                textUI.text = val.ToString();
                // this.gameObject.SetActive(false);
            }
        }
    }
}