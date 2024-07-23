using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int manaPool = 0; // The player's mana pool
    public ManaBar manaBar;

    private void Start()
    {
        manaBar.setMaxMana(manaPool);
    }
    public void AddMana(int amount)
    {
        manaPool += amount;
        manaBar.setMana(manaPool);
        Debug.Log("Mana added. Current mana: " + manaPool);
    }
}
