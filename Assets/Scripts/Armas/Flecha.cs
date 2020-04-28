using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    public float velocidad;
    public GameObject player;
    private Vector2 objetivo;
    private Rigidbody2D rb;
    EnemyHealth enemyHealth;
    public int daño = 50;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {

        enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if ( collision.gameObject.tag == "Mapa")
        {

            DestruirFlecha();
        }
        else if(collision.gameObject.tag == "Player")
        {
            DestruirFlecha();
            
        }
        else if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(daño);
            DestruirFlecha();
        }
    }
    private void DestruirFlecha()
    {
        Destroy(gameObject);
    }
}
