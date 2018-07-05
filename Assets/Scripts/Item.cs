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
    public string tagAlvo, nome;
    public float x, y, z;
    private Transform trans;

    public AudioSource audioClipFase;
    public AudioClip itemClip;

    private void Start()
    {
        audioClipFase = GameObject.FindGameObjectWithTag("AudioClipFase").GetComponent<AudioSource>();
        switch (tag)
        {
            case "Cristal":
                {
                    tagAlvo = "CountCristal";
                    nome = tag;
                    break;
                }
            case "Coin":
                {
                    tagAlvo = "CountCoin";
                    nome = tag;
                    break;
                }
            case "Star":
                {
                    tagAlvo = "CountStar";
                    nome = tag;
                    break;
                }
            default:
                {
                    Debug.LogWarning("Nome: " + name + " - Tag: " + tag);
                    nome = "Erro";
                    break;
                }
        }
        trans = gameObject.GetComponent<Transform>();
        x = trans.position.x;
        y = trans.position.y;
        z = trans.position.z;
    }

    private void Update()
    {
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

            audioClipFase.clip = itemClip;
            audioClipFase.Play();


            GetComponent<Renderer>().enabled = false;
            if (tagAlvo.CompareTo("CountCoin") == 0)
            {
                GetComponent<CircleCollider2D>().enabled = false;
            }
            else
            {
                GetComponent<PolygonCollider2D>().enabled = false;
            }
            //Destroy(gameObject, 3);

            if (tagAlvo.CompareTo("CountStar") == 0)
            {

                var array = textUI.text.Split('/');
                int val = int.Parse(array[0]);
                val = val + 1;
                textUI.text = val.ToString() + "/" + array[1];
                this.gameObject.SetActive(false);
            }
            else
            {
                int val = int.Parse(textUI.text);
                val = val + valor;
                textUI.text = val.ToString();
                this.gameObject.SetActive(false);
            }
        }
    }
}