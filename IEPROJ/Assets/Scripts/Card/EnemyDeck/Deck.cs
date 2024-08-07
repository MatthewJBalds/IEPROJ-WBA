using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    public static DeckManager Instance;
    [SerializeField]
    private List<Card> deck = new List<Card>();
    public GameObject cardInDeck;
    public static List<Card> staticDeck = new List<Card>();
    public static int deckSize;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.ExampleEvent += DrawCard;
        EventManager.DeckEvent += RemoveAtStart;
        EventManager.MoveCardEvent += MoveCard;
        deckSize = 8;
        for (int i = 0; i < deckSize; i++)
        {
            deck[i] = CardDatabase.CardsDatabase[0];
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
            cards[n] = temp;

        }
    }

    public void RemoveAtStart()
    {
        deck.RemoveAt(deck.Count - 1);
    }
    public void DrawCard()
    {
        if (deckSize == 5)
        {
            StartCoroutine(WaitForDraw());
        }
    }

    IEnumerator WaitForDraw()
    {
        yield return new WaitForSeconds(0.3f);
        Instantiate(cardInDeck, transform.position, transform.rotation);

    }

    public void MoveCard(int id)
    {
        deck.Insert(0, CardDatabase.CardsDatabase[id]);
        Debug.Log(id);
    }
    private void OnDisable()
    {
        EventManager.ExampleEvent -= DrawCard;
        EventManager.DeckEvent -= RemoveAtStart;
    }
}
