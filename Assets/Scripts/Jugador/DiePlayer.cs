using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiePlayer : MonoBehaviour
{
    [SerializeField] GameObject CanvasMenu;
    private void Start()
    {
        GameManager.instance.SetPlayer(this.gameObject);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
            GameManager.instance.Restor();
        
    }
   
    public void Call()
    {
        CanvasMenu.GetComponent<MenuDeMuerte>().DeathMenu();
        Destroy(this.gameObject);
        

    }
}
