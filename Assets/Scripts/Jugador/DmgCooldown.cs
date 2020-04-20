using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgCooldown : MonoBehaviour
{
    bool onCooldown; //Indica el estado del cooldown, si está activo o no.
    public float cooldownTime = 2f; //Duración del cooldown.

    private void Awake()
    {
        onCooldown = false; //El cooldown comienza como falso por defecto.
    }

    public void Call() //Activa el cooldown.
    {
        onCooldown = true;
        Debug.Log("Activate cooldown");

        Invoke("Deactivate", cooldownTime); //desactiva el cooldown después de terminar su duración.
    }

    public bool GetStatus() //permite que otras clases vean la variable privada onCooldown para saber si hay que activarla.
    {
        return onCooldown;
    }

    void Deactivate() //Desactiva el cooldown.
    {
        onCooldown = false;
    }
}
