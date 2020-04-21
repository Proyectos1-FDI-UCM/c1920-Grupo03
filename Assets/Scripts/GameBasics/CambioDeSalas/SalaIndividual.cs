using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaIndividual : MonoBehaviour
{
    Puertas puertas;
    Deshabilitado desh;
    void Start()
    {
        puertas = GetComponentInChildren<Puertas>();
        desh = GetComponentInChildren<Deshabilitado>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Movimiento8D>() != null)
        {
            desh.Deshabilitarse();

            puertas.ActivarPuertas(true);
           
            //GameManager.instance.AddRoom();
            Debug.Log("Hola he chocado");
            Destroy(this);
        }
        
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
