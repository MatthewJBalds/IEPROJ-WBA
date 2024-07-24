using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Text hpText;

    private int maxHealth;

    private void Start()
    {
        EventManager.TrackHP += setMaxHealth;
        EventManager.TrackHP += setHealth;
    }

    private void OnDisable()
    {
        EventManager.TrackHP -= setMaxHealth;
        EventManager.TrackHP -= setHealth;
    }
    public void setMaxHealth(int health)
    {
        maxHealth = health;
        hpText.text = string.Format("{0:0}/{1:0}", health, maxHealth);
        this.slider.maxValue = health;
        this.slider.value = health;
    }
    public void setHealth(int health)
    {
        hpText.text = string.Format("{0:0}/{1:0}", health, maxHealth);
        this.slider.value = health;
    }
}
