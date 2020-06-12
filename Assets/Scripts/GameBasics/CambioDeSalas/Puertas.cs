using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    

    int puertas = 0;
    
    //desactiva todas las puertas al inicio
    void Awake()
    {
        puertas = this.transform.childCount;
        
        for(int x = 0; x < puertas; x++)
        {
            transform.GetChild(x).gameObject.SetActive(false);
        }
    }

    //se activan y desactivam las puertas en función del bool abiertas recibido
    public void ActivarPuertas(bool abiertas)
    {
        
        for (int x = 0; x < puertas; x++)        
            transform.GetChild(x).gameObject.SetActive(abiertas);
        
    }

    
}
