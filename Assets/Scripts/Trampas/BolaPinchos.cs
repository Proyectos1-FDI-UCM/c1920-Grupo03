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
    private Vector2 dirX = new Vector2(1, 0);
    private Vector2 dirY = new Vector2(0, 1);


    private void Update()
    {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (ejeX)
            rb.velocity = dirX*velocidad;
        else
            rb.velocity = dirY*velocidad;

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

            }
        }
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

    }

    void ActivaMov8D()
    {
        movplayer.enabled = true;
    }

}
