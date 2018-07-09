using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollAlteraValor : MonoBehaviour {

	public void AletraVal(GameObject go)
    {
        //go.GetComponent<Text>().text = this.GetComponent<Scrollbar>().value.ToString();
        go.GetComponent<Text>().text = GameController.instance.perfilAtivo.GetXp().ToString();
    }

    public void AletraLimite(GameObject go)
    {
        go.GetComponent<Text>().text = "/   " + GameController.instance.perfilAtivo.GetLimite().ToString();
    }
}
