using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaIndividual : MonoBehaviour
{
    GameObject[] enemigosSala;
    
    Puertas puertas;
    Deshabilitado desh;
    
    EnemigosSala enem;
    int enemigosViv = 0;
    bool hayEnemigos = false;
    void Start()
    {

        enem = GetComponentInChildren<EnemigosSala>();

        
        if (enem != null)
            hayEnemigos = enem.gameObject.transform.childCount > 0;
        // se guardan los enemigos, en caso de haberlos, en un array de GO(parte del script perteneciente a la facilitación del testeo)
        //if (hayEnemigos)
        //{
        //    enemigosSala = new GameObject[enem.gameObject.transform.childCount];
        //    for (int x = 0; x < enem.gameObject.transform.childCount; x++) enemigosSala[x] = enem.gameObject.transform.GetChild(x).gameObject;
        //}

        puertas = GetComponentInChildren<Puertas>();
        desh = GetComponentInChildren<Deshabilitado>();
        if (GetComponentInChildren<ObjetoRecogible>() != null)
        {
            puertas.ActivarPuertas(true);
        }

    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        // en caso de entrar el jugador
        if (collision.GetComponent<Movimiento8D>() != null)
        {
            // si es sala de trampas, se desactiva el dash
            if (GetComponentInChildren<TrampasManager>() != null)
                collision.GetComponent<Dash>().enabled = false;

            //bool para facilitar testeo
            //playerDentro = true;

            // dependiendo de si es sala de enemigos, de boss 1 o de boss 2 se activa los enemigos o los respectivos bosses
            if (hayEnemigos)
                enem.ActivarEnemigos(collision);
            else if (this.GetComponentInChildren<BossSala>() != null)
                this.GetComponentInChildren<BossSala>().ActivarBoss(collision);
            else if (GetComponentInChildren<BossArqueroSala>() != null)
                GetComponentInChildren<BossArqueroSala>().ActivarBoss(collision);
            //se deja visible la sala dentro del minimapa

            desh.Deshabilitarse();
            // si hay enemigos, se activan las trampas
            if (enemigosViv > 0)
                Accionar(true);

            //se añade una room al int que lo controla del gameManager
            GameManager.instance.AddRoom();
            
            // se destruye el collider de la salaIndividual
            Destroy(this.gameObject.GetComponent<Collider2D>());
        }


    }

    // desactiva todas las trampas una vez se recoge el anillo de la misma
    public void Trampas()
    {
        TrampasManager trampas = GetComponentInChildren<TrampasManager>();
        trampas.DestruirCollider();
        trampas.DesactivarTrampas();
        
        }

    // recibe el numero de enemigos en sala
    public void RecibeEnemigos(int enemigos)
    {
        enemigosViv = enemigos;
    }
 //si hay puertas se desactivan o activan en funcion del bool estado recibido

    public void Accionar(bool estado)
    {        
        if(puertas != null)
        puertas.ActivarPuertas(estado);
    }


    //(Código incluido solo para el facilitado de testeo)
    //Código matar enemigos en sala



    //void Update()
    //{

    //    if (Input.GetKeyDown(KeyCode.K) && playerDentro && hayEnemigos)
    //    {
    //        EliminarEnem();
    //    }
    //}

    //void EliminarEnem()
    //{
    //    for (int x = 0; x < enemigosSala.Length; x++)
    //    {
    //        if (enemigosSala[x] != null)
    //            enemigosSala[x].SetActive(false);
    //    }


    //    hayEnemigos = false;
    //}

}



