using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Card
{
    public string cardType;
    public string description;
    public string cardName;
    public int cardID;
    public int cost;
    public Sprite artwork;


    private void Start()
    {
    }
    public Card(int cardID,int cost,string cardType, string description, string name, Sprite artwork)
    {
        this.cardID = cardID;
        this.cardType = cardType;
        this.description = description;
        this.cardName = name;
        this.cost = cost;
        this.artwork = artwork;
    }

}
