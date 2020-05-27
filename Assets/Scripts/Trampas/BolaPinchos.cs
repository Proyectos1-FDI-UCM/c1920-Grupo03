using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaPinchos : MonoBehaviour
{
    MovEnemig movenemig;
    Movimiento8D movplayer;

    [SerializeField] float fuerza = 100f;
    public bool ejeX = true;
    public float velocidad;
    public int damage;
   
    Vector2 posIni, posFin, posMid, dir;
    Rigidbody2D rb;
    float distanciaTotalAlCentro, distanciaAlCentro;
    

    private void Start()
    {
        posIni = transform.GetChild(0).position;//al principio coge la localizacion de inicio y fin y no lo modifica, por lo que no importa que luego se mueva la bola con sus hijo
        posFin = transform.GetChild(1).position;
        posMid = (posIni + posFin) / 2;

        dir = (posFin - posIni);
        distanciaTotalAlCentro = Mathf.Sqrt(Mathf.Pow(dir.x, 2) + Mathf.Pow(dir.y, 2));
        dir = dir.normalized;
        
        rb = GetComponent<Rigidbody2D>();
        gameObject.transform.position = new Vector3(posIni.x, posIni.y, -3) ;
        rb.velocity = velocidad * dir;
       
    }
    private void Update()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        Vector2 distCentro = new Vector2(pos.x - posMid.x, pos.y -posMid.y);//Vector de la pos de la bola hacia el centro

       

       

        
         if (posIni.x <= posFin.x)//si empieza de izqueirda a derecha
         {
             if(posIni.y >= posFin.y)//si va de arriba a abajo
             {
                 if (pos.x < posIni.x || pos.x > posFin.x || pos.y > posIni.y || pos.y < posFin.y)
                 {
                     dir *= -1;
                     rb.velocity = velocidad * dir;
                     Debug.Log("CambiaVel");
                 }
                else
                {
                    distanciaAlCentro = Mathf.Sqrt(Mathf.Pow(distCentro.x, 2) + Mathf.Pow(distCentro.y, 2));
                    rb.velocity = dir * velocidad * ( distanciaTotalAlCentro - distanciaAlCentro) /distanciaAlCentro;
                }
             }
             else // de abajo a arriba
             {
                 if (pos.x < posIni.x || pos.x > posFin.x || pos.y < posIni.y || pos.y > posFin.y)
                 {
                     dir *= -1;
                     rb.velocity = velocidad * dir;
                     Debug.Log("CambiaVel");
                 }
                else
                {
                    distanciaAlCentro = Mathf.Sqrt(Mathf.Pow(distCentro.x, 2) + Mathf.Pow(distCentro.y, 2));
                    rb.velocity = dir * velocidad * (distanciaTotalAlCentro - distanciaAlCentro) / distanciaAlCentro;
                }
            }
         }

         else//si empieza de derecha a izquierda
         {
             if (posIni.y >= posFin.y)//si va de arriba a abajo
             {
                 if (pos.x > posIni.x || pos.x < posFin.x || pos.y > posIni.y || pos.y < posFin.y)
                 {
                     dir *= -1;
                     rb.velocity = velocidad * dir;
                     Debug.Log("CambiaVel");
                 }
                else
                {
                    distanciaAlCentro = Mathf.Sqrt(Mathf.Pow(distCentro.x, 2) + Mathf.Pow(distCentro.y, 2));
                    rb.velocity = dir * velocidad * (distanciaTotalAlCentro - distanciaAlCentro) / distanciaAlCentro;
                }
            }
             else // de abajo a arriba
             {
                 if (pos.x > posIni.x || pos.x < posFin.x || pos.y < posIni.y || pos.y > posFin.y)
                 {
                     dir *= -1;
                     rb.velocity = velocidad * dir;
                     Debug.Log("CambiaVel");
                 }
                else
                {
                    distanciaAlCentro = Mathf.Sqrt(Mathf.Pow(distCentro.x, 2) + Mathf.Pow(distCentro.y, 2));
                    rb.velocity = dir * velocidad * (distanciaTotalAlCentro - distanciaAlCentro) / distanciaAlCentro;
                }
            }
         }

         
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        Rigidbody2D enemy = collision.gameObject.GetComponent<Rigidbody2D>();

        if (collision.gameObject.GetComponent<Movimiento8D>() != null)
        {


            if (enemy != null)
            {
                movplayer = enemy.GetComponent<Movimiento8D>();
                movplayer.enabled = false;
                Debug.Log("Entra personaje");
                Vector2 difference = collision.transform.position - transform.position;
                enemy.AddForce(difference.normalized * fuerza, ForceMode2D.Impulse);
                Invoke("ActivaMov8D", 2f);
                GameManager.instance.TakeDamage(damage);

            }
        }

        else if (collision.gameObject.GetComponent<MovEnemig>() != null)
        {


            if (enemy != null)
            {
                movenemig = enemy.GetComponent<MovEnemig>();
                movenemig.enabled = false;

                Vector2 difference = collision.transform.position - transform.position;
                enemy.AddForce(difference.normalized * fuerza, ForceMode2D.Impulse);
                EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(damage);

            }
        }
        /*
        if (collision.gameObject.tag == "Mapa")
        {
            Debug.Log("ChocaPared");
            if (ejeX)
            {
                dirX = dirX  * -1;
            }

            else
                dirY = dirY  * -1;
        }
        */
    }

    void ActivaMov8D()
    {
        movplayer.enabled = true;
    }

}
