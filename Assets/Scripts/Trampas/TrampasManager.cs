using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampasManager : MonoBehaviour
{
    private DesacPinchos trampaPinchos;
    private DesacBola trampaBola;
    private DesacBallesta trampaBallesta;
    void Start()
    {
        trampaPinchos = GetComponentInChildren<DesacPinchos>();
        trampaBola = GetComponentInChildren<DesacBola>();
        trampaBallesta = GetComponentInChildren<DesacBallesta>();
        ChangeState(false);
    }
    public void DesactivarTrampas()
    {
        if (trampaPinchos != null) trampaPinchos.Desactivar();
        if (trampaBola != null) trampaBola.Desactivar();
        if (trampaBallesta != null) trampaBallesta.Desactivar();

    }
    public void DestruirCollider()
    {
        Destroy(this.GetComponent<Collider2D>());
        ChangeState(true);
    }
    void OnTriggerEnter2D()
    {
        ChangeState(true);
    }
    void OnTriggerExit2D()
    {
        ChangeState(false);
    }
    void ChangeState(bool activar)
    {
        for (int x = 0; x < transform.childCount; x++) transform.GetChild(x).gameObject.SetActive(activar);
    }
}
