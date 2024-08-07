using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMana : MonoBehaviour
{
    public int manaPool = 0; // The player's mana pool
                             //public ManaBar manaBar;

    //PhotonView view;


    private void OnDisable()
    {
        EventManager.UseEnemyMana -= RemoveMana;
    }
    private void Start()
    {
        EventManager.UseEnemyMana += RemoveMana;
    }
    private void Update()
    {

    }
    public void AddMana(int amount)
    {
        manaPool += amount;
        //manaBar.setMana(manaPool);
        Debug.Log("Mana added. Current mana: " + manaPool);
    }

    public void RemoveMana(int mana)
    {
        manaPool -= mana;
        if (manaPool < 0)
        {
            manaPool = 0;
        }
        //manaBar.setMana(manaPool);
        Debug.Log("Mana removed. Current mana: " + manaPool);
    }
}
