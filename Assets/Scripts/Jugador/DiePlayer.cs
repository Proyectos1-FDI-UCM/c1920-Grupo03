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

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
            GameManager.instance.Restor();
        
    }
    MenuDeMuerte menuDeMuerte;
    public void Call()
    {
        menuDeMuerte = GetComponent<MenuDeMuerte>();
        menuDeMuerte.DeathMenu();
        Destroy(this.gameObject);
        

    }
}
