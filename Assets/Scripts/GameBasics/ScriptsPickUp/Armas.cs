using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armas : MonoBehaviour
{
    // iniciales de armas
    // no es la solucion mas elegante pero xd
    public GameObject M, A, L;
    //Transform mart, arco;
    bool MartilloActivo = false, ArcoActivo = false, LanzaActiva = false;

    /*public void Guardar(GameObject  arma)
    {
        M = arma;
    }*/
    /*void Start()
    {
        //mart = this.gameObject.transform.GetChild(0);
        M = mart.gameObject;
        //arco = this.gameObject.transform.GetChild(3);
        A = arco.gameObject;
        
    }*/
    public bool CompruebArma()
    {
        if (MartilloActivo || ArcoActivo || LanzaActiva) return false;
        return true;
    }
    
    public void ActivarMartillo()
    {
        if (CompruebArma())
        {
            M.SetActive(true);
            MartilloActivo = true;
        }
        
    }

    public void ActivarArco()
    {
        if (CompruebArma())
        {
            A.SetActive(true);
            ArcoActivo = true;
        }
       
    }
    public void ActivarLanza()
    {
        if (CompruebArma())
        {
            L.SetActive(true);
            MartilloActivo = true;
        }

    }
}
