using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    //GameObject[] Paredes;

    int puertas = 0;
    // Start is called before the first frame update
    void Start()
    {
        puertas = this.transform.childCount;
        
        for(int x = 0; x < puertas; x++)
        {
            transform.GetChild(x).gameObject.SetActive(false);
        }
    }

    public void ActivarPuertas(bool abiertas)
    {
        for (int x = 0; x < puertas; x++)
        {
            transform.GetChild(x).gameObject.SetActive(abiertas);
        }
    }

    
}
