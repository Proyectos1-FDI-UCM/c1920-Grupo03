using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Error : MonoBehaviour
{
    private void OnDisable()
    {
        Debug.LogError("Borrado");
    }
}
