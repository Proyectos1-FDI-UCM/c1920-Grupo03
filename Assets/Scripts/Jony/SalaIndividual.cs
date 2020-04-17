using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaIndividual : MonoBehaviour
{
    Puertas puertas;
    void Start()
    {
        puertas = GetComponentInParent<Puertas>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Movimiento8D>() != null)
        {
            puertas.ActivarPuertas(true);
           
            GameManager.instance.AddRoom();
            Debug.Log("Hola he chocado");
            Destroy(this);
        }
        
    }
   /* void ActPuertas()
    {
        puertas.ActivarPuertas(true);
    }*/
}
