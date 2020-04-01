using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    public float velocidad;
    public GameObject player;
    private Vector2 objetivo;
    private Rigidbody2D rb;
    
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Mapa")
        {

            DestruirFlecha();
        }
        else if(collision.gameObject.tag == "Player")
        {
            DestruirFlecha();
        }
    }
    private void DestruirFlecha()
    {
        Destroy(gameObject);
    }
}
