using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private HealthBar health;
    public static GameManager instance;
    private UIManager theUIManager;
    private GameObject player;
    bool Ring2;
    bool Ring4;

    int unexploredRooms = 0, currentHealth = 100, maxHealth = 100, h, cargas, normRest = 8;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }
    void Start()
    {
        currentHealth = maxHealth;
        theUIManager.SetMaxHealth(currentHealth);
        Ring2 = false;
        Ring4 = false;
    }  
    public void SetPlayer(GameObject theplayer)
    {
        player = theplayer;
    }

    public void SetUIManager(UIManager uim)
    {
        theUIManager = uim;
    }
    
    public void TakeDamage(int damage)
    {
        if (currentHealth - damage > 0)
        {
            currentHealth -= damage;
            theUIManager.CambiarVida(currentHealth);

           // Debug.Log(currentHealth);
        }

        else player.GetComponent<DiePlayer>().Call();
    }
    public void Restore()
    {
        
        cargas = unexploredRooms / 2;
        theUIManager.CambioPociones(cargas);
        h = normRest * cargas + 3 * cargas; //?
                                            //cargas = 0;
    }
    public void Restor()
    {
        if (currentHealth + h < maxHealth)
            currentHealth += h;
        else currentHealth = maxHealth;
        theUIManager.CambiarVida(currentHealth);
        unexploredRooms = 0;
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
        SceneManager.LoadScene(nivel);
    }

   public void PickRing2()      //cuando el player coge el anillo 2 lo activa en el GameManager
    {
        Ring2 = true;
    }

    public bool ReturnRing2()       //para decirle a otros EnemyHealth si Ring2 esta activo o no
    {
        return Ring2;
    }

    public void PickRing4()      //cuando el player coge el anillo 4 lo activa en el GameManager
    {
        Ring4 = true;
    }

    public bool ReturnRing4()       //para decirle a DmgEnemyMelee si Ring4 esta activo o no
    {
        return Ring4;
    }




}

