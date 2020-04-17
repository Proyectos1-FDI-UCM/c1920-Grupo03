using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechasCayendo : MonoBehaviour
{
    private Renderer cambiaColor;
    private bool cayendo;
    bool playerDentro;
    
    void Start()
    {
        cambiaColor = GetComponent<Renderer>();
        cayendo = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Movimiento8D>() != null)
        {
            playerDentro = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Movimiento8D>() != null)
        {
            playerDentro = false;
        }
    }
    private void OnEnable()
    {
        if (!cayendo)
        {
            
            cayendo = true;
            Invoke("Advertencia", 0f);
            Invoke("Ataque", 1.5f);
            
        }
        
    }


    void Advertencia()
    {
        cambiaColor.material.color = Color.blue;
    }

    void Ataque()
    {
        cambiaColor.material.color = Color.magenta;
        if (playerDentro) 
        {
            GameManager.instance.TakeDamage(15);
            cayendo = false;
            
        }
        Invoke("Destruir", 2f);


    }
    void Destruir()
    {
        Destroy(this.gameObject);
    }
}
