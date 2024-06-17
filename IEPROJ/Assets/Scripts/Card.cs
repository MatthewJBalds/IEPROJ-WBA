using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private GameObject cardBack;
    private Vector3 position;
    [SerializeField]
    private string cardType;
    [SerializeField]
    private string description;
    [SerializeField]
    private string cardName;

    public Vector3 Position
    {
        get { return position; }
        set { position = value; }
    }
    public GameObject CardBack
    {
        get { return cardBack; }
        set { cardBack = value; }
    }
    public string CardName
    {
        get { return cardName; }
    }
    public Card(string cardType, string description, string name)
    {
        this.cardType = cardType;
        this.description = description;
        this.cardName = name;
        this.position = this.transform.position;
    }
}
