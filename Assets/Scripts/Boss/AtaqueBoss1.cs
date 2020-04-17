using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueBoss1 : MonoBehaviour
{
    Rigidbody2D rb;
    MirarJugador miraJugador;
     GameObject player;
    public float tiempoataque;
    public float distancia;
    MovEnemig1 mov;
    GameObject hijo;
    float d;
    SpriteRenderer sprite;
    MeshRenderer maza;
    float velocidad;
    enum Estados {Atacando, Moviendose }
    Estados estado;
    bool delay;//delay de ataque, para el if de abajo
    void Start()
    {
        delay = true;
        estado = Estados.Moviendose;
        mov = GetComponent<MovEnemig1>();
        hijo = transform.GetChild(0).gameObject;
        sprite = hijo.GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        maza = transform.GetChild(2).gameObject.GetComponent<MeshRenderer>();
        miraJugador = GetComponent<MirarJugador>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void CogerJugador(GameObject juga)
    {
        player = juga;
        Debug.Log("JUgador AtaquebOss");
    }



  
    private void EsperaDelay()
    {
        delay = true;
    }
    void Update()
    {
        
      if(player != null)
        {
            d = Vector2.Distance(transform.position, player.transform.position);
            if (d < distancia && estado!=Estados.Atacando && delay)
            {
                delay = false;
                Invoke("EsperaDelay", tiempoataque + 1);
                estado = Estados.Atacando;
                //para hacer más grande el circulo que indica la explosión
                maza.enabled = true;
                sprite.enabled = true;
                hijo.transform.localScale = new Vector2(distancia, distancia) * 2;
                mov.CambiaguardaPos(true);
                velocidad = mov.velocidad;
               mov.velocidad  = mov.velocidad/2;
                miraJugador.enabled = false;
                rb.freezeRotation = true;
                Invoke("Ataca", tiempoataque);
                
                //gameObject.tag = "Invencible";
                

            }
        }
         


    }


    bool dentroTriggerMaza;
    //ese metodo se usa en el script que lleva la maza para comrpbar si el player está dentro
    public void CompruebaTriggerMaza(bool dentro)
    {
        dentroTriggerMaza =  dentro;
        Debug.Log(dentroTriggerMaza);
    }
    void Ataca()
    {
       
        
        if (enabled)//si el script está activa, para que no ataque si está embistiendo
        {
            if (dentroTriggerMaza)
            {

                GameManager.instance.TakeDamage(10);

            }
            rb.freezeRotation = false;
            miraJugador.enabled = true;
            sprite.enabled = false;
            maza.enabled = false;
            mov.velocidad = velocidad;
            estado = Estados.Moviendose;
           
            mov.CambiaguardaPos(false);
           
            
        }
       
       
    }
   private void OnDisable()
    {
        sprite.enabled = false;
        mov.velocidad = velocidad;
        estado = Estados.Moviendose;
    }
    
}
