using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
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
        manaText.text = currentMana.ToString();
    }
    public void setMana(int mana)
    {
        currentMana = mana;
        if (currentMana >= maxMana)
        {
            maxMana = currentMana;
        }
        manaText.text = currentMana.ToString();
        
    }
}
