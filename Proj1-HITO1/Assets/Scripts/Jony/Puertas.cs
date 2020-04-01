using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    BoxCollider2D[] Paredes;
    // Start is called before the first frame update
    void Start()
    {
        Paredes = this.gameObject.GetComponents<BoxCollider2D>();
        for(int x = 0; x < Paredes.Length; x++)
        {
            Paredes[x].enabled = false;
        }
    }

    public void ActivarPuertas(bool abiertas)
    {
        for (int x = 0; x < Paredes.Length; x++)
        {
            Paredes[x].enabled = abiertas;
        }
    }

    
}
