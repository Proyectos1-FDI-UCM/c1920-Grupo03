using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueLanza : MonoBehaviour
{
    //En esencia igual al script "Martillo"


    Animator anim;
    public int amount = 20;
    //los enemigos dentro del rango de ataque se introducen en una lista
    ListaEnemigosDentro lista;
    bool atacando ;
    //delay entre ataques
    float hitRate = 1.5f, nextHit = 0;
    
    void Start()
    {
        anim = GetComponentInParent<Animator>();        
        atacando = false;
        lista = new ListaEnemigosDentro();
    }

    // si se ha completado el delay entre ataques y el juagdor pulsa click izquierdo:
    void Update()
    {
        if(Time.time > nextHit && Input.GetMouseButtonDown(0))
        {
            //reinicia cooldown
            nextHit = Time.time + hitRate;
            //se activa la animación de ataque
            anim.SetBool("Ataque", true);
            //se ejecuta el ataque con algo de delay para coincidir con la animación
            Invoke("Ataque",0.9f);
            
        }
    }
    void Ataque()
    {        
        //mientras hayan enemigos dentro de la lista de enemigos para realizar daño
        while (lista.DamePrimeroParaEmpujar() != null)
        {            
            //cojo sus componentes rIgidbody
            GameObject enemigo = lista.DamePrimeroParaEmpujar();            
                Rigidbody2D enemy = enemigo.GetComponent<Rigidbody2D>();
            //en caso de que este tenfga rigidbody
                if (enemy != null)
                {
                //le realizo daño
                EnemyHealth vidaEnmigo = enemy.GetComponent<EnemyHealth>();
                vidaEnmigo.TakeDamage(amount);
            }
            
        }
        // "apago" la animación para evitar que se pueda repetir
        anim.SetBool("Ataque", false);
    }

    //si el objeto que ha entrado en el trigger es enemigo, lo añado a la lista de enemigos a dañar
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<EnemyHealth>())
        {
            if (!lista.BuscaGameOBject(collision.gameObject))
            {
                lista.AddPrincipio(collision.gameObject);
                
            }
        }

    }

    //cuando un objeto enemigo sale, se elimina el mismo de la lista
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyHealth>())
        {
            lista.EliminaEnemig(collision.gameObject);
            
        }

    }
}

//Clase de listas utilizada 
public class ListaEnemigosDentro
{
    //clase enemigo interna
    private class Enemigo
    {
        public GameObject enem;
        public Enemigo sig;

       //constructora clase enemigo
        public Enemigo(GameObject e, Enemigo next)
        {
            enem = e;
            sig = next;            
        }
    }

    Enemigo prim;

    //constructora de clase ListaEnemigosDentro
    public ListaEnemigosDentro()
    {
        prim = null;
    }

    public int EnemigoN(GameObject e)//busca el numero del  nodo que tiene el siguiente gameobject
    {

        int x = 1;
        Enemigo aux = prim;
        while (aux != null && aux.enem != e)
        {
            x++;
            aux = aux.sig;
        }
        if (aux == null) x = 0;
        return x;
    }

    // devuelve un objeto de la clase enemigo en la posición n de la lista
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

    //añade un enemigo al inicio de la lista
    public void AddPrincipio(GameObject e)
    {

        Enemigo nuevo = new Enemigo(e, prim);
        prim = nuevo;


    }

    //busca en la lista un objeto enemigo cuyo GO coincida con el del objeto recibido como parámetro
    public bool BuscaGameOBject(GameObject e)
    {
        Enemigo aux = prim;


        while (aux != null && aux.enem != e)
        {
            aux = aux.sig;
        }



        return aux != null;
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
        while (aux != null)
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
        else if (x == 1)
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

