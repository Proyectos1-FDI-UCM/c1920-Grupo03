using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgEnemyMeelee : MonoBehaviour
{
    public int amount = 10; //Cantidad de daño a hacer al jugador.
    int prob;
    private void OnCollisionEnter2D(Collision2D collision) //Cuando se produce una colisión...
    {
        //Debug.Log("Collision");

        GameObject player = collision.gameObject; //El otro GameObject.
        DmgCooldown cooldown = player.GetComponent<DmgCooldown>(); //El componente Cooldown del jugador.

        if (cooldown != null && !cooldown.GetStatus() && player.GetComponent<Movimiento8D>() != null) //Si existe cooldown, sabemos que el otro GameObject es el jugador. Si no está activo dicho cooldown...
        {
            prob = Random.Range(0, 8);
            if (!GameManager.instance.ReturnRing(4))            //si no tiene el anilllo 4 hace daño normal
            {
                GameManager.instance.TakeDamage(amount); //..hacemos daño al jugador...
                cooldown.Call(); //...y llamamos al cooldown.
            }
            else if (GameManager.instance.ReturnRing(4) && prob > 0)     //si tiene el anillo 4, 7 de cada 8 veces recibes daño
            {
                GameManager.instance.TakeDamage(amount); //..hacemos daño al jugador...
                cooldown.Call(); //...y llamamos al cooldown.
            }
            else if (GameManager.instance.ReturnRing(4) && prob == 0)     //si tiene el anillo 4, 1 de cada 8 veces no recibes daño
            {
                cooldown.Call();
            }

            if (GameManager.instance.GetHealth() <= 0) Destroy(player); //Si el jugador se queda sin vida, matarlo.

        }
        else if (player.GetComponent<EnemyHealth>() != null)
            player.GetComponent<EnemyHealth>().TakeDamage(amount);
    }
}
