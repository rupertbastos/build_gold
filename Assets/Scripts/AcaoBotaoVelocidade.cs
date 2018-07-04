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

        
}