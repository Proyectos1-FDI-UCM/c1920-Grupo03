using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaPinchos : MonoBehaviour
{
    private bool pinchando;
    Animator anim;
    float hit = 0, activateRate= 2;

    void Start()
    {
        anim = GetComponent<Animator>();
        pinchando = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Movimiento8D>()) { 
            if (!pinchando && Time.time > hit)
            {
                activateRate = Time.time + hit;
                anim.SetBool("actvidado", true);
                pinchando = true;
                Invoke("Ataque", 1.5f);

            }
    }
    }
    void OnTriggerExit2D()
    {
        //anim.SetBool("actvidado", false);
        pinchando = false;
    }
    
    void Ataque()
    {
        
        if (pinchando)
        {
            GameManager.instance.TakeDamage(15);
            pinchando = false;
        }
        anim.SetBool("actvidado", false);
    }
}
