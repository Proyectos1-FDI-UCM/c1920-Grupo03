using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemig1 : MonoBehaviour
{
   
    public  float velocidad;
     GameObject player;
    Rigidbody2D rb;
    Vector2 dir;
    bool guardaPos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        guardaPos = false;
    }
    public void CogerJugador(GameObject juga)
    {
        player = juga;
        Debug.Log("JUgador Movenemig");
    }

    public void CambiaguardaPos(bool guarda)
    {
        guardaPos = guarda;
    }

    //guardaPos para que cuando el boss ataque con la maza se mantenga en la dirección en la que estaba y no siga al jugador
   
    private void Update()
    {
        if(player!= null)
        {
            if (!guardaPos) { dir = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y); }
            
        }
         
    }
  
    private void FixedUpdate()
    {
        if(player != null)
        {
            dir.Normalize();
            rb.velocity = dir * velocidad * Time.fixedDeltaTime * 100;
        }
       
    }
    private void OnDisable()
    {
        if(player != null)
        {
            dir = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
            rb.velocity = Vector2.zero;

        }
       
    }
   
}
