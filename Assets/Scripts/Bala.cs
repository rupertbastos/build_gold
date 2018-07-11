using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {


    public float speed, timeDestroy;


	void Start () {
        Destroy(gameObject, timeDestroy);
	}
	
	void Update () {
        transform.Translate(Vector2.right * speed* Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.CompareTo("BlocoFim") == 0)
        {
            Destroy(gameObject);
        }
    }
}
