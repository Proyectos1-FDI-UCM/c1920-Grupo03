using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public int amount = 20;

    private void OnTriggerStay2D(Collider2D collider)
    {
        EnemyHealth health = collider.GetComponent<EnemyHealth>();

        if (Input.GetMouseButtonDown(0) && health != null)
        {
            health.TakeDamage(amount);
        }
    }
}
