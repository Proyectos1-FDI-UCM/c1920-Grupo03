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
}
