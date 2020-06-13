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
            rb.velocity = new Vector2(0, 0);
            estadoLLoviendo = true;
            

            //para hacer más grande el circulo que indica la explosión
            

                Invoke("Ataca", 1f);
            
                //gameObject.tag = "Invencible";


            
        }
        estadoLLoviendo = false;



    }

    public GameObject sala;
    void Ataca()
    {
        
        //  padre.transform.position +- (padre.transform.localscale.x/2 - prefab.transform.localscale.x/2)
        if (enabled)
        {
            Transform salatransform = sala.transform;
            Debug.Log(salatransform.position);
            for (int i=0; i<Random.Range(3, 6); i++)
            {
                GameObject clon;
                float spawnPosX =  (salatransform.transform.localScale.x / 2 - prefabLluvia.transform.localScale.x / 2);
                float spawnPosY = (salatransform.transform.localScale.y / 2 - prefabLluvia.transform.localScale.y / 2);
                clon = Instantiate(prefabLluvia, new Vector3(Random.Range(salatransform.position.x - spawnPosX, salatransform.position.x + spawnPosX), Random.Range(salatransform.position.y -spawnPosY, salatransform.position.y + spawnPosY), -8), Quaternion.identity);      //crea flechas
                clon.transform.localScale *= 4;
            }
            
          
       
            bossManager2.CambiaEstado("Normal");
            

        }


    }
    

}
