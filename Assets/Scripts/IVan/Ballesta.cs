using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballesta : MonoBehaviour
{
    
    public GameObject shot;
    private Transform shotSpawn;
    private GameObject arrow;
    public float fireRate;
    private float nextFire;


    Vector2 dirFlecha;
    private void Start()
    {
        shotSpawn = transform.GetChild(0);
    }
    void Update()
    {
        if (Time.time > nextFire)
        {
            dirFlecha = new Vector2(shotSpawn.position.x - transform.position.x, shotSpawn.position.y - transform.position.y);
            nextFire = Time.time + fireRate;
            Vector3 pos = new Vector3(shot.transform.position.x, shot.transform.position.y, 0);
            arrow = Instantiate<GameObject>(shot, shotSpawn.position, transform.rotation);
            Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
            rb.velocity = dirFlecha;



        }
    }




}

