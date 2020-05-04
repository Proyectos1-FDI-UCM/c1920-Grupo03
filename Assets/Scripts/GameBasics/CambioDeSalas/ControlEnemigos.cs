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
        //Debug.Log(enemigosVivos);
        if (enemigosVivos > 0) PasarEnemigos();
        //else DeshP();
        

        //else if (enemigosVivos == 0) DeshP();
    }

    /*void ActP()
    {
        //Debug.Log("Hola he pasado por aqui");
        puertas.Accionar(true);
    }*/
    
    void PasarEnemigos()
    {
        puertas.RecibeEnemigos(enemigosVivos);
    }

    /*void DeshP()
    {
        puertas.Accionar(false);
    }*/
    public void MinusEnemy()
    {
        enemigosVivos--;
       // Debug.Log("Numero enemigos = " + enemigosVivos);
        if(enemigosVivos == 0)        
           puertas.Accionar(false);
        
    }

   
}