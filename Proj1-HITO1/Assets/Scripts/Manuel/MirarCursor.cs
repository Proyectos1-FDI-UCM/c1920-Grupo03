using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirarCursor : MonoBehaviour
{
    
   

    
    void Update()
    {


        Vector3 cursorPosition = Input.mousePosition;
        cursorPosition = Camera.main.ScreenToWorldPoint(cursorPosition);
        Vector2 positionToFace = new Vector2(cursorPosition.x - transform.position.x, cursorPosition.y - transform.position.y);

        transform.up = positionToFace;



    }
}
