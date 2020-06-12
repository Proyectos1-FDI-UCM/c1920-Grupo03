using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image[] pocion;
    public Image [] anillosSprite;
    HealthBar health;
    Potion pc;
    GameObject barraVida;
    Slider slider;

    

    void Start()
    {
        slider = GetComponentInChildren<Slider>();
       
        barraVida = transform.GetChild(1).gameObject;
        health = barraVida.GetComponent<HealthBar>();
        for (int x = 0; x  < anillosSprite.Length; x++) anillosSprite[x].enabled = false; //Para no perder información en el cambio de escena implementar un array de booleanos en el gamemanager
                                                                                          //que indique los anillos que tenemos.

        GameManager.instance.SetUIManager(this);
    }
    public void SetMaxHealth(int x)
    {
        slider.maxValue = x;
    }

    //para llmar al otro script
    public  void CambiarVida(int x)
    {
        slider.value = x;
    }

    
 
    public void CambiarAnillos(int i, bool cambio)
    {
        
            anillosSprite[i].enabled = cambio;
        

    }
    public void CambioPociones(int y)//Activa el sprite de la poción que tiene y desactiva las mayores
    {
        if (y < 0 || y > 9)
        {
            Debug.Log("numero de pociones no valido");
        }
        else
        {
            
                pocion[y].enabled = true;
            
            for(int x = y+1; x<pocion.Length; x++)
            {
                pocion[x].enabled = false;
            }

        }
    }
}
