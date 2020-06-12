using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesacPinchos : MonoBehaviour
{
    //desactiva todas los componentes bolaPinchos de sus hijos así como sus collider para que no actúen si el jugador no esta en la sala
    public void Desactivar()
    {
        for (int x = 0; x < transform.childCount; x++)
        {
            transform.GetChild(x).GetComponent<TrampaPinchos>().enabled = false;
            Destroy(transform.GetChild(x).GetComponent<Collider2D>());
        }
    }
}
