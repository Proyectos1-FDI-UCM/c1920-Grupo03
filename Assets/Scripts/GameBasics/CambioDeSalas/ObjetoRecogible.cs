using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoRecogible : MonoBehaviour
{
    SalaIndividual sala;
    void Start()
    {
        sala = GetComponentInParent<SalaIndividual>();
    }
    //abre las puertas una vez se recoge el arma
    public void Puertas()
    {
        sala.Accionar(false);
    }
    // abre las puertas una vez se recoge el anillo, además de desactivar las trampas
    public void SalaTrampa()
    {
        sala.Accionar(false);
        sala.Trampas();

    }

    //script creado para que las armas se destruyan una vez el jugador recoge una
    public void DestruirHijos()
    {
        int numHijos = this.transform.childCount;

        for(int x = 0; x < numHijos; x++)
        {
            transform.GetChild(x).gameObject.SetActive(false);
        }
    }
}
