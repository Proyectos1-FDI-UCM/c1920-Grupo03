using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento8D : MonoBehaviour
{
    public float velocidad;
    Rigidbody2D rb;
    float x, y;
    Vector2 dir;
    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public float GetVel()
    {
        return velocidad;
    }
    public void CambiaVel(float x)
    {

        velocidad = x;

    }
    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        dir = new Vector2(x, y);
        dir.Normalize();
    }

    private void FixedUpdate()
    {

        rb.velocity = dir * Time.fixedDeltaTime * velocidad * 100;
    }

    private void OnDisable()
    {
        rb.velocity = Vector2.zero;//para que no se quede a la deriva
    }
}
