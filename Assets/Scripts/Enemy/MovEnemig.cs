using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemig : MonoBehaviour
{
    public float velocidad;
    GameObject player;
    Rigidbody2D rb;
    Vector2 dir;
    void Start()
    {

        velocidad = Random.Range(velocidad - velocidad / 10, velocidad + velocidad / 5);//Al principio se ajusta la velicidad entre un -20% y un +10& del valor dado
        rb = GetComponent<Rigidbody2D>();

    }

    public void Activar(bool act)
    {
        enabled = act;
    }

    public void CogerJugador(GameObject juga)
    {
        player = juga;
    }
    

    

    private void Update()
    {
        if(player!= null)
        {
            dir = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
            dir.Normalize();
            transform.up = dir;
        }
         
    }

    private void FixedUpdate()
    {
        if(player != null)
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
}
