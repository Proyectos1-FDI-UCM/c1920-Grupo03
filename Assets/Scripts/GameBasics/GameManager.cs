using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static bool anillo1 = false;
    private bool invencible = false;
    static private bool[] armas = { false, false, false };
    static private bool [] ring = { false,false,false,false};
    private HealthBar health;
    public static GameManager instance;
    private UIManager theUIManager;
    private GameObject player;
    
    
    // bool Ring2;
    //bool Ring4;
    static int currentHealth = 100,cargas, unexploredRooms=0, h;
    int  maxHealth = 100, normRest = 8;

   
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);

    }
    void Start()
    {
        

        //while (!armas[cont] && cont < armas.Length) cont++;
        //if (cont < armas.Length) ActivarArma(cont);
       
        for (int x = 0; x < ring.Length; x++) ActivarAnillos(x,ring[x]);
        // no se si deberia hacer la asignacion de cargas otra vez(no se si se ejecuta esto antes o el metodo de restore, lo cual hace variar las cargas de pociones debido a la primera habitación de cada nivel)
        if(theUIManager != null)
        {
            theUIManager.CambioPociones(cargas);
            currentHealth = maxHealth;
           
        }
        

        //Ring2 = false;
        //Ring4 = false;

    }
    public void ActivarAnillo1()
    {
        anillo1 = true;
    }
    public bool AnilloDash()
    {
        return anillo1;
    }
    public void SetPlayer(GameObject theplayer)
    {
        int cont = 0;
        player = theplayer;
        while (cont < armas.Length && !armas[cont]) cont++;
        if (cont < armas.Length) ActivarArma(cont);
        ActivarArma(cont);
        if (anillo1) player.GetComponent<Dash>().enabled = true;
    }
    public void ActivarArma(int num)
    {
        player.GetComponent<Armas>().Activar(num);
    }

    public void ActBoolArma(int num)
    {
        armas[num] = true;
    }
    public void SetUIManager(UIManager uim)
    {
        theUIManager = uim;
       
        Invoke("ActualizaSlider", 0.1f);

        for (int x = 0; x < 4; x++)
        {
            theUIManager.CambiarAnillos(x, ring[x]);
        }
        
    }
    


    public void TakeDamage(int damage)
    {
        if (!invencible)
        {
            
            if (currentHealth - damage > 0)
            {
                currentHealth -= damage;

                theUIManager.CambiarVida(currentHealth);
                // Debug.Log(currentHealth);
            }

            else player.GetComponent<DiePlayer>().Call();
        }
    }


    public void ActualizaSlider()
    {
        theUIManager.CambiarVida(currentHealth);
    }


    //public void Invencibilidad(bool activo)
    //{
        
    //    invencible = activo;
       
    //}


    public void Restore()
    {        
        cargas = unexploredRooms / 2;
        theUIManager.CambioPociones(cargas);
        h = normRest * cargas + 3 * cargas; //?
                                            //cargas = 0;
    }
    public void Restor()
    {
        if (h > 0)
        {
            if (currentHealth + h < maxHealth)
                currentHealth += h;
            else currentHealth = maxHealth;
            theUIManager.CambiarVida(currentHealth);
            unexploredRooms = 0;
            Restore();
        }
        
    }
   
    public void AddRoom()
    {
        unexploredRooms++;
        Restore();
    }
    
    public int GetHealth()
    {
        return currentHealth;
    }

    public void CargarNivel(string nivel)
    {
        SceneManager.LoadScene(nivel, LoadSceneMode.Single);
        Time.timeScale = 1;
        
    }
    

    public void ResetinitialState()
    {
        for (int x = 0; x < armas.Length; x++) armas[x] = false;
        currentHealth = 100;
        unexploredRooms = 0;
        cargas = 0;
        for (int x = 0; x < ring.Length; x++) ring[x] = false;
        h = 0;
    }

   
    // quitar bool en caso de que no sea necesario desactivarlos(comprobar cambio nivel)
    public void ActivarAnillos(int num, bool cambio)
    {
        if (theUIManager != null)
        {
            theUIManager.CambiarAnillos(num, cambio);
            ring[num] = cambio;
        }

    }

  
    public bool ReturnRing(int num)
    {
        return ring[num - 1];
    }


    public void SalirDelJuego()
    {
        Debug.Log("Sale del juego");
        Application.Quit();
    }


}

