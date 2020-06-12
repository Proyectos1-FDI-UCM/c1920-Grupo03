using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//(no importante, script de prueba en fases tempranas)
//script de pasado un tiempo destruye al objeto que lo porte
public class Destruirse : MonoBehaviour
{
    public int tiempo = 5;
    
    void Start()
    {
        Invoke("AutoDestruc", tiempo);
    }
        
    private void AutoDestruc()
    {
        Destroy(this.gameObject);
    }

}
