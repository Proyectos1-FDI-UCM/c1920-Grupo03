using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invencibilidad : MonoBehaviour
{
    bool activo = true;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log(activo);
            activo = !activo;
        }
    }
}
