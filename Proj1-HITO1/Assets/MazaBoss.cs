using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazaBoss : MonoBehaviour
{
    AtaqueBoss1 ataque;
    
    void Start()
    {
        ataque = transform.parent.GetComponent<AtaqueBoss1>();
       
    }

    // Update is called once per frame


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entra trigger");
        if (collision.GetComponent<Movimiento8D>() != null)
            ataque.CompruebaTriggerMaza(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Movimiento8D>() != null)
            ataque.CompruebaTriggerMaza(false);
    }
  
}
