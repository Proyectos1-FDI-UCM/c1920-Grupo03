using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesacBola : MonoBehaviour
{
    public void Desactivar()
    {
        for (int x = 0; x < transform.childCount; x++) transform.GetChild(x).GetComponent<BolaPinchos>().enabled = false;
    }
}
