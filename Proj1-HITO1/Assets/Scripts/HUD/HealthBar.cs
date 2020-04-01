using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        SetMaxHealth(100);
        SetHealth(100);//tener quidado con esto, hay que hacerlo desde gamemanager
    }

    // Update is called once per frame
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}