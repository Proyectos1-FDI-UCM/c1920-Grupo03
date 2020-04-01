using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; //Puntos de vida con los que comienza el enemigo.
    int currentHealth; //Vida actual del enemigo.

    void Start()
    {
        currentHealth = maxHealth; //La vida del enemigo comienza al máximo.
    }

    public void TakeDamage(int damage) //Se llama cuando el jugador ataca al enemigo.
    {
        Debug.Log("Ouch");
        currentHealth -= damage; //Disminuye su vida.

        if (currentHealth <= 0) Destroy(this.gameObject); //Si se queda sin vida matarlo.
    }
}
