using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
   
    public void setMaxHealth(int health)
    {
        this.slider.maxValue = health;
        this.slider.value = health;
    }
    public void setHealth(int health)
    {
        this.slider.value = health;
    }
}
