using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArquero : MonoBehaviour
{
    
    Animator anim;
    public GameObject flecha;
    public Transform lugar;
    float tiempo = 0, FireRate = 1;
  
    void Start()
    {
        anim = GetComponentInParent<Animator>();

    }
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > tiempo)
        {
           
            anim.SetBool("Ataque", true);
            Ataca();
            
            
            
        }
        
    }

    void Ataca()
    {
        
        tiempo = Time.time + FireRate;
        Vector3 cursorPosition = Input.mousePosition;
        cursorPosition = Camera.main.ScreenToWorldPoint(cursorPosition);
        Vector2 lugardisparo = new Vector2(cursorPosition.x - transform.position.x, cursorPosition.y - transform.position.y);
        GameObject arrow = Instantiate(flecha, lugar.position, Quaternion.identity);
        arrow.GetComponent<Rigidbody2D>().velocity = lugardisparo.normalized * 10;
        arrow.transform.Rotate(0, 0, Mathf.Atan2(lugardisparo.y, lugardisparo.x) * Mathf.Rad2Deg - 90);
        arrow.layer = 13;
        
    }
   
}
