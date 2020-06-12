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
    bool sprint;
    Animator animator;

    void Start()
    {
        movEnabled = true;
        rb = GetComponent<Rigidbody2D>(); 
        hijo = transform.GetChild(0);
        sprint = false;
        vel = velocidad;
        animator = GetComponent<Animator>();
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

        if (player != null && !sprint)//movimiento normal hacia el player
        {
            dir = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
            dir.Normalize();
            transform.up = dir;
        }
        else  if (sprint && transform.position != posPlayer) //mientras que esté sprint activo se dirige a la posición guardada
        {
            transform.position = Vector3.MoveTowards(transform.position, posPlayer, vel * Time.deltaTime);
        }
       

        
       
        if(d < distanciaRange && !sprint )//si se enuentra a una determinada distancia y no tiene activado el sprint
        {
            Invoke("SprintBomba", 1f);//Activa el spint tras un segundo
            animator.SetBool("enciendeMecha", true);
        }


        if(transform.position == posPlayer)//si la bomba se encuentra en la posición guardada expolota
        {
            hijo.localScale = new Vector3(distanciExplosion, distanciExplosion, distanciExplosion) * 2;
            Invoke("Explota", tiempoexplosion);
            animator.SetBool("explota", true);
        }
    }

    void Explota ()
    {
        d = Vector2.Distance(transform.position, player.transform.position);
        if (d < distanciExplosion && player != null)
        {
            GameManager.instance.TakeDamage(30);
        }

        
        Destroy(this.gameObject, 0.1f);
        
        
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
       
        posPlayer = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z); //Guarda la posición del jugador en ese momento
        sprint = true;
        dir = new Vector2(posPlayer.x - transform.position.x, posPlayer.y - transform.position.y);//para no mirar al jugadro mirentras esta corriendo a la posición gueardada
        dir.Normalize();
        transform.up = dir;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        vel = velocidad * 1.5f;//aumenta la velocidad
        movEnabled = false;
       
    }
}
