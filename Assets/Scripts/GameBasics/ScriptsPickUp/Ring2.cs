using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring2 : MonoBehaviour
{
    private bool recogible;
    private GameObject player;
    private ObjetoRecogible recogibles;

    void Start()
    {
        recogibles = GetComponentInParent<ObjetoRecogible>();
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
        recogibles.SalaTrampa();
        player.GetComponent<Dash>().enabled = true;
        player.GetComponent<AnilloCrítico>().enabled = true;
        GameManager.instance.ActivarAnillos(1, true);
        Destroy(this.gameObject);
    }
}
