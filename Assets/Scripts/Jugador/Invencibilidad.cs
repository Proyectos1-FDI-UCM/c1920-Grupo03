using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//script creado para el testo
public class Invencibilidad : MonoBehaviour
{
    // en caso de que el jugador presione la tecla M, se activa la invencibilidad(linea quitada ya que se ha eliminado el script de GameManager y daba error al no existir el metodo)
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
