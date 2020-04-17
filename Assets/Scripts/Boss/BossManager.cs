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
  

    

   /* public void CogerJugadorBM1(GameObject juga)                 No funciona y no se la razón
    {
        movEneScript.CogerJugador(juga);
        mirarJugadorScript.CogerJugador(juga);
        embeScript.CogerJugador(juga);
       
        ataqueScript.CogerJugador(juga);

    */
    void Start()
    {
        embeScript = GetComponent<Embestida>();
        movEneScript = GetComponent<MovEnemig1>();
        mirarJugadorScript = GetComponent<MirarJugador>();
        ataqueScript = GetComponent<AtaqueBoss1>();
        CambiaEstado("Normal");
       
        //Invoke("embestir", 0f);
        cargaembestir = false;



    }
    private void Update()
    {
        if(estado == Estados.Normal &&!cargaembestir)
          {
            cargaembestir = true;
              Invoke("embestir", Random.Range(15f, 17f)) ;
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

        switch (a)
        {
            case "Normal":
                movEneScript.CambiaguardaPos(false);
                estado = Estados.Normal;
                embeScript.enabled = false;
                movEneScript.enabled = true;
                mirarJugadorScript.enabled = true;
                ataqueScript.enabled = true;
                break;

           
            case "Embistiendo":
                estado = Estados.Embistiendo;
                movEneScript.enabled = false;
                embeScript.enabled = true;
                mirarJugadorScript.enabled = true;
                ataqueScript.enabled = false;

                break;
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
}
