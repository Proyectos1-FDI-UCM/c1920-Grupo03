using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDePausa : MonoBehaviour
{


    public static bool isPaused;
    public GameObject pauseMenu;
    private void Start()
    {
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !transform.GetChild(1).gameObject.activeSelf)
        {
            if (isPaused)
            {
                Resume();
            }
            else Pause();
        }


       
    }
    public void Resume()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }


    void Pause()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
