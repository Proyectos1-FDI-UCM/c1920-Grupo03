using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armas : MonoBehaviour
{
    Martillo martillo;
    GameObject M;
    Transform pos;
    

    /*public void Guardar(GameObject  arma)
    {
        M = arma;
    }*/
    void Start()
    {
        pos = this.gameObject.transform.GetChild(0);
        M = pos.gameObject;
        
    }
    public void ActivarArmas()
    {
        M.SetActive(true);
    }
}
