using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    EnemyHealth enemyHealth;
    public int daño = 50;


    private void OnCollisionEnter2D(Collision2D collision)//La flecha se destruye con  el mapa,
    {
        enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
            enemyHealth.TakeDamage(daño);

        Destroy(gameObject);
    }
        
}