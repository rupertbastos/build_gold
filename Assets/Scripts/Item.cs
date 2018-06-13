using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item: MonoBehaviour
{

    public int x { get; private set; }
    public int y { get; private set; }
    public int z { get; private set; }
    
    public Item()
    {
        z = -3;
    }

    public Vector3 GeraPosicao()
    {
        Vector3 posicao = new Vector3(x, y, z);
        return posicao;
    }
}
