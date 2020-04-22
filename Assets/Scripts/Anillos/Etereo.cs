using System.Collections;
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
    float boost = 1.1f; //Multiplicador de la velocidad del jugador
    [SerializeField]
    GameObject player; //GameObject del jugador

    Movimiento8D playerMovement; //Componente que mueve el jugador, para acceder a su velocidad
    float speed, oldSpeed; //Velocidad a aplicar al jugador, y velocidad por defecto a la que volver cuando termine el efecto.

    SpriteRenderer pSprite; //SpriteRenderer del jugador.
    Color original; //Color original del jugador.
    Color tmp; //Color a aplicar durante el efecto del anillo.

    private void Awake() 
    {
        playerMovement = player.GetComponent<Movimiento8D>(); //Recibe el componente para cambiar la velocidad del jugador.
        speed = playerMovement.velocidad;

        pSprite = player.GetComponent<SpriteRenderer>(); //Guarda el sprite y el color del jugador
        original = pSprite.color;
        tmp = original; //Nuevo color con diferente alpha
        tmp.a = 0.5f;
    }

    private void OnEnable() //Cuando el componente sea activado por el jugador
    {
        Invoke("DisableEffect", duracion);

        Physics2D.IgnoreLayerCollision(10, 15); //ignora columnas
        Physics2D.IgnoreLayerCollision(10, 9); 
        Physics2D.IgnoreLayerCollision(10, 11); //ignora enemigos (para no recibir ataques)

        oldSpeed = speed; //Guarda la velocidad antes de activarse el anillo
        speed *= boost; //Cambia la velocidad

        pSprite.color = tmp;
    }

    private void DisableEffect()
    {
        Physics2D.IgnoreLayerCollision(10, 15, false); //detecta paredes
        Physics2D.IgnoreLayerCollision(10, 9, false);
        Physics2D.IgnoreLayerCollision(10, 11, false); //detecta enemigos

        speed = oldSpeed; //vuelve a la velocidad inicial

        pSprite.color = original;
    }
}
