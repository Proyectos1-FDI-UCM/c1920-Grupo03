using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potion : MonoBehaviour
{
    
    void Update()
    {
        if(Input.inputString == "Q" || Input.inputString == "q")
        {
            GameManager.instance.Restor();
        }
    }
 }

