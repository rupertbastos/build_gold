using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {

    public int count;
    public GameObject tut1, tut2, tut3, tut4, tut5, tut6, tut7, tut8, tut9;
    public GameObject canvasTutorial;

    // Use this for initialization
    void Start () {
        count = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Proximo()
    {
        count++;
        switch (count)
        {
            case 2:
                {
                    tut1.gameObject.SetActive(false);
                    tut2.gameObject.SetActive(true);
                    break;
                }
            case 3:
                {
                    tut2.gameObject.SetActive(false);
                    tut3.gameObject.SetActive(true);
                    break;
                }
            case 4:
                {
                    tut3.gameObject.SetActive(false);
                    tut4.gameObject.SetActive(true);
                    break;
                }
            case 5:
                {
                    tut4.gameObject.SetActive(false);
                    tut5.gameObject.SetActive(true);
                    break;
                }
            case 6:
                {
                    tut5.gameObject.SetActive(false);
                    tut6.gameObject.SetActive(true);
                    break;
                }
            case 7:
                {
                    tut6.gameObject.SetActive(false);
                    tut7.gameObject.SetActive(true);
                    break;
                }
            case 8:
                {
                    tut7.gameObject.SetActive(false);
                    tut8.gameObject.SetActive(true);
                    break;
                }
            case 9:
                {
                    tut8.gameObject.SetActive(false);
                    tut9.gameObject.SetActive(true);
                    break;
                }
            case 10:
                {
                    tut9.gameObject.SetActive(false);
                    canvasTutorial.gameObject.SetActive(false);
                    count = 1;
                    GameController.instance.ativaTutorial = false;
                    IniciaJogo();
                    break;
                }
        }
    }

    public void SairTurorial()
    {
        canvasTutorial.gameObject.SetActive(false);
        count = 1;
        GameController.instance.ativaTutorial = false;
        IniciaJogo();
    }

    public void IniciaJogo()
    {
        SceneManager.LoadScene("04_01_towerWood");
    }
}
