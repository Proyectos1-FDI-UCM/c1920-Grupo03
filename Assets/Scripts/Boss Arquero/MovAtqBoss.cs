﻿using System.Collections;
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
    GameObject player;
    private Rigidbody2D rb;
    private Vector3 spawn;
    Vector2 dir;
    Animator anim;

    public void CogerJugador(GameObject juga)
    {
        player = juga;
        Debug.Log("Pilla jugador el script MovAtaBoss");
    }
    void Start()
    {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        tiempoDisparos = Random.Range(disparos -1, disparos+1);
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
                spawn = this.transform.GetChild(0).gameObject.transform.position;
                Quaternion rot = transform.rotation;
                anim.SetBool("atacaBoss2", true);       //activa la animacion de ataque del boss 2
                Instantiate(flecha, spawn, rot, transform);             
                tiempoDisparos = disparos;
                nhijos = transform.childCount;
                dirFlecha = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);        //direccion flecha
                flechaHija = transform.GetChild(nhijos - 1).gameObject;
                flechaHija.transform.SetParent(null);
                flechaHijaRB = flechaHija.GetComponent<Rigidbody2D>();
                flechaHijaRB.velocity = dirFlecha * 100 * Time.deltaTime;




            }
            else
            {
                anim.SetBool("atacaBoss2", false);      //desactiva la animacion de ataque del boss 2
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
                rb.velocity = -dir * velocidad * 100 * Time.fixedDeltaTime;             //se aleja

            }
            else if (Vector2.Distance(transform.position, player.transform.position) > distanciaParar)
            {
                rb.velocity = dir * velocidad * 100 * Time.fixedDeltaTime;      //se acerca
            }
            else if (Vector2.Distance(transform.position, player.transform.position) < distanciaParar && Vector2.Distance(transform.position, player.transform.position) > distanciaCerca)
            {
                rb.velocity = dir * 0;          //se para
            }
        }





    }
}
