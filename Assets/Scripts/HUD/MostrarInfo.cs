using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostrarInfo : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer UIelement;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        UIelement.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        UIelement.enabled = false;
    }
}
