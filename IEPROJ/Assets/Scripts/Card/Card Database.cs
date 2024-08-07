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
        CardsDatabase.Add(new Card(0, 5,"Spell","N/A","Fireball", Resources.Load<Sprite>("tree")));
        CardsDatabase.Add(new Card(1, 10, "Summon", "N/A", "Skeletons", Resources.Load<Sprite>("tree")));
        CardsDatabase.Add(new Card(2, 20,"Summon", "N/A", "Spell Turret", Resources.Load<Sprite>("tree")));
        CardsDatabase.Add(new Card(3, 5, "Spell", "N/A", "Fireball", Resources.Load<Sprite>("tree")));
        CardsDatabase.Add(new Card(4, 10, "Summon", "N/A", "Skeletons", Resources.Load<Sprite>("tree")));
        CardsDatabase.Add(new Card(5, 20, "Summon", "N/A", "Spell Turret", Resources.Load<Sprite>("tree")));
        CardsDatabase.Add(new Card(6, 5, "Spell", "N/A", "Fireball", Resources.Load<Sprite>("tree")));
        CardsDatabase.Add(new Card(7, 20, "Summon", "N/A", "Spell Turret", Resources.Load<Sprite>("tree")));

    }

}
