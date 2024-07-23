using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int manaPool = 0; // The player's mana pool
    public ManaBar manaBar;

    private void Awake()
    {
        EventManager.UseMana += RemoveMana;
    }
    private void OnDisable()
    {
        EventManager.UseMana -= RemoveMana;
    }
    private void Start()
    {
        manaBar.setMaxMana(manaPool);
    }
    public void AddMana(int amount)
    {
        manaPool += amount;
        manaBar.setMana(manaPool);
        EventManager.trackMana(amount);
        Debug.Log("Mana added. Current mana: " + manaPool);
    }

    public void RemoveMana(int mana)
    {
        manaPool -= mana;
        manaBar.setMana(manaPool);
        EventManager.trackMana(manaPool);
        Debug.Log("Mana removed. Current mana: " + manaPool);
    }
}
