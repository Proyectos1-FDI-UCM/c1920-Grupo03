using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaPinchos : MonoBehaviour
{
    private bool pinchando;
    Animator anim;
    float hit = 0, activateRate= 1;

    void Start()
    {
        anim = GetComponent<Animator>();
        pinchando = false;
    }
    // si el jugador entra en  el trigger, y no  esta realizando ya la acción de activarse ni esta en cooldown
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Movimiento8D>())
        { 
            if (!pinchando && Time.time > hit)
            {
                activateRate = Time.time + hit;
                //empieza la animacion
                anim.SetBool("actvidado", true);
                //se actualiza el bool a "hago daño"
                pinchando = true;
                //se invoca el metodo de daño con el retardo de la animación
                Invoke("Ataque", 1.5f);

            }
        }
    }
    //se actualiza el bool a "el jugador se ha salido, no le hago daño"
    void OnTriggerExit2D()
    {
        
        pinchando = false;
    }
    
    // si esta dentro del trigger,  el jugador recibe daño 
    void Ataque()
    {
        
        if (pinchando)
        {
            GameManager.instance.TakeDamage(15);
            pinchando = false;
        }
        //se desactiva la animación
        anim.SetBool("actvidado", false);
    }
}
