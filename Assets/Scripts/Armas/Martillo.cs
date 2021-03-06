﻿
using UnityEngine;

public class Martillo : MonoBehaviour
{
    Armas arma;
    float guardarVel;
    Movimiento8D movPlayer;
    MovEnemig movenemig;
    MovEnemig1 movenemig1;
    BossManager2 bossarquero;
    public float fuerza = 300;
  
    bool ataque;//da la orden de atacar
    ListaEnemigosDentro lista;
    public int damage;
    Arquer arquero;
    Bomba bomb;
    Animator animator;
    float hitRate = 1.5f, nextHit = 0;
    BoxCollider2D trigger;
 
    private void Start()
    {
        //atacando = false;
        trigger = GetComponent<BoxCollider2D>();
         lista = new ListaEnemigosDentro();
        animator = GetComponentInParent<Animator>();
        
    }

    private void Update()
    {
       
            if (Input.GetMouseButtonDown(0)&& nextHit< Time.time)
            {
                nextHit = Time.time + hitRate;// El cooldown
                movPlayer = GetComponentInParent<Movimiento8D>();
                guardarVel = movPlayer.GetVel();
                movPlayer.CambiaVel(guardarVel / 2);//en el tiempo que dura el ataque el personaje va más lento
            
          
                Invoke("Ataca", 0.6f);
                Invoke("ActivaAnimacion",0f); //Invoca la animacion de ataque
                Invoke("ParaAnimacion", 0.9f);  //Vuelve a estar estatico

            }

        
    }

    
    private void Ataca()
    {
       
        ataque = true;               
        while (lista.DamePrimeroParaEmpujar() != null)
        {
            // para que este if si lo haces true en el mismo metodo
            if (ataque)
            {
                GameObject enemigo = lista.DamePrimeroParaEmpujar();
                if (enemigo != null)
                {

                    Rigidbody2D enemy = enemigo.GetComponent<Rigidbody2D>();
                    if (enemy != null)
                    {
                      

                        //Para saber de que tipo es cada enemigo
                        movenemig = enemigo.GetComponent<MovEnemig>();
                        movenemig1 = enemigo.GetComponent<MovEnemig1>();
                        arquero = enemigo.GetComponent<Arquer>();
                        bomb = enemigo.GetComponent<Bomba>();
                        bossarquero = enemigo.GetComponent<BossManager2>();



                        //Dependiendo del enemigo con el que luche hace un a cosa u otra
                        if (movenemig != null)
                        {
                            movenemig.enabled = false;
                            Vector2 difference = enemigo.transform.position - transform.position;
                            enemy.AddForce(difference.normalized * fuerza, ForceMode2D.Impulse);
                            EnemyHealth vidaEnmigo = enemy.GetComponent<EnemyHealth>();
                            vidaEnmigo.TakeDamage(damage);
                        }
                      
                        else if (movenemig1 != null)
                        {
                            EnemyHealth vidaEnmigo = enemy.GetComponent<EnemyHealth>();
                            vidaEnmigo.TakeDamage(damage);
                        }

                        else if (arquero != null)
                        {
                            //no le emuja ya que lo mata de un toque
                            EnemyHealth vidaEnmigo = enemy.GetComponent<EnemyHealth>();
                            vidaEnmigo.TakeDamage(damage);
                            arquero.enabled = false;
                        }
                        else if(bomb != null)
                        {
                            EnemyHealth vidaEnmigo = enemy.GetComponent<EnemyHealth>();
                            vidaEnmigo.TakeDamage(damage);
                        }
                        else if (bossarquero != null)
                        {
                            EnemyHealth vidaEnmigo = enemy.GetComponent<EnemyHealth>();
                            vidaEnmigo.TakeDamage(damage);
                        }
                    }
                }

            }
            lista.AvanzaPrimer(); //Hace que el primer enemigo de la lista sea el segundo, eliminando el primero
        }
        VelOriginal();
        trigger.enabled = false;//para que si se ha quedado alguien en el trigger se veulva a meter en la lista tras atacar
        trigger.enabled = true;

    }




    //Se utiliza una lista para llevar la cuenta de los enemigo que hay dentro del area de efector del arma (trigger)
    public class ListaEnemigosDentro
    {
        private class Enemigo
        {
            public GameObject enem;
            public Enemigo sig;

            public Enemigo(GameObject e, Enemigo next)
            {
                enem = e;
                sig = next;
               // Debug.Log("Se ha creado un nuevo enemigo");
            }
        }


        Enemigo prim;

        public ListaEnemigosDentro()
        {
            prim = null;
        }

        public int EnemigoN(GameObject e)//busca el numero dl  nodo que tiene el siguiente gameobject
        {

            int x = 1;
            Enemigo aux = prim;
            while(aux != null && aux.enem != e)
            {
                x++;
                aux = aux.sig;
            }
            if (aux == null) x=0;
            return x;
        }

        private Enemigo DameEnemigoN(int n)
        {
            int x = 1;
            Enemigo aux = prim;
            while (aux != null && x < n)
            {
                x++;
                aux = aux.sig;
            }
            
            return aux;
        }
        public void AddPrincipio(GameObject e)
        {
            
                Enemigo nuevo = new Enemigo(e, prim);
            prim = nuevo;
           
            
        }

        public bool BuscaGameOBject(GameObject e)
        {
            Enemigo aux = prim;
            
            
                while (aux != null && aux.enem != e)
                {
                    aux = aux.sig;
                }
            
            

            return aux!=null;
        }

        public void EliminaTodosEnemigos(GameObject e)//no hace falta este método, lo hace todo el siguiente
        {
            prim = null;
            
        }

        public GameObject DamePrimeroParaEmpujar()//esto metodo se utilizara en un bucle y dara de 1 en 1 el primero de la lsita para poder empujarlo hasta que esté vacía
        {
            Enemigo aux = prim;
            

            if (aux != null)
                return aux.enem;
            else return null;
        }
        public void AvanzaPrimer()
        {
            if (prim != null)
                prim = prim.sig;
        }

        public int nEnemigos()//muestra el total de enemigos que hay en la lista
        {
            Enemigo aux = prim;
            int x = 0;
            while(aux != null)
            {
                aux = aux.sig;
                x++;
            }
            return x;
        }
        public void EliminaEnemig(GameObject e)//este sirve para cundo salgan del trigger salgan de la lista que se va a utilizar para empujar
        {
            int x = EnemigoN(e);
            if (x == 0)
            {
                Debug.Log("No hay enemigos");
            }
            else if(x == 1)
            {
                prim = null;
            }
            else 
            {
                Enemigo anterior = DameEnemigoN(x - 1);
                anterior.sig = anterior.sig.sig;
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<EnemyHealth>())
        {
            if (!lista.BuscaGameOBject(collision.gameObject))//cuando entra unenemigo en el trigger se añade a la lista
            {
                lista.AddPrincipio(collision.gameObject);
             
            }
        }
        



    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyHealth>()) //Cunado sale un enemigo del trigger se elimina de la lista
        {
            lista.EliminaEnemig(collision.gameObject);
           
        }
       
    }

   void ActivaAnimacion()                           //Pasa de la animacion estatica a la de ataque
    {
        animator.SetBool("Ataque", true);
    }

    void ParaAnimacion()                            //Pasa de la animacion de ataque a la estatica
    {
        animator.SetBool("Ataque", false);
    }

   
    private void VelOriginal()
    {
        movPlayer.CambiaVel(guardarVel);
      
        Debug.Log("masRapido");
    }

}
