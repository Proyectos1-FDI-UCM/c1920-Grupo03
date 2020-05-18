using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaPinchos : MonoBehaviour
{
    private Renderer cambiaColor;
    private bool pinchando;
    void Start()
    {
        cambiaColor = GetComponent<Renderer>();
        pinchando = false;
    }
    void OnTriggerEnter2D()
    {
        if (!pinchando)
        {
            pinchando = true;
            Invoke("Advertencia", 0f);
            Invoke("Ataque", 3f);
            Invoke("ColorInicial", 3.5f);

        }


    }
    void OnTriggerExit2D()
    {
        pinchando = false;
    }
    void ColorInicial()
    {
        cambiaColor.material.color = Color.black;
    }

    void Advertencia()
    {
        cambiaColor.material.color = Color.blue;
    }

    void Ataque()
    {
        cambiaColor.material.color = Color.magenta;
        if (pinchando)
        {
            GameManager.instance.TakeDamage(15);
            pinchando = false;
        }
        
    }
}
