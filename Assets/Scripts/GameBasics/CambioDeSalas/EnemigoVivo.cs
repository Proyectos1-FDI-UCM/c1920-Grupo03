using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVivo : MonoBehaviour
{
    ControlEnemigos sala;
    

    void Start()
    {
        sala = GetComponentInParent<ControlEnemigos>();        
    }
    // cada vez que se muera un enemigo, se llama al script de controlenemigos para que reduzca la variable que controla los enemigos que hay en sala
    void OnDisable()
    {
        sala.MinusEnemy();
    }
}
