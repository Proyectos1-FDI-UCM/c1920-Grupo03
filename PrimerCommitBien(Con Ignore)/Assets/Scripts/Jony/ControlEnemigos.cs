using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigos : MonoBehaviour
{
    Puertas puertas;
    
    int enemigosVivos = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        puertas = GetComponentInParent<Puertas>();
        enemigosVivos = this.transform.childCount;
    }
    public void MinusEnemy()
    {
        enemigosVivos--;
        Debug.Log("Numero enemigos = " + enemigosVivos);
        if(enemigosVivos == 0)        
           puertas.ActivarPuertas(false);
        
    }

   
}