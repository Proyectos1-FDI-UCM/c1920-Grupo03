﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Poner esta script dentro del jugador.
//Cuando este script sea activado permitirá al jugador atravesar paredes y enemigos (layers de colisión 9 y 12)
//y le dará un aumento de velocidad.
public class Etereo : MonoBehaviour
{
    [SerializeField]
    float duracion = 10f; //Duración del efecto del anillo
    [SerializeField]
    float cooldownTime = 10f; //Duración del cooldown
    [SerializeField]
    float boost = 1.1f; //Multiplicador de la velocidad del jugador
    [SerializeField]
    public GameObject player; //GameObject del jugador

    Movimiento8D playerMovement; //Componente que mueve el jugador, para acceder a su velocidad
    float speed, oldSpeed; //Velocidad a aplicar al jugador, y velocidad por defecto a la que volver cuando termine el efecto.
    bool onCooldown = false; //Booleano que indica si el efecto se puede activar

    SpriteRenderer pSprite; //SpriteRenderer del jugador.
    Color original; //Color original del jugador.
    Color tmp; //Color a aplicar durante el efecto del anillo.
    Etereo etereo;

    private void Start() 
    {
        playerMovement = player.GetComponent<Movimiento8D>(); //Recibe el componente para cambiar la velocidad del jugador.
        speed = playerMovement.velocidad;

        pSprite = player.GetComponent<SpriteRenderer>(); //Guarda el sprite y el color del jugador
        //original = pSprite.color;
        tmp = original; //Nuevo color con diferente alpha
        tmp.a = 0.5f;
        etereo = player.GetComponent<Etereo>();
    }

    public bool IsReady()
    {
        return !onCooldown;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && etereo.IsReady()) Call();
    }
    public void Call() //Cuando el efecto sea activado por el jugador
    {
        onCooldown = true; //Para que no pueda activarse dos veces

        Invoke("DisableEffect", duracion);

        Physics2D.IgnoreLayerCollision(10, 15); //ignora columnas
        Physics2D.IgnoreLayerCollision(10, 9); 
        Physics2D.IgnoreLayerCollision(10, 11);
        Physics2D.IgnoreLayerCollision(10, 13); //ignora enemigos y flechas (para no recibir ataques)

        oldSpeed = speed; //Guarda la velocidad antes de activarse el anillo
        speed *= boost; //Cambia la velocidad

        pSprite.color = tmp; //Aplica opacidad
    }

    private void DisableEffect()
    {
        Physics2D.IgnoreLayerCollision(10, 15, false); //detecta paredes
        Physics2D.IgnoreLayerCollision(10, 9, false); 
        Physics2D.IgnoreLayerCollision(10, 11, false); //detecta enemigos
        Physics2D.IgnoreLayerCollision(10, 13, false); //detecta flechas

        speed = oldSpeed; //vuelve a la velocidad inicial

        pSprite.color = original; //vuelve al color original

        Invoke("DeactivateCooldown", cooldownTime);
    }
    
    void DeactivateCooldown()
    {
        onCooldown = false;
    }
}
