using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
   
    public void setMaxHeatlh(int health)
    {
        this.slider.maxValue = health;
        this.slider.value = health;
    }
    private void setHealth(int health)
    {
        this.slider.value = health;
    }
}
