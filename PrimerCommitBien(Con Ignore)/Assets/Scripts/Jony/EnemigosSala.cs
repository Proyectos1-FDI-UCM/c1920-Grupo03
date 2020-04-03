using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigosSala : MonoBehaviour
{

    int x;
    GameObject hijo;
    MovEnemig movEnemig;
    Movimiento8D mov8d;
    Bomba bomb;
    Arquer arquero;
    BossManager bossManager;
   
    //Este metodo no se usa, pero puede ser util, no borrar
    void  EnciendeHijos()
    {
        x = transform.childCount;
        //es un bucle que va decrementando la x ya que van saliendo los hijos
        while ( x > 0)
        {
            hijo = transform.GetChild(x-1).gameObject;
            movEnemig = hijo.GetComponent<MovEnemig>();
           
            movEnemig.Activar(true);
            hijo.transform.SetParent(null);
            Debug.Log("Enciende hijo" + x);
            Debug.Log(x);
            x = transform.childCount;

        }

       

        
       

    }

    Puertas puertas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        mov8d = collision.GetComponent<Movimiento8D>();
        if (mov8d != null)
        {
           
            Debug.Log("Entro");
            x = transform.childCount;
            //es un bucle que va decrementando la x ya que van saliendo los hijos
            while (x > 0)
            {
                hijo = transform.GetChild(x - 1).gameObject;
                movEnemig = hijo.GetComponent<MovEnemig>();
                bomb = hijo.GetComponent<Bomba>();
                arquero = hijo.GetComponent<Arquer>();
                if (movEnemig != null)
                {
                    movEnemig.CogerJugador(collision.gameObject);
                    movEnemig.Activar(true);
                }
                if (bomb != null)
                {
                    bomb.enabled = true;
                    bomb.CogerJugador(collision.gameObject);
                    Debug.Log("ACtiva bomba");
                }
                if (arquero != null)
                {
                    arquero.enabled = true;
                    arquero.CogeJugador(collision.gameObject);
                }


                hijo.transform.SetParent(null);
                Debug.Log("Enciende hijo" + x);
                Debug.Log(x);
                x = transform.childCount;

            }
        }
        
    }
}
