using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechasCayendo : MonoBehaviour
{
    private Renderer cambiaColor;
    private bool cayendo;
    bool playerDentro;
    Animator anim;
    
    void Start()
    {
        cambiaColor = GetComponent<Renderer>();
        cayendo = false;
        anim = GetComponent<Animator>();
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
        anim.SetBool("iniciaAdvertencia", true);
    }

    void Ataque()
    {
        anim.SetBool("caeFlechas", true);
        if (playerDentro) 
        {
            GameManager.instance.TakeDamage(30);
            cayendo = false;
            
        }
        Invoke("Destruir", 1.75f);


    }
    void Destruir()
    {   
        
        Destroy(this.gameObject);
    }
}
