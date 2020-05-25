using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemig : MonoBehaviour
{
     float velocidad;
    public float velMin, velMax;
    GameObject player;
    Rigidbody2D rb;
    Vector2 dir;
    bool moverse;
    public float timepoMaxrespuesta;

    void Start()
    {
        moverse = false;
        velocidad = Random.Range(velMin, velMax);//Al principio se ajusta la velicidad entre un -20% y un +10& del valor dado
        rb = GetComponent<Rigidbody2D>();
        

    }

    public void Activar(bool act)
    {
        enabled = act;
        Invoke("Muevete", Random.Range(0, timepoMaxrespuesta));//para que no vayan todos los enemigos a la vez
    }

    public void CogerJugador(GameObject juga)
    {
        player = juga;
    }

   
      
    


    private void Update()
    {
        if(player!= null && moverse)
        {
            dir = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
            dir.Normalize();
            transform.up = dir;
        }
         
    }

    private void FixedUpdate()
    {
        if(player != null && moverse)
        {
            rb.velocity = dir * velocidad * Time.fixedDeltaTime * 100;
        }
       
    }
    private void OnDisable()
    {
        if(player != null)
        {
            dir = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
            Invoke("ActivaMov", 2f);
        }
    }
    private void ActivaMov()
    {
        enabled = true;
    }

    private void Muevete()
    {
        moverse = true;
    }
}
