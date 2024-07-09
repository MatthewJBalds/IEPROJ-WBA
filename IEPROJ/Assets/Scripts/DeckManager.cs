using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public static DeckManager Instance;
    [SerializeField]
    private List<Card> deck = new List<Card>();
    public GameObject cardInDeck;
    public static List<Card> staticDeck = new List<Card>();
    public static int deckSize;

    public GameObject[] Clones;
    public GameObject Hand;

    void Awake()
    {
        if (Instance != null && Instance == this)
        {
            Instance = this;
        }
        else
            Destroy(Instance);

    }
    // Start is called before the first frame update
    void Start()
    {
        EventManager.ExampleEvent += DrawCard;
        deckSize = 8;
        for (int i = 0; i < deckSize; i++)
        {
            deck[i] = CardDatabase.CardsDatabase[i];
        }
        PlayCards();
    }

    // Update is called once per frame
    void Update()
    {
        staticDeck = deck;
      
    }
    private void PlayCards()
    {
        Shuffle(deck);
        foreach (Card card in deck)
        {
            //card.CardBack = cardBack;
            print(card.cardName);
        }
        Deal();

    }

    private void Shuffle<T>(List<T> cards)
    {
        System.Random rand = new System.Random();
        int n = cards.Count;
        while (n > 1)
        {
            int k = rand.Next(n);
            n--;
            T temp = cards[k];
            cards[k] = cards[n]; 
            cards[n]= temp;

        }
    }

    private void Deal()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        for(int i =0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.3f);
            
            Instantiate(cardInDeck, transform.position,transform.rotation);
        }
    }
    public void DrawCard()
    {
        if (deckSize == 5)
        {
            Instantiate(cardInDeck, transform.position, transform.rotation);
        }
    }
    private void OnDisable()
    {
        EventManager.ExampleEvent -= DrawCard;
    }
}
