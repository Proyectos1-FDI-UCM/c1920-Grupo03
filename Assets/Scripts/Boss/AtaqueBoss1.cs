
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
  
    float velocidad;
    enum Estados {Atacando, Moviendose}
    Estados estado;
    bool delay;//delay de ataque, para el if de abajo
    Animator anim;
    void Start()
    {
        delay = true;
        estado = Estados.Moviendose;
        mov = GetComponent<MovEnemig1>();
        hijo = transform.GetChild(0).gameObject;
        miraJugador = GetComponent<MirarJugador>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
    void Update()//En cuanto el boss está a distancia de ataque reduce su velocidad, deja de mirar al jugador y se prepara para atacar,
    {             // el jugador recibe daño si se encuentra en el area de afecto del ataque del boss cuando este acabe
        
      if(player != null)
        {
            d = Vector2.Distance(transform.position, player.transform.position);
            if (d < distancia && estado!=Estados.Atacando && delay)//si está a distancia de ataque
            {
                delay = false;
                Invoke("EsperaDelay", tiempoataque + 1); 
                estado = Estados.Atacando;
                mov.CambiaguardaPos(true);
                velocidad = mov.velocidad;
                mov.velocidad  = mov.velocidad/2;//al atacar su velocidad de movimiento se reduce
                miraJugador.enabled = false;//deja de mirar al jugador
                rb.freezeRotation = true; //para que no rote cuando deja de mirar al jugador

                anim.SetBool("cargarAtaque", true);
                Invoke("InvocaAnimAtaque", tiempoataque - 0.3f);
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



    public int danyo;
    void Ataca()
    {
       
        
        if (enabled)//si el script está activa, para que no ataque si está embistiendo
        {
            
            
            if (dentroTriggerMaza)
            {

                GameManager.instance.TakeDamage(danyo);

            }
            rb.freezeRotation = false;
            miraJugador.enabled = true;
           // sprite.enabled = false;
           // maza.enabled = false;
            mov.velocidad = velocidad;
            estado = Estados.Moviendose;
           
            mov.CambiaguardaPos(false);

            anim.SetBool("ataca",true);         //anim ataque

            Invoke("DesactivaAnimacion", 0.25f);
        }
       
       
    }

    void InvocaAnimAtaque()
    {
        anim.SetBool("cargarAtaque", false);
    }
    void DesactivaAnimacion()
    {
        anim.SetBool("ataca", false);
    }
   private void OnDisable()
    {
       // sprite.enabled = false;
        mov.velocidad = velocidad;
        estado = Estados.Moviendose;
    }
    
}
