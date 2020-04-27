using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruirse : MonoBehaviour
{
    public int tiempo = 5;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("AutoDestruc", tiempo);
    }
        
    private void AutoDestruc()
    {
        Destroy(this.gameObject);
    }

}
