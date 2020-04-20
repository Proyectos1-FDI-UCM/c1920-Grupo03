using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruirse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("AutoDestruc", 5f);
    }
        
    private void AutoDestruc()
    {
        Destroy(this.gameObject);
    }

}
