﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public int amount = 20;
    float fireRate = 1f, nextFire = 0f;
    private void OnTriggerStay2D(Collider2D collider)
    {
        EnemyHealth health = collider.GetComponent<EnemyHealth>();

        if (Input.GetMouseButtonDown(0) && health != null && Time.time > nextFire)
        {
            Debug.Log("Ataco");
            nextFire = Time.time + nextFire;
            health.TakeDamage(amount);
        }
    }
}
