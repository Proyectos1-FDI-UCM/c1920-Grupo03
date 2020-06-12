using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : MonoBehaviour
{
    private Armas armas;
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
        //se desactivan las puertas
        recogibles.Puertas();
        //se activa el martillo
        armas = player.GetComponent<Armas>();
        armas.ActivarMartillo();
        //se destruyen el resto de armas
        recogibles.DestruirHijos();
        //se destruye el objeto
        Destroy(this.gameObject);
        
    }
}
