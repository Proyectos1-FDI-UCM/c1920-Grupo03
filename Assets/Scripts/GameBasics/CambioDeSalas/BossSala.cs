using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSala : MonoBehaviour
{

    int x;
    GameObject boss;
    BossManager bossManager;
    Movimiento8D mov8d;
    
 
    
    void  EnciendeBoss()
    {
       
        boss = transform.GetChild(0).gameObject;
        bossManager = boss.GetComponent<BossManager>();
        if (bossManager != null)
        {
            Debug.Log("Entro en el boss");
            boss.transform.SetParent(null);//le saca de la sala para que no se distorsione
            bossManager.enabled = true;
        }

    }



    Embestida embeScript;
    MovEnemig1 movEneScript;
    MirarJugador mirarJugadorScript;
    AtaqueBoss1 ataqueScript;
    public void ActivarBoss(Collider2D collision)
    {
        
        mov8d = collision.GetComponent<Movimiento8D>();
        if (mov8d != null)
        {
            Debug.Log("Entro");

            //es un bucle que va decrementando la x ya que van saliendo los hijos
            boss = transform.GetChild(0).gameObject;
            if(boss != null)
            {
                bossManager = boss.GetComponent<BossManager>();
                if (bossManager != null)
                {
                    Debug.Log("Entro en el boss");
                    boss.transform.SetParent(null);
                    bossManager.enabled = true;



                    //Aquí se le pasa el jugador a todos los scripts del boss
                    embeScript = boss.GetComponent<Embestida>();
                    if (embeScript != null)
                    {
                        embeScript.CogerJugador(collision.gameObject);
                    }
                    movEneScript = boss.GetComponent<MovEnemig1>();
                    if (movEneScript != null)
                    {
                        movEneScript.CogerJugador(collision.gameObject);
                    }
                    mirarJugadorScript = boss.GetComponent<MirarJugador>();
                    if (mirarJugadorScript != null)
                    {
                        mirarJugadorScript.CogerJugador(collision.gameObject);
                    }
                    ataqueScript = boss.GetComponent<AtaqueBoss1>();
                    if (ataqueScript != null)
                    {
                        ataqueScript.CogerJugador(collision.gameObject);
                    }
                }
            }
           
        }
        
    }
}
