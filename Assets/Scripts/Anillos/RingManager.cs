using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour
{
    [SerializeField]
    Etereo etereo;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && etereo.IsReady()) etereo.Call();
    }
}
