using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring3 : MonoBehaviour
{
    private bool recogible;
    private GameObject player;
    private ObjetoRecogible recogibles;

    void Start()
    {
        recogibles = GetComponentInParent<ObjetoRecogible>();
        recogible = false;
    }
    // si el objeto es recogible(el jugador esta dentro del trigger) y se pulsa E, el jugador recoge el objeto
    void Update()
    {

        if (recogible && Input.GetKey(KeyCode.E)) PickUp();

    }
    // si entra el jugador en el trigger, se guarda el jugador como GO player y el objeto es recogible
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Movimiento8D>() != null)
        {
            player = other.gameObject;
            recogible = true;
        }
    }
    // si sale el jugador , el objeto deja de ser recogible
    void OnTriggerExit2D()
    {
        recogible = false;
    }
    void PickUp()
    {
        //se ejecuta salaTrampa(ver)
        recogibles.SalaTrampa();
        //se reactiva el dash si ya lo tenía
        if (GameManager.instance.AnilloDash())
            player.GetComponent<Dash>().enabled = true;
        //se activa la habilidad de Etereo para poder usarse
        player.GetComponent<Etereo>().enabled = true;
        //se activa el anillo
        GameManager.instance.ActivarAnillos(2, true);
        //se destruye el objeto
        Destroy(this.gameObject);
    }
}
