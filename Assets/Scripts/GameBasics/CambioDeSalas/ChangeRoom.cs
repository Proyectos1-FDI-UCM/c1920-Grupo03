using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    public Transform sigSala;
    public Transform teleportPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.GetComponent<Movimiento8D>() != null)
        {
            //Debug.Log("Hola he chocado");
            //sala.CambioDeSala(collision);
            Camera.main.transform.position = this.transform.position;
            Camera.main.transform.position += new Vector3(0, 0, -10);
            collision.transform.position = teleportPoint.transform.position;
        }
      
        
        
        
    }
}
