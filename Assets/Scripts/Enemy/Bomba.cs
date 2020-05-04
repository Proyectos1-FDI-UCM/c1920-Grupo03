using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    GameObject player;
    public  float tiempoexplosion;
    public float distanciExplosion;
    public float distanciaRange;// distancia para hacer ell sprint
    MovEnemig mov;
    Transform hijo;
    float d;
    Rigidbody2D rb;
    Vector2 dir;
    public float velocidad;
    float vel;
    Vector3 posPlayer;
    bool movEnabled;
    bool playerInRange;

    void Start()
    {
        movEnabled = true;
        rb = GetComponent<Rigidbody2D>(); 
        hijo = transform.GetChild(0);
        playerInRange = false;
        vel = velocidad;
    }

    public void CogerJugador(GameObject juga)
    {
        player = juga;
    }

    void Update()
    {
        if (transform.position == posPlayer)
        {
            transform.position = posPlayer;
        }

        if (player != null && !playerInRange)//movimiento normal hacia el player
        {
            dir = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
            dir.Normalize();
            transform.up = dir;
        }

        if (playerInRange && transform.position != posPlayer)
        {
            dir = new Vector2(posPlayer.x - transform.position.x, posPlayer.y - transform.position.y);
            dir.Normalize();
            transform.up = dir;
            transform.position = Vector3.MoveTowards(transform.position, posPlayer, vel*Time.deltaTime);
        }
       

        
       
        if(d < distanciaRange && !playerInRange )
        {



            
           
            vel = velocidad / 2;
            

            Invoke("SprintBomba", 1f);

        }


        if(transform.position == posPlayer)//si la bomba se encuentra en la posición donde estaba el player expolota
        {
            //para hacer más grande el circulo que indica la explosión
            hijo.localScale = new Vector3(distanciExplosion, distanciExplosion, distanciExplosion) * 2;
            Invoke("Explota", tiempoexplosion);
        }
    }

    void Explota ()
    {
        d = Vector2.Distance(transform.position, player.transform.position);
        if (d < distanciExplosion && player != null)
        {
            GameManager.instance.TakeDamage(30);
        }
        Destroy(this.gameObject);
        
        
    }

    private void FixedUpdate()
    {
        if(player != null && movEnabled)
        {
            rb.velocity = dir * vel * Time.fixedDeltaTime * 100;
        }
    }

    public void SprintBomba()
    {

        posPlayer = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        playerInRange = true;
        
        vel = velocidad * 1.5f;
        movEnabled = false;
        
    }
}
