using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public static DeckManager Instance;
    [SerializeField]
    private List<Card> deck = new List<Card>();
    [SerializeField]
    private GameObject cardBack;

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
        PlayCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void PlayCards()
    {
        Shuffle(deck);
        foreach (Card card in deck)
        {
            card.CardBack = cardBack;
            print(card.CardName);
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
        float zOffset = 0.03f;

        foreach (Card card in deck)
        {

            card.Position = new Vector3(card.Position.x, card.Position.y, card.Position.z - zOffset);
            GameObject newCard = Instantiate(cardBack, card.Position, Quaternion.identity);

            zOffset += 0.03f;
        }
    }
}
