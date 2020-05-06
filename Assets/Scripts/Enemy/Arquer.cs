using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arquer : MonoBehaviour
{
    public float velocidad;
    public float distanciaParar;
    public float distanciaCerca;
    public float disparos;
    private float tiempoDisparos;
    public GameObject flecha;
     GameObject player;
    private Rigidbody2D rb;
    private Vector3 spawn;
    Vector2 dir;

    
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

        tiempoDisparos = disparos;
    }

    public void CogeJugador(GameObject jugador)
    {
        player = jugador;
    }
    int nhijos;
    Vector2 dirFlecha;
    GameObject flechaHija;
    Rigidbody2D flechaHijaRB;
    private void Update()
    {
        if (player != null)
        {
            dir = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
            dir.Normalize();
            transform.up = dir;
            if (tiempoDisparos <= 0)
            {
                spawn = this.transform.GetChild(1).gameObject.transform.position;
                Quaternion rot =  this.gameObject.transform.rotation;
                Instantiate(flecha, spawn, rot, transform);
                
                tiempoDisparos = disparos;
                nhijos = transform.childCount;
                dirFlecha = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
                flechaHija = transform.GetChild(nhijos - 1).gameObject;
                flechaHija.transform.SetParent(null);
                flechaHija.layer = 16;
                flechaHijaRB = flechaHija.GetComponent<Rigidbody2D>();
                dirFlecha.Normalize();
                flechaHijaRB.velocity = dirFlecha * 500 * Time.deltaTime;

            }
            else
            {
                tiempoDisparos -= Time.deltaTime;
            }
        }
    }
   
    void FixedUpdate()
    {
        if (player != null)
        {

            if (Vector2.Distance(transform.position, player.transform.position) < distanciaCerca)
            {
                rb.velocity = -dir*velocidad*100*Time.fixedDeltaTime;

            }
            else if (Vector2.Distance(transform.position, player.transform.position) > distanciaParar)
            {
                rb.velocity = dir * velocidad *100 *Time.fixedDeltaTime;
            }
            else if (Vector2.Distance(transform.position, player.transform.position) < distanciaParar && Vector2.Distance(transform.position, player.transform.position) > distanciaCerca)
            {
                rb.velocity = dir * 0;
            }
        }

         



    }
}
