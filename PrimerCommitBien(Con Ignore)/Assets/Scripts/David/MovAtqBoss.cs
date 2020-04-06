using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovAtqBoss : MonoBehaviour
{
    public float velocidad;
    public float distanciaParar;
    public float distanciaCerca;
    public float disparos;
    private float tiempoDisparos;
    public GameObject flecha;
    public GameObject player;
    private Rigidbody2D rb;
    Vector2 dir;
    public Transform lugarDisparo;

    void Start()
    {


        rb = GetComponent<Rigidbody2D>();

        tiempoDisparos = disparos;
    }

    private void Update()
    {
        if (player != null)
        {
            dir = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
            dir.Normalize();
            transform.up = dir;
            if (tiempoDisparos <= 0)
            {
                Instantiate(flecha, lugarDisparo.position, Quaternion.identity);
                tiempoDisparos = disparos;
            }
            else
            {
                tiempoDisparos -= Time.deltaTime;
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {

            if (Vector2.Distance(transform.position, player.transform.position) < distanciaCerca)
            {
                rb.velocity = -dir * velocidad * 100 * Time.fixedDeltaTime;

            }
            else if (Vector2.Distance(transform.position, player.transform.position) > distanciaParar)
            {
                rb.velocity = dir * velocidad * 100 * Time.fixedDeltaTime;
            }
            else if (Vector2.Distance(transform.position, player.transform.position) < distanciaParar && Vector2.Distance(transform.position, player.transform.position) > distanciaCerca)
            {
                rb.velocity = dir * 0;
            }
        }





    }
}

