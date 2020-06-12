using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampasManager : MonoBehaviour
{
    private DesacPinchos trampaPinchos;
    private DesacBola trampaBola;
    private DesacBallesta trampaBallesta;

    //coge todas las componentes de sus hijos y desactiva las trampas inicialmente
    void Start()
    {
        trampaPinchos = GetComponentInChildren<DesacPinchos>();
        trampaBola = GetComponentInChildren<DesacBola>();
        trampaBallesta = GetComponentInChildren<DesacBallesta>();
        ChangeState(false);
    }
    //desactiva todas las trampas de la sala
    public void DesactivarTrampas()
    {
        if (trampaPinchos != null) trampaPinchos.Desactivar();
        if (trampaBola != null) trampaBola.Desactivar();
        if (trampaBallesta != null) trampaBallesta.Desactivar();

    }
    //destruye el collider y activa a sus hijos
    public void DestruirCollider()
    {
        Destroy(this.GetComponent<Collider2D>());
        ChangeState(true);
    }
    //activa a los hijos
    void OnTriggerEnter2D()
    {
        ChangeState(true);
    }
    //desactiva a los hijos
    void OnTriggerExit2D()
    {
        if(GetComponent<Movimiento8D>())
        ChangeState(false);
    }
    void ChangeState(bool activar)
    {
        for (int x = 0; x < transform.childCount; x++) transform.GetChild(x).gameObject.SetActive(activar);
    }
}
