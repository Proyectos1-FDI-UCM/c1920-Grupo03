using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    public Transform sigSala;
    public Transform teleportPoint;
    
    // en caso de el jugador entrar el contacto con un changePoint, la camara se mueve a la siguiente sala y el jugador se teletransporta al teleportPoint
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Movimiento8D>() != null)
        {
            
            Camera.main.transform.position = sigSala.transform.position;
            Camera.main.transform.position += new Vector3(0, 0, -10);
            collision.transform.position = teleportPoint.transform.position;
        }

       
        
    }
}
