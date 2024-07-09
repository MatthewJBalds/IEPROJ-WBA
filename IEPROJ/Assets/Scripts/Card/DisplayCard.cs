using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisplayCard : MonoBehaviour
{
    public List<Card> displayCard = new List<Card>();
    public int displayID;

    [SerializeField]
    private string displayType;
    [SerializeField]
    private string displayDescription;
    [SerializeField]
    private string displayName;
    public int ID;
    [SerializeField]
    private int displayCost;
    [SerializeField]
    private Sprite spriteImage;

    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text descriptionText;
    [SerializeField]
    private Text typeText;
    [SerializeField]
    private Text costText;
    [SerializeField]
    private Image artImage;

    public GameObject Hand;
    public int numOfCardInDeck;

    // Start is called before the first frame update
    void Start()
    {
        numOfCardInDeck = DeckManager.deckSize;
        displayCard[0] = CardDatabase.CardsDatabase[displayID];

    }

    // Update is called once per frame
    void Update()
    {
        
        this.ID = displayCard[0].cardID;
        this.displayName = displayCard[0].cardName;
        this.displayCost = displayCard[0].cost;
        this.displayDescription = displayCard[0].description;
        this.displayType = displayCard[0].cardType;
        this.spriteImage = displayCard[0].artwork;

        nameText.text = " " + this.displayName;
        typeText.text = " " + this.displayType;
        descriptionText.text = " " + this.displayDescription;
        costText.text = " " + this.displayCost;
        artImage.sprite = this.spriteImage;

        Hand = GameObject.Find("Hand");
       
        if(this.tag == "Clone")
        {
            displayCard[0] = DeckManager.staticDeck[numOfCardInDeck - 1];
            numOfCardInDeck -= 1;
            DeckManager.deckSize -= 1;
            EventManager.RemoveCard();
            this.tag = "Untagged";
        }
    }
}
