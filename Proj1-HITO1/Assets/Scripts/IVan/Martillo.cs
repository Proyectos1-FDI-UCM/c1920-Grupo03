using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Martillo : MonoBehaviour
{
    MovEnemig movenemig;
    [SerializeField] float fuerza = 500f;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MovEnemig>() != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
                if (enemy != null)
                {
                    movenemig = enemy.GetComponent<MovEnemig>();
                    movenemig.enabled = false;
                    Vector2 difference = collision.transform.position - transform.position;
                    enemy.AddForce(difference.normalized * fuerza, ForceMode2D.Impulse);


                }
            }
        }
       
    }
}
