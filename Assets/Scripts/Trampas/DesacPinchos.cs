using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesacPinchos : MonoBehaviour
{
    
    public void Desactivar()
    {
        for (int x = 0; x < transform.childCount; x++)
        {
            transform.GetChild(x).GetComponent<TrampaPinchos>().enabled = false;
            Destroy(transform.GetChild(x).GetComponent<Collider2D>());
        }
    }
}
