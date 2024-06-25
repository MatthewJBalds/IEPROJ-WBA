using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class CardSO : ScriptableObject
{
    public string cardName;
    public string cardType;
    public string cardDescription;
    public int cardCost;
    public Sprite cardSprite;


}
