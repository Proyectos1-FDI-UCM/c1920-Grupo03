﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVivo : MonoBehaviour
{
    ControlEnemigos sala;
    // Start is called before the first frame update
    void Start()
    {
        sala = GetComponentInParent<ControlEnemigos>();        
    }
    public  void Destruir()
    {
        Destroy(this.gameObject);
    }
    void OnDisable()
    {
        sala.MinusEnemy();
    }
}
