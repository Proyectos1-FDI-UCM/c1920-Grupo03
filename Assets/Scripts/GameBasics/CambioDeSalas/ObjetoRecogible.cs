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
    public void Puertas()
    {
        sala.Accionar(false);
    }
    public void SalaTrampa()
    {
        sala.Accionar(false);
        sala.Trampas();

    }
    public void DestruirHijos()
    {
        int numHijos = this.transform.childCount;

        for(int x = 0; x < numHijos; x++)
        {
            transform.GetChild(x).gameObject.SetActive(false);
        }
    }
}
