using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embestida : MonoBehaviour
{
    BossManager bossmanager;
     GameObject player;
    Rigidbody2D rb, rbplayer;
    MirarJugador mirarJugador;
    MovEnemig1 movBoss;
    public float fuerza;
    Vector2 pos, dir;
    public float vel;

    Movimiento8D movPlayer;
    string estado;
    public void CogerJugador(GameObject juga)
    {
        player = juga;
        Debug.Log("JUgador embes");
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bossmanager = GetComponent<BossManager>();
        mirarJugador = GetComponent<MirarJugador>();
        rbplayer = player.GetComponent<Rigidbody2D>();
        movPlayer = player.GetComponent<Movimiento8D>();
       
    }

   
    private void OnEnable()
    {
     
        Invoke("Embiste", 3f);
    }
 
    void Embiste()
    {
        if(player != null)
        {
          
            mirarJugador.enabled = false;
            pos = new Vector2(player.transform.position.x, player.transform.position.y);
            dir = new Vector2(pos.x - transform.position.x, pos.y - transform.position.y);
            dir.Normalize();
            // rb.isKinematic = true;
            rb.freezeRotation = true;
            rb.velocity = dir * vel;
        }
       
        
    }

    public int danyo;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (enabled)//si no se pone esto da error cunado embestida esta desactivado
        {
            bossmanager.NotificaEstado(out estado);
            
            if (collision.gameObject.tag == "Mapa")
            {

                bossmanager.CambiaEstado("Aturdido");
              
                rb.velocity = Vector2.zero;//no es para quitar mov, es para que se pare en seco al chocar con algo
                Invoke("CambiaMov", 3f);
            }
            else if (collision.gameObject.tag == "Player" && estado == "Embistiendo")
            {
              
                bossmanager.CambiaEstado("Aturdido");
               
                rb.velocity = Vector2.zero;//no es para quitar mov, es para que se pare en seco al chocar con algo
                movPlayer.enabled = false;
                dir.Normalize();
                rbplayer.AddForce(dir * fuerza, ForceMode2D.Impulse);
                Invoke("CambiaMovPlayer", 0.5f);
                Invoke("CambiaMov", 1f);
                GameManager.instance.TakeDamage(danyo);
                

            }
        }
        
    }
    private void CambiaMovPlayer()
    {
        movPlayer.enabled = true;
    }
    private void CambiaMov()
    {
        bossmanager.CambiaEstado("Normal");
    }
}
