using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviour
{
    public int manaPool = 0; // The player's mana pool
    public ManaBar manaBar;

    //PhotonView view;

  
    private void OnDisable()
    {
        EventManager.UseMana -= RemoveMana;
    }
    private void Start()
    {
        EventManager.UseMana += RemoveMana;
        manaBar.setMaxMana(manaPool);
        //view = GetComponent<PhotonView>();
    }
    private void Update()
    {
        //if (view.IsMine)
        //{
        //    EventManager.trackMana(manaPool);
        //}

        EventManager.trackMana(manaPool);
    }
    public void AddMana(int amount)
    {
        manaPool += amount;
        manaBar.setMana(manaPool);
        Debug.Log("Mana added. Current mana: " + manaPool);
    }

    public void RemoveMana(int mana)
    {
        manaPool -= mana;
        if(manaPool < 0)
        {
            manaPool = 0;
        }
        manaBar.setMana(manaPool);
        Debug.Log("Mana removed. Current mana: " + manaPool);
    }
}
