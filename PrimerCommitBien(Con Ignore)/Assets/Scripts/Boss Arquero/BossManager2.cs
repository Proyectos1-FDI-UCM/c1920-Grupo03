using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager2 : MonoBehaviour
{
    enum Estados { Normal, Lluvia };
    Estados estado;
    MovAtqBoss movAtqBoss;
    MirarJugador mirarJugadorScript;
    Lluvia lluvia;
    bool lluviaAct;


    void Start()
    {
        movAtqBoss = GetComponent<MovAtqBoss>();
        mirarJugadorScript = GetComponent<MirarJugador>();
        lluvia = GetComponent<Lluvia>();
        CambiaEstado("Normal");

        //Invoke("embestir", 0f);
        lluviaAct = false;



    }

    private void OnEnable()
    {
        CambiaEstado("Nromal");

    }
    private void Update()
    {
        if (estado == Estados.Normal && !lluviaAct)
        {
            lluviaAct = true;
            Invoke("lluviaAtq", Random.Range(15f, 17f));

         
        }

    }
    public void NotificaEstados(out string estadocopia)
    {
        estadocopia = estado.ToString();
    }
    private void lluviaAtq()
    {
        CambiaEstado("Lluvia");
        lluviaAct = false;
    }
    public void CambiaEstado(string a)//a es el nombre del estado
    {

        switch (a)
        {
            case "Normal":
                estado = Estados.Normal;
                lluvia.enabled = false;
                movAtqBoss.enabled = true;
                mirarJugadorScript.enabled = true;
                
                break;


            case "Lluvia":
                estado = Estados.Lluvia;
                movAtqBoss.enabled = false;
                lluvia.enabled = true;
                mirarJugadorScript.enabled = true;
              
                break;


            default:
                Debug.Log("El estado intoducido no es válido");
                break;
        }

        Debug.Log("Estado "+ estado);

    }
}
