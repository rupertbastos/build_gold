using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcaoBotaoVelocidade : MonoBehaviour {

    public Sprite BTVel1, BTVel2, BTVel3;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

        public void AcaoBotaoVel(GameObject go)
    {
        if (go.GetComponent<Button>().GetComponent<Image>().sprite.name.CompareTo("Velocidade1") == 0)
        {
            go.GetComponent<Button>().GetComponent<Image>().sprite = BTVel2;
            player.GetComponent<Player>().AlteraVelocidade(2);
        }
        else if (go.GetComponent<Button>().GetComponent<Image>().sprite.name.CompareTo("Velocidade2") == 0)
        {
            go.GetComponent<Button>().GetComponent<Image>().sprite = BTVel3;
            player.GetComponent<Player>().AlteraVelocidade(1);
        }
        else
        {
            go.GetComponent<Button>().GetComponent<Image>().sprite = BTVel1;
            player.GetComponent<Player>().AlteraVelocidade(3);
        }
    }
}