using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider slider;
    public Text manaText;

    private int maxMana;
    public void setMaxMana(int mana)
    {
        maxMana = mana;
        manaText.text = string.Format("{0:0}/{1:0}", mana, maxMana);
        this.slider.maxValue = mana;
        this.slider.value = mana;
    }
    public void setMana(int mana)
    {
        manaText.text = string.Format("{0:0}/{1:0}", mana, maxMana);
        this.slider.value = mana;
    }
}
