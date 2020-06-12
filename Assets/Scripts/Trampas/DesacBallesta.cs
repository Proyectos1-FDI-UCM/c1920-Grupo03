using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesacBallesta : MonoBehaviour
{
    //desactiva todas los componentes ballesta de sus hijos para que no disparen si el jugador no esta en la sala
    public void Desactivar()
    {
        for (int x = 0; x < transform.childCount; x++) transform.GetChild(x).GetComponent<Ballesta>().enabled = false;
    }
}
