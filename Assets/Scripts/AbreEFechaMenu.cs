using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbreEFechaMenu : MonoBehaviour
{

    public void AcaoBotaoOpenTips(GameObject go)
    {
        if (go.activeSelf == false)
        {
            go.gameObject.SetActive(true);
        }
        else
        {
            go.gameObject.SetActive(false);
        }
    }
}
