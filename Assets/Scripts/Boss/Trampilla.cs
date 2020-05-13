using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampilla : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Movimiento8D>() != null)
        {
            GameManager.instance.CargarNivel("Nivel2HUD");
        }
    }
}

