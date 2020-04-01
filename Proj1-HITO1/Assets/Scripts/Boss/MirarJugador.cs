using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirarJugador : MonoBehaviour
{
    Vector2 dir;
    GameObject player;


    public void CogerJugador(GameObject juga)
    {
        player = juga;
        Debug.Log("JUgador MirarJUga");
    }
    private void Update()
    {
        if (player != null)
        {
            dir = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
            dir.Normalize();
            transform.up = dir;
        }

    }
}
