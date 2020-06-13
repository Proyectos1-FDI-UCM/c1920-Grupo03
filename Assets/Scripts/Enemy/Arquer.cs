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
    Animator anim;

    
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

        tiempoDisparos = disparos;

        anim = GetComponent<Animator>();
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
                spawn = this.transform.GetChild(1).gameObject.transform.position;       //lugar spawn
                Quaternion rot = transform.rotation;

                anim.SetBool("cargaFlecha", true);   
                
                Instantiate(flecha, spawn, rot, transform);         //crea flecha
                
                tiempoDisparos = disparos;
                nhijos = transform.childCount;
                dirFlecha = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);       //direccion flecha
                flechaHija = transform.GetChild(nhijos - 1).gameObject;
                flechaHija.transform.SetParent(null);
                flechaHija.layer = 16;
                flechaHijaRB = flechaHija.GetComponent<Rigidbody2D>();
                dirFlecha.Normalize();
                flechaHijaRB.velocity = dirFlecha * 500 * Time.deltaTime;           //velocidad

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
                rb.velocity = -dir*velocidad*100*Time.fixedDeltaTime;               //se aleja

            }
            else if (Vector2.Distance(transform.position, player.transform.position) > distanciaParar)
            {
                rb.velocity = dir * velocidad *100 *Time.fixedDeltaTime;        //se acerca
            }
            else if (Vector2.Distance(transform.position, player.transform.position) < distanciaParar && Vector2.Distance(transform.position, player.transform.position) > distanciaCerca)
            {
                rb.velocity = dir * 0;          //se para
            }
        }

         



    }
}
