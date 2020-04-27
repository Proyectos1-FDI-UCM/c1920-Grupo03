using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiePlayer : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.SetPlayer(this.gameObject);
    }

    public void Call()
    {
        Destroy(this.gameObject);
        GameManager.instance.CargarNivel("Nivel1HUD");
    }
}
