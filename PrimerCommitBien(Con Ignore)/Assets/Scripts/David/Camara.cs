using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Camera cam;
    public GameObject sala1, player, sala2, sala3, sala4, sala5, sala6, sala7;
    private Vector3 pos, ini;
    private float x1, x2, y1, y2;

    // Start is called before the first frame update
    void Start()
    {
        pos = sala1.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        x1 = player.transform.position.x;
        y1 = player.transform.position.y;



    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        x2 = player.transform.position.x;
        y2 = player.transform.position.y;
        if (pos == sala1.transform.position)
        {
            if (y1 > y2)
            {
                pos = sala2.transform.position;
                cam.transform.position = pos + new Vector3(0, 0, -1);
                
            }
        }
        else if (pos == sala2.transform.position)
        {
            if (y1 < y2)
            {
                pos = sala1.transform.position;
                cam.transform.position = pos + new Vector3(0, 0, -1);
                
            }
            else if (x1 < x2)
            {
                pos = sala3.transform.position;
                cam.transform.position = pos + new Vector3(0, 0, -1);

            }
        }
        else if (pos == sala3.transform.position)
        {
            if (x1 > x2)
            {
                pos = sala2.transform.position;
                cam.transform.position = pos + new Vector3(0, 0, -1);

            }
            else if (x1 < x2)
            {
                pos = sala5.transform.position;
                cam.transform.position = pos + new Vector3(0, 0, -1);

            }
            else if (y1 > y2)
            {
                pos = sala4.transform.position;
                cam.transform.position = pos + new Vector3(0, 0, -1);

            }
        }
        else if (pos == sala4.transform.position)
        {
            if (y1 < y2)
            {
                pos = sala3.transform.position;
                cam.transform.position = pos + new Vector3(0, 0, -1);

            }
        }
        else if (pos == sala5.transform.position)
        {
            if (x1 > x2)
            {
                pos = sala3.transform.position;
                cam.transform.position = pos + new Vector3(0, 0, -1);

            }
            if (x1 < x2)
            {
                pos = sala6.transform.position;
                cam.transform.position = pos + new Vector3(0, 0, -1);

            }
        }
        else if (pos == sala6.transform.position)
        {
            if (x1 > x2)
            {
                pos = sala5.transform.position;
                cam.transform.position = pos + new Vector3(0, 0, -1);

            }
            else if (y1 < y2)
            {
                pos = sala5.transform.position;
                cam.transform.position = pos + new Vector3(0, 0, -1);

            }
        }
        else if (pos == sala7.transform.position)
        {
            if (y1 > y2)
            {
                pos = sala6.transform.position;
                cam.transform.position = pos + new Vector3(0, 0, -1);

            }
            if (y1 < y2)
            {
                pos = sala1.transform.position;
                cam.transform.position = pos + new Vector3(0, 0, -1);

            }
        }





    }
 

}
