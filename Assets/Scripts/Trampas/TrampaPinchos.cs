using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaPinchos : MonoBehaviour
{
    private bool pinchando;

    void Start()
    {
        pinchando = false;
    }

    void OnTriggerEnter2D()
    {
        if (!pinchando)
        {
            pinchando = true;
            Invoke("Ataque", 3f);

        }
    }
    void OnTriggerExit2D()
    {
        pinchando = false;
    }
    
    void Ataque()
    {
        if (pinchando)
        {
            GameManager.instance.TakeDamage(15);
            pinchando = false;
        }
        
    }
}
