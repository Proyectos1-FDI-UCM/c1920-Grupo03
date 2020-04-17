using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgEnemyMeelee : MonoBehaviour
{
    public int amount = 10; //Cantidad de daño a hacer al jugador.

    private void OnCollisionEnter2D(Collision2D collision) //Cuando se produce una colisión...
    {
        //Debug.Log("Collision");

        GameObject player = collision.gameObject; //El otro GameObject.
        DmgCooldown cooldown = player.GetComponent<DmgCooldown>(); //El componente Cooldown del jugador.

        if (cooldown != null && !cooldown.GetStatus()) //Si existe cooldown, sabemos que el otro GameObject es el jugador. Si no está activo dicho cooldown...
        {
           // Debug.Log("enter if");

            GameManager.instance.TakeDamage(amount); //..hacemos daño al jugador...
            cooldown.Call(); //...y llamamos al cooldown.

            if (GameManager.instance.GetHealth() <= 0) Destroy(player); //Si el jugador se queda sin vida, matarlo.

        }
    }
}
