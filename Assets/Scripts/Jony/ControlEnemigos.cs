using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigos : MonoBehaviour
{
    SalaIndividual puertas;
    
    int enemigosVivos = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        puertas = GetComponentInParent<SalaIndividual>();
        enemigosVivos = this.transform.childCount;
        if (enemigosVivos > 0) ActP();
    }

    void ActP()
    {
        puertas.Accionar(true);
    }
    public void MinusEnemy()
    {
        enemigosVivos--;
       // Debug.Log("Numero enemigos = " + enemigosVivos);
        if(enemigosVivos == 0)        
           puertas.Accionar(false);
        
    }

   
}