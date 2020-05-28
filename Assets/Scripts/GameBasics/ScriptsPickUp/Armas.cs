using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armas : MonoBehaviour
{
    Animator animator;
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
            GameManager.instance.ActBoolArma(0);
            Activar(0);
            //M.SetActive(true);
            MartilloActivo = true;
            GetComponent<Animator>().SetBool("RecogidaMaza", true);
        }
        
    }

    public void ActivarArco()
    {
        if (CompruebArma())
        {
            GameManager.instance.ActBoolArma(1);
            Activar(1);
            //A.SetActive(true);
            ArcoActivo = true;
            GetComponent<Animator>().SetBool("RecogidoArco", true);
        }
       
    }
    public void ActivarLanza()
    {
        if (CompruebArma())
        {
            GameManager.instance.ActBoolArma(2);
            Activar(2);
            //L.SetActive(true);
            MartilloActivo = true;
            GetComponent<Animator>().SetBool("RecogidaLanza", true);
        }

    }
    public void Activar(int num)
    {
        switch (num)
        {
            case 0:
                M.SetActive(true);
                GetComponent<Animator>().SetBool("RecogidaMaza", true);
                break;
            case 1:
                A.SetActive(true);
                GetComponent<Animator>().SetBool("RecogidoArco", true);
                break;
            case 2:
                L.SetActive(true);
                GetComponent<Animator>().SetBool("RecogidaLanza", true);
                break;
        }
    }
}
