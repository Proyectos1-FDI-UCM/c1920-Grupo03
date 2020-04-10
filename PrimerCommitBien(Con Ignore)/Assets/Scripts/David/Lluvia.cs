using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lluvia : MonoBehaviour
{
    public GameObject player;
    public float tiempoataque;
    public float distancia;
    MovEnemig1 mov;
    GameObject hijo1, hijo2, hijo3, hijo4, hijo5;
    float d;
    SpriteRenderer sprite1, sprite2, sprite3, sprite4, sprite5;
    float velocidad;
    enum Estados { Lluvia}
    Estados estado;
    void Start()
    {
        mov = GetComponent<MovEnemig1>();
        hijo1 = transform.GetChild(0).gameObject;
        hijo2 = transform.GetChild(1).gameObject;
        hijo3 = transform.GetChild(2).gameObject;
        hijo4 = transform.GetChild(3).gameObject;
        hijo5 = transform.GetChild(4).gameObject;
        sprite1 = hijo1.GetComponent<SpriteRenderer>();
        sprite1.enabled = false;
        sprite2 = hijo2.GetComponent<SpriteRenderer>();
        sprite2.enabled = false;
        sprite3 = hijo3.GetComponent<SpriteRenderer>();
        sprite3.enabled = false;
        sprite4 = hijo4.GetComponent<SpriteRenderer>();
        sprite4.enabled = false;
        sprite5 = hijo5.GetComponent<SpriteRenderer>();
        sprite5.enabled = false;


    }



    void Update()
    {

        if (player != null)
        {
            d = Vector2.Distance(transform.position, player.transform.position);
            if (d < distancia && estado != Estados.Lluvia)
            {
                estado = Estados.Lluvia;
                //para hacer más grande el circulo que indica la explosión
                sprite1.enabled = true;
                sprite2.enabled = true;
                sprite3.enabled = true;
                sprite4.enabled = true;
                sprite5.enabled = true;
                hijo1.transform.localScale = new Vector2(distancia, distancia) * 2;
                hijo2.transform.localScale = new Vector2(distancia, distancia) * 2;
                hijo3.transform.localScale = new Vector2(distancia, distancia) * 2;
                hijo4.transform.localScale = new Vector2(distancia, distancia) * 2;
                hijo5.transform.localScale = new Vector2(distancia, distancia) * 2;

                velocidad = mov.velocidad;
                mov.velocidad = mov.velocidad / 2;

                Invoke("Ataca", tiempoataque);

                //gameObject.tag = "Invencible";


            }
        }



    }

    void Ataca()
    {


        if (enabled)//si el script está activa, para que no ataque si está embistiendo
        {
            if (d < distancia && player != null)
            {

                Destroy(player);

            }
            sprite1.enabled = false;
            sprite2.enabled = false;
            sprite3.enabled = false;
            sprite4.enabled = false;
            sprite5.enabled = false;
            mov.velocidad = velocidad;

        }


    }
    private void OnDisable()
    {
        sprite1.enabled = false;
        sprite2.enabled = false;
        sprite3.enabled = false;
        sprite4.enabled = false;
        sprite5.enabled = false;

    }

}
