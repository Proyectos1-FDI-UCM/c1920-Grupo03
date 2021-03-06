﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    public float velocidad;
    
    EnemyHealth enemyHealth;
    public int danyo = 25;


    private void OnCollisionEnter2D(Collision2D collision)//La flecha se destruye con  el mapa,
    {

        enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        
        if (collision.gameObject.GetComponent<Movimiento8D>() != null)
        {
            GameManager.instance.TakeDamage(danyo);         //quita la mitad de daño del enemigo al jugador que del jugador al enemigo
            DestruirFlecha();

        }
        else if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(danyo*2);
            DestruirFlecha();
        }
        else if (collision.gameObject.layer == 16 || collision.gameObject.layer == 13 || collision.gameObject.layer == 12)//si las flechas chocan entre sí o con una pared se destruyen
        {
            DestruirFlecha();
        }
    }
    private void DestruirFlecha()
    {
        Destroy(gameObject);
    }

}