using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostrarInfo : MonoBehaviour
{
    SpriteRenderer UIelement;

    private void Awake()
    {
        UIelement = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D()
    {
        UIelement.enabled = true;
    }

    private void OnTriggerExit2D()
    {
        UIelement.enabled = false;
    }
}
