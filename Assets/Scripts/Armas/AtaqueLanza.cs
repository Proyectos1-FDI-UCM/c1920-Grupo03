using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueLanza : MonoBehaviour
{
    public int amount = 20;
    ListaEnemigosDentro lista;
    bool atacando ;
    float hitRate = 1.5f, nextHit = 0;
    // Start is called before the first frame update
    void Start()
    {
        atacando = false;
        lista = new ListaEnemigosDentro();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextHit && Input.GetMouseButtonDown(0))
        {
            nextHit = Time.time + hitRate;
            Ataque();
        }
    }
    void Ataque()
    {
        while (lista.DamePrimeroParaEmpujar() != null)
        {
            
            GameObject enemigo = lista.DamePrimeroParaEmpujar();            
                Rigidbody2D enemy = enemigo.GetComponent<Rigidbody2D>();
                if (enemy != null)
                {
                EnemyHealth vidaEnmigo = enemy.GetComponent<EnemyHealth>();
                vidaEnmigo.TakeDamage(amount);
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<EnemyHealth>())
        {
            if (!lista.BuscaGameOBject(collision.gameObject))
            {
                lista.AddPrincipio(collision.gameObject);
                // Debug.Log("Entraenem");

                //  Debug.Log("Lista: " + lista.nEnemigos());
            }
        }




    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyHealth>())
        {
            lista.EliminaEnemig(collision.gameObject);
            //Debug.Log("SaleEnem");
        }



        // Debug.Log("Lista: " + lista.nEnemigos());
    }
}
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
        while (aux != null && aux.enem != e)
        {
            x++;
            aux = aux.sig;
        }
        if (aux == null) x = 0;
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

