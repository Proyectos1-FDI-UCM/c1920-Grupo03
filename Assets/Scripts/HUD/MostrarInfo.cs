using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostrarInfo : MonoBehaviour
{
    SpriteRenderer UIelement;

    private void Awake()
    {
        UIelement = GetComponentInChildren<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        UIelement.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        UIelement.enabled = false;
    }
}
