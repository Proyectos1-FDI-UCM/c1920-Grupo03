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
                Quaternion rot =  this.gameObject.transform.rotation;
                Instantiate(flecha, transform.position, rot, transform);
                
                tiempoDisparos = disparos;
                nhijos = transform.childCount;
                dirFlecha = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
                flechaHija = transform.GetChild(nhijos - 1).gameObject;
                flechaHija.transform.SetParent(null);
                flechaHijaRB = flechaHija.GetComponent<Rigidbody2D>();
                flechaHijaRB.velocity = dirFlecha * 100 * Time.deltaTime;




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
