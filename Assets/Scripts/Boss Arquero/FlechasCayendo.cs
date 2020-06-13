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
            Invoke("Advertencia", 0f);          //advierte del ataque
            Invoke("Ataque", 1.5f);
            
        }
        
    }


    void Advertencia()
    {
        anim.SetBool("iniciaAdvertencia", true);        //animacion de la sombra para advertir al jugador del ataque
    }

    void Ataque()
    {
        anim.SetBool("caeFlechas", true);       //al impactar las flechas se activa la animacion de explosion
        if (playerDentro) 
        {
            GameManager.instance.TakeDamage(30);                //quita daño
            cayendo = false;
            
        }
        Invoke("Destruir", 1.75f);


    }
    void Destruir()
    {   
        
        Destroy(this.gameObject);           //destruye la lluvia
    }
}
