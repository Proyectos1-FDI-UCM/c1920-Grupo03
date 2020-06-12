using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //bool que controla si se ha recogido el anillo 1
    static bool anillo1 = false;
    // bool para el testeo(para activar la invencibilidad)
    private bool invencible = false;

    // booleano que controla que arma esta activa
    static private bool[] armas = { false, false, false };
    //bool que controla que anillos están activos
    static private bool [] ring = { false,false,false,false};
    private HealthBar health;
    public static GameManager instance;
    private UIManager theUIManager;
    private GameObject player;
  

    static int currentHealth = 100,cargas, unexploredRooms=0, h;
    int  maxHealth = 100, normRest = 8;

   // se ocupa de que solo haya un GO en escena
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
       //activa los anillos que el juagdor haya recogido
        for (int x = 0; x < ring.Length; x++) ActivarAnillos(x,ring[x]);
        
        //si existe el UI se actualiza y se asigna el valor de currentHealth
        if(theUIManager != null)
        {
            theUIManager.CambioPociones(cargas);
            currentHealth = maxHealth;
           
        }
        
    }
    // pone a true el booleano de coger el anillo 1
    public void ActivarAnillo1()
    {
        anillo1 = true;
    }
    //devuelve el estado del booleano anillo1
    public bool AnilloDash()
    {
        return anillo1;
    }
    //el gameObject recibe al player como GO y se ocupa de actualizarlo al pasar de nivel(activa el arma que haya recogido y le mantiene el dash en caso de haber recogido el anillo 1)
    public void SetPlayer(GameObject theplayer)
    {
        int cont = 0;
        player = theplayer;
        while (cont < armas.Length && !armas[cont]) cont++;
        
        ActivarArma(cont);
        if (anillo1) player.GetComponent<Dash>().enabled = true;
    }

    //activa el arma que el jugador hubiese recogido
    public void ActivarArma(int num)
    {
        player.GetComponent<Armas>().Activar(num);
    }
    //activa el bool de la posición num del array armas, poniendo a true la posición correspondiente a cada arma
    public void ActBoolArma(int num)
    {
        armas[num] = true;
    }

    //el GameManager recibe el UImanager y se actualiza
    public void SetUIManager(UIManager uim)
    {
        theUIManager = uim;
       
        Invoke("ActualizaSlider", 0.1f);

        for (int x = 0; x < 4; x++)
        {
            theUIManager.CambiarAnillos(x, ring[x]);
        }
        
    }
    

    //cambia el slider dependiendo del daño que el jugador reciba
    public void TakeDamage(int damage)
    {
        if (!invencible)
        {
            if (currentHealth - damage > 0)
            {
                currentHealth -= damage;

                theUIManager.CambiarVida(currentHealth);
            }

            else
            {
                currentHealth = 0;
                theUIManager.CambiarVida(currentHealth);
                // en caso de que el jugador muera, se activa el componente DiePlayer
                player.GetComponent<DiePlayer>().Call();
            }
        }
    }

    // actaliza el slider 
    public void ActualizaSlider()
    {
        theUIManager.CambiarVida(currentHealth);
    }

    //metodo para hacer invencible al jugador(testeo)
    //public void Invencibilidad(bool activo)
    //{
        
    //    invencible = activo;
       
    //}


        //actualiza las cargas de la poción, así como la vida que se restaura al utilizarla
    public void Restore()
    {        
        cargas = unexploredRooms / 2;
        theUIManager.CambioPociones(cargas);
        h = normRest * cargas + 3 * cargas; 
    }
    //restaura h vida al jugador y actualiza variables y  UI en consecuencia
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
   
    // añade uno cada vez que el jugador entra en una sala(aumenta cargas de pociones)
    public void AddRoom()
    {
        unexploredRooms++;
        Restore();
    }
    //devuelve la vida actual del jugador
    public int GetHealth()
    {
        return currentHealth;
    }

    // carga el nivel teniendo en cuenta el string que reciba
    public void CargarNivel(string nivel)
    {
        SceneManager.LoadScene(nivel, LoadSceneMode.Single);
        Time.timeScale = 1;
        
    }
    
    // actualiza UI al coger anillo y cambia su respectivo bool del array ring
    public void ActivarAnillos(int num, bool cambio)
    {
        if (theUIManager != null)
        {
            theUIManager.CambiarAnillos(num, cambio);
            ring[num] = cambio;
        }

    }

  //devuelve el bool del num recibido - 1
    public bool ReturnRing(int num)
    {
        return ring[num - 1];
    }

    // cierra el juego
    public void SalirDelJuego()
    {
        Debug.Log("Sale del juego");
        Application.Quit();
    }


}

