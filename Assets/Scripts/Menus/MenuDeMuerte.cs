using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDeMuerte : MonoBehaviour
{
    
    public GameObject deathMenu;
    
    public void DeathMenu()
    {
       
        deathMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
