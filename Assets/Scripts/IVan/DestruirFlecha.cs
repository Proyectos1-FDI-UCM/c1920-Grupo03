using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirFlecha : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<BoxCollider2D>() != null)
            Destroy(this.gameObject);
    }
}
