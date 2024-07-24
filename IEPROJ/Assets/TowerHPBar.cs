using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHPBar : MonoBehaviour
{
    public Slider slider;

    private int maxHealth;
    public void setMaxHealth(int health)
    {
        maxHealth = health;
        this.slider.maxValue = health;
        this.slider.value = health;
    }
    public void setHealth(int health)
    {
        this.slider.value = health;
    }
}
