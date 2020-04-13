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
    FlechasCayendo flechasCayendo;
    bool lluviaAct;


    void Start()
    {
        lluvia = GetComponent<Lluvia>();
        movAtqBoss = GetComponent<MovAtqBoss>();
        mirarJugadorScript = GetComponent<MirarJugador>();
        flechasCayendo = GetComponent<FlechasCayendo>();
        CambiaEstado("Normal");

        //Invoke("embestir", 0f);
        lluviaAct = false;



    }

    private void OnEnable()
    {
        CambiaEstado("Normal");

    }
    private void Update()
    {
        if (estado == Estados.Normal && !lluviaAct)
        {
            lluviaAct = true;
            Invoke("lluviaAtq", Random.Range(10f, 11f));

         
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
                if(lluvia!=null)lluvia.enabled=false;
                if(movAtqBoss!=null)movAtqBoss.enabled = true;
                if(mirarJugadorScript!=null)mirarJugadorScript.enabled = true;
                break;


            case "Lluvia":
                estado = Estados.Lluvia;
                if(lluvia!=null)lluvia.enabled = true;
                if(movAtqBoss!=null)movAtqBoss.enabled = false;
                if(mirarJugadorScript!=null)mirarJugadorScript.enabled = true;
                break;


            default:
                Debug.Log("El estado intoducido no es válido");
                break;
        }

        Debug.Log("Estado "+ estado);

    }
}
