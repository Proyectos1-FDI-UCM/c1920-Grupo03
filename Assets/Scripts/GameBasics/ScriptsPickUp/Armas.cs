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

  
    
    public bool CompruebArma()
    {
        if (MartilloActivo || ArcoActivo || LanzaActiva) return false;
        return true;
    }
    
    //Todos los metodos comprueban si ya se ha recogido un arma, y en caso contrario, se pone a true su bool de ArmaActivo, su respectivo bool en armas[] de GameManager y se ejecuta Activar(ver)
    public void ActivarMartillo()
    {
        if (CompruebArma())
        {
            GameManager.instance.ActBoolArma(0);
            Activar(0);
            
            MartilloActivo = true;
            
        }
        
    }

    public void ActivarArco()
    {
        if (CompruebArma())
        {
            GameManager.instance.ActBoolArma(1);
            Activar(1);
            
            ArcoActivo = true;
            
        }
       
    }
    public void ActivarLanza()
    {
        if (CompruebArma())
        {
            GameManager.instance.ActBoolArma(2);
            Activar(2);
            
            MartilloActivo = true;
            
        }

    }
    // activa(dependiendo del arma recogida) el arma y su respectiva animación 
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
