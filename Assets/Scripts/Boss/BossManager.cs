using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    enum Estados { Normal, Embistiendo,  Aturdido};
    Estados estado;
    Embestida embeScript;
    MovEnemig1 movEneScript;
    MirarJugador mirarJugadorScript;
    AtaqueBoss1 ataqueScript;
    bool cargaembestir;
    [SerializeField] GameObject trampilla;

    

   
    void Start()
    {
        embeScript = GetComponent<Embestida>();
        movEneScript = GetComponent<MovEnemig1>();
        mirarJugadorScript = GetComponent<MirarJugador>();
        ataqueScript = GetComponent<AtaqueBoss1>();
        CambiaEstado("Normal");
       
       
        cargaembestir = false;



    }
    private void Update()
    {
        if(estado == Estados.Normal &&!cargaembestir)
          {
            cargaembestir = true;
              Invoke("embestir", Random.Range(10f, 15f)) ;
          }
          
    }
    public void NotificaEstado(out string estadocopia)
     {
        estadocopia = estado.ToString(); 
     }
    private void embestir()
    {
        CambiaEstado("Embistiendo");
        cargaembestir = false;
    }

    public void CambiaEstado(string a)//a es el nombre del estado
    {
        //Dependiendo el estado en el que se encuentra el boss, éste hace una  cosa  u otra
        switch (a)
        {


            //El estado normal es en el que el boss se mueve persiguiendo al enemigo y en el que se ataca al juagdor si está en rango
            case "Normal":
                movEneScript.CambiaguardaPos(false);
                estado = Estados.Normal;
                embeScript.enabled = false;
                movEneScript.enabled = true;
                mirarJugadorScript.enabled = true;
                ataqueScript.enabled = true;
                break;

           //Desde que se para para embestir hasta que choca con algo después de embestir
            case "Embistiendo":
                estado = Estados.Embistiendo;
                movEneScript.enabled = false;
                embeScript.enabled = true;
                mirarJugadorScript.enabled = true;
                ataqueScript.enabled = false;

                break;


            //Justo deespués de embestir, cuando ha chocado con una pared o el jugador
            case "Aturdido":
                estado = Estados.Aturdido;
                mirarJugadorScript.enabled = false;
                ataqueScript.enabled = false;
                embeScript.enabled = true;

                break;
            default:
                Debug.Log("El estado intoducido no es válido");
                break;
        }

        Debug.Log(estado);
        
    }

    public void ActivaTrampilla()
    {
        trampilla.SetActive(true);
    }
}
