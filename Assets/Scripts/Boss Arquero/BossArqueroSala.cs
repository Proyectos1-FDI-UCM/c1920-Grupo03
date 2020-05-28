using UnityEngine;

public class BossArqueroSala : MonoBehaviour
{
    int x;
    GameObject boss;
    BossManager2 bossManager2;
    MovAtqBoss movAtaBoss;
    Lluvia lluvia;



   
    void EnciendeBoss()
    {



        //es un bucle que va decrementando la x ya que van saliendo los hijos
        boss = transform.GetChild(0).gameObject;
        bossManager2 = boss.GetComponent<BossManager2>();
        if (bossManager2 != null)
        {
            Debug.Log("Entro en el boss");
            boss.transform.SetParent(null);
            bossManager2.enabled = true;
        }



    }



    public void ActivarBoss(Collider2D collision)
    {

      
        if (collision.GetComponent<Movimiento8D>() != null)
        {
            Debug.Log("Entro");

            
            boss = transform.GetChild(0).gameObject;
            if (boss != null)
            {
                bossManager2 = boss.GetComponent<BossManager2>();
                if (bossManager2 != null)
                {
                    Debug.Log("Entro en el boss");
                    boss.transform.SetParent(null);
                    bossManager2.enabled = true;


                    lluvia = boss.GetComponent<Lluvia>();
                    if (lluvia != null)
                    {
                        lluvia.CogerJugador(collision.gameObject);
                        Debug.Log("Pilla al player");
                    }

                    movAtaBoss= boss.GetComponent<MovAtqBoss>();
                    if (movAtaBoss != null)
                    {
                        movAtaBoss.CogerJugador(collision.gameObject);
                    }

                }
            }

        }

    }
}
