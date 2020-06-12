using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampilla : MonoBehaviour
{
    // si el jugador entra dentro del GO trampilla, se carga el nivel 2
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Movimiento8D>() != null)
        {
            GameManager.instance.CargarNivel("Nivel2HUD");
        }
    }
}

