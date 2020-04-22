using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring3 : MonoBehaviour
{
    private bool recogible;
    private GameObject player;


    void Start()
    {
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
       // player.GetComponent<AnilloTres>().enabled = true;
    }
}
