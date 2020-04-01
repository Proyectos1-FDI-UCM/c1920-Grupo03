using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    GameObject player;
    public  float tiempoexplosion;
    public float distancia;
    MovEnemig mov;
    Transform hijo;
    float d;
    
    void Start()
    {
       
        mov = GetComponent<MovEnemig>();
        hijo = transform.GetChild(0);
       
    }

    public void CogerJugador(GameObject juga)
    {
        player = juga;
    }

    void Update()
    {

        if(player!=null)
        d = Vector2.Distance(transform.position, player.transform.position);
        if(d < distancia)
        {
            
            
            //para evitar que se mueva cuando vaya a explotar
            mov.enabled = false;
            //para hacer más grande el circulo que indica la explosión
            hijo.localScale = new Vector3(distancia, distancia, distancia) * 2;

            Invoke("Explota", tiempoexplosion);
            //gameObject.tag = "Invencible";

        }
    }

    void Explota ()
    {
        Destroy(this.gameObject);
        if(d < distancia && player != null)
        {
            Destroy(player);
        }
        
    }

}
