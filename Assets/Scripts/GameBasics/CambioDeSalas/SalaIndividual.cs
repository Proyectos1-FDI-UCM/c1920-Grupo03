using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaIndividual : MonoBehaviour
{
    Puertas puertas;
    Deshabilitado desh;
    ObjetoRecogible recogibles;
    //EnemigosSala enem;
    int enemigosViv = 0;
    void Start()
    {
        //enem = GetComponentInChildren<EnemigosSala>();
        puertas = GetComponentInChildren<Puertas>();
        desh = GetComponentInChildren<Deshabilitado>();
        if (GetComponentInChildren<ObjetoRecogible>() != null)
        {
            puertas.ActivarPuertas(true);

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Movimiento8D>() != null)
        {
            //enem.ActivarEnemigos(this.gameObject);
            desh.Deshabilitarse();
            if (enemigosViv > 0)
                Accionar(true);
           
            //GameManager.instance.AddRoom();
          //  Debug.Log("Hola he chocado");
            Destroy(this);
        }
        
    }
    public void RecibeEnemigos(int enemigos)
    {
        enemigosViv = enemigos;
    }
   /* void ActPuertas()
    {
        puertas.ActivarPuertas(true);
    }*/

    public void Accionar(bool estado)
    {        
        puertas.ActivarPuertas(estado);
    }
}
