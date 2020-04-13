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
    GameObject boss;
    
    
 
   
    
  


    bool estadoLLoviendo;
    void Start()
    {
        bossManager2 = GetComponent<BossManager2>();
        rb = GetComponent<Rigidbody2D>();
        boss = GetComponent<GameObject>();
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
            rb.velocity = new Vector2(0, 0);
            estadoLLoviendo = true;
            

            //para hacer más grande el circulo que indica la explosión
             
                

               
                

                Invoke("Ataca", 1f);
            
                //gameObject.tag = "Invencible";


            
        }
        estadoLLoviendo = false;



    }

    void Ataca()
    {
        Debug.Log("Ataca lluvia");

        if (enabled)//si el script está activa, para que no ataque si está embistiendo
        {
            
            for (int i=0; i<Random.Range(3, 6); i++)
            {
                Instantiate(prefabLluvia, new Vector3(Random.Range(-5, 5), Random.Range(-4, 4), -3), Quaternion.identity);
            }
            
          
       
            bossManager2.CambiaEstado("Normal");
            

        }


    }
    

}
