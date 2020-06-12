using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigos : MonoBehaviour
{
    SalaIndividual sala;
    
    int enemigosVivos = 0;
   
    // al iniciar, se coge la cantidad de enemigos que hay en la sala y si hay enemigos, SalaIndividual recibe la cantidad que hay 
    void Start()
    {
        
        sala = GetComponentInParent<SalaIndividual>();
        enemigosVivos = this.transform.childCount;
        
        if (enemigosVivos > 0) PasarEnemigos();
       
    }

    void PasarEnemigos()
    {
        sala.RecibeEnemigos(enemigosVivos);
    }

   // se reduce la cantidad de enemigos a medida que mueren 
    public void MinusEnemy()
    {
        enemigosVivos--;
       //cuando se alcanza 0 enemigos(es decir, todos muertos) las puertas se abren
        if(enemigosVivos == 0)        
           sala.Accionar(false);
        
    }

   
}