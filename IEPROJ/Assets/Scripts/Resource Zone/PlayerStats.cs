using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int manaPool = 0; // The player's mana pool

    public void AddMana(int amount)
    {
        manaPool += amount;
        Debug.Log("Mana added. Current mana: " + manaPool);
    }
}
