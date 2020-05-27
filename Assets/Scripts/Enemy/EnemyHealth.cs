using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; //Puntos de vida con los que comienza el enemigo.
    int currentHealth; //Vida actual del enemigo.
    int prob;
    public bool isBoss1 = false;
    public bool isBoss2 = false;
    void Start()
    {
        currentHealth = maxHealth; //La vida del enemigo comienza al máximo.
    }

    public void TakeDamage(int damage) //Se llama cuando el jugador ataca al enemigo.
    {
        Debug.Log("he sido ejecutado");
        prob = Random.Range(0, 10);

        if (GameManager.instance.ReturnRing(2) && prob < 3)
        {

            Debug.Log("Critico");
            currentHealth -= (damage * 3 / 2); //daño critico
        }
        else
        {
            Debug.Log("Ouch");
            currentHealth -= damage; //daño normal
        }

        if (currentHealth <= 0)
        {

            if (isBoss1)
            {
                GameManager.instance.Boss1Dead();
            }
           else if (isBoss2) GameManager.instance.CargarNivel("MenuVictoria");

           Destroy(this.gameObject); //Si se queda sin vida matarlo.
        }
    }
}
