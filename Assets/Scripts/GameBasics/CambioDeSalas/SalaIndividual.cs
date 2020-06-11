using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaIndividual : MonoBehaviour
{
    GameObject[] enemigosSala;
    //BossSala boss;
    Puertas puertas;
    Deshabilitado desh;
    //ObjetoRecogible recogibles;
    EnemigosSala enem;
    int enemigosViv = 0;
    bool hayEnemigos = false, playerDentro;

    void Start()
    {

        enem = GetComponentInChildren<EnemigosSala>();

        if (enem != null)
            hayEnemigos = enem.gameObject.transform.childCount > 0;

        if (hayEnemigos)
        {
            enemigosSala = new GameObject[enem.gameObject.transform.childCount];
            for (int x = 0; x < enem.gameObject.transform.childCount; x++) enemigosSala[x] = enem.gameObject.transform.GetChild(x).gameObject;
        }

        puertas = GetComponentInChildren<Puertas>();
        desh = GetComponentInChildren<Deshabilitado>();
        if (GetComponentInChildren<ObjetoRecogible>() != null)
        {
            puertas.ActivarPuertas(true);
        }

    }

    //Código matar enemigos en sala

    //void Update()
    //{

    //    if (Input.GetKeyDown(KeyCode.K) && playerDentro && hayEnemigos)
    //    {
    //        EliminarEnem();
    //    }
    //}

    //void EliminarEnem()
    //{
    //    for (int x = 0; x < enemigosSala.Length; x++)
    //    {
    //        if (enemigosSala[x] != null)
    //            enemigosSala[x].SetActive(false);
    //    }


    //    hayEnemigos = false;
    //}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Movimiento8D>() != null)
        {
            if (GetComponentInChildren<TrampasManager>() != null)
                collision.GetComponent<Dash>().enabled = false;

            playerDentro = true;


            if (hayEnemigos)
                enem.ActivarEnemigos(collision);
            else if (this.GetComponentInChildren<BossSala>() != null)
                this.GetComponentInChildren<BossSala>().ActivarBoss(collision);
            else if (GetComponentInChildren<BossArqueroSala>() != null)
                GetComponentInChildren<BossArqueroSala>().ActivarBoss(collision);
            desh.Deshabilitarse();
            if (enemigosViv > 0)
                Accionar(true);

            GameManager.instance.AddRoom();
            //  Debug.Log("Hola he chocado");
            Destroy(this.gameObject.GetComponent<Collider2D>());
        }


    }
    public void Trampas()
    {
        TrampasManager trampas = GetComponentInChildren<TrampasManager>();
        trampas.DestruirCollider();
        trampas.DesactivarTrampas();
        

        }
    public void RecibeEnemigos(int enemigos)
    {
        enemigosViv = enemigos;
    }
 


    public void Accionar(bool estado)
    {        
        if(puertas != null)
        puertas.ActivarPuertas(estado);
    }
}
