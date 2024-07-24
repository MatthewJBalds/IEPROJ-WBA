using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider slider;
    public Text manaText;

    private int maxMana;
    private int currentMana;

    private void Start()
    {
        EventManager.TrackMaxMana += setMaxMana;
        EventManager.TrackMana += setMana;
    }

    private void OnDisable()
    {
        EventManager.TrackMaxMana -= setMaxMana;
        EventManager.TrackMana -= setMana;
    }
    public void setMaxMana(int mana)
    {
        maxMana = mana;
        currentMana = mana;
        manaText.text = string.Format("{0:0}/{1:0}", mana, maxMana);
        this.slider.maxValue = mana;
        this.slider.value = mana;
    }
    public void setMana(int mana)
    {
        currentMana = mana;
        if (currentMana >= maxMana)
        {
            maxMana = currentMana;
            this.slider.maxValue = mana;
        }
        manaText.text = string.Format("{0:0}/{1:0}", mana, maxMana);
        
        this.slider.value = mana;
    }
}
