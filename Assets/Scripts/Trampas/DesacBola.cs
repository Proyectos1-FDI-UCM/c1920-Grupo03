using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesacBola : MonoBehaviour
{
    //desactiva todas los componentes bolaPinchos de sus hijos para que no se muevan si el jugador no esta en la sala
    public void Desactivar()
    {
        for (int x = 0; x < transform.childCount; x++) transform.GetChild(x).GetComponent<BolaPinchos>().enabled = false;
    }
}
