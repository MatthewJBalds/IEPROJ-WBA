using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplaySO : MonoBehaviour
{
    [SerializeField]
    private CardSO card;

    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text typeText;
    [SerializeField]
    private Text descriptionText;
    [SerializeField]
    private Text costText;
    [SerializeField]
    private Sprite cardSprite;
    void Start()
    {
        nameText.text = card.cardName;
        descriptionText.text = card.cardDescription;
        typeText.text = card.cardType;
        costText.text = card.cardCost.ToString();
    }

}
