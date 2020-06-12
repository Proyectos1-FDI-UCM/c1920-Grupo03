using System.Collections;
using System.Collections.Generic;
using UnityEngine;




// script utilizado para deshabilitar el cubo negro que oculta cada sala del mapa
public class Deshabilitado : MonoBehaviour
{
    public void Deshabilitarse()
    {
        this.gameObject.SetActive(false);
    }
}
