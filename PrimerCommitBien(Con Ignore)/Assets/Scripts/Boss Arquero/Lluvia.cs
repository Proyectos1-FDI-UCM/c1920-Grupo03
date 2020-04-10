using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lluvia : MonoBehaviour
{
    BossManager2 bossManager2;
     GameObject player;
    Rigidbody2D rb;
    public float tiempoataque;
    public GameObject prefabLluvia;
 
   
    
  


    bool estadoLLoviendo;
    void Start()
    {
        bossManager2 = GetComponent<BossManager2>();
        rb = GetComponent<Rigidbody2D>();
    }


    
    public void CogerJugador(GameObject juga)
    {
        player = juga;
        Debug.Log("Pilla jugador el script lluvia");
    }


    
    void Update()
    {

        if (player != null && !estadoLLoviendo)
        {

            estadoLLoviendo = true;
            rb.velocity = new Vector2(0, 0);

            //para hacer más grande el circulo que indica la explosión
             
                

               
                

                Invoke("Ataca", tiempoataque);
            
                //gameObject.tag = "Invencible";


            
        }



    }

    void Ataca()
    {
        Debug.Log("Ataca lluvia");

        if (enabled)//si el script está activa, para que no ataque si está embistiendo
        {
            
          
       
            bossManager2.CambiaEstado("Normal");
            

        }


    }
    

}
