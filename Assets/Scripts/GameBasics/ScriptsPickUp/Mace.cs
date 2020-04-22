﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : MonoBehaviour
{
    private bool recogible;
    private GameObject player;
    private ObjetosRecogibles recogibles;

    void Start()
    {
        recogibles = GetComponentInParent<ObjetosRecogibles>();
        recogible = false;
    }
    void Update()
    {

        if (recogible && Input.GetKey(KeyCode.E)) PickUp();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Movimiento8D>() != null)
        {
            player = other.gameObject;
            recogible = true;
        }
    }

    void OnTriggerExit2D()
    {
        recogible = false;
    }
    void PickUp()
    {
        recogibles.Puertas();
        // player.GetComponent<Maza>().enabled = true;
        Destroy(this.gameObject);
    }
}
