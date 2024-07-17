using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> CardsDatabase = new List<Card>();
    //public GameObject[] cardPrefabs; //[SEE] Card Casting under Player.

    // Start is called before the first frame update
    void Awake()
    {
        CardsDatabase.Add(new Card(0, 1,"Summon","N/A","Card1", Resources.Load<Sprite>("tree")));
        CardsDatabase.Add(new Card(1, 1, "Spell", "N/A", "Card2", Resources.Load<Sprite>("tree")));
        CardsDatabase.Add(new Card(2, 1,"Summon", "N/A", "Card3", Resources.Load<Sprite>("tree")));
        CardsDatabase.Add(new Card(3, 1,"Spell", "N/A", "Card4", Resources.Load<Sprite>("tree")));
        CardsDatabase.Add(new Card(4, 1, "Summon", "N/A", "Card5", Resources.Load<Sprite>("tree")));
        CardsDatabase.Add(new Card(5, 1, "Spell", "N/A", "Card6", Resources.Load<Sprite>("tree")));
        CardsDatabase.Add(new Card(6, 1, "Summon", "N/A", "Card7", Resources.Load<Sprite>("tree")));
        CardsDatabase.Add(new Card(7, 1, "Spell", "N/A", "Card8", Resources.Load<Sprite>("tree")));

    }

}
