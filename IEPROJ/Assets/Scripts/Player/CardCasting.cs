using UnityEngine;

public class CardCasting : MonoBehaviour
{
    public GameObject[] cards;
    public Transform castPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CastCard(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CastCard(1);
        }
    }

    void CastCard(int cardIndex)
    {
        Instantiate(cards[cardIndex], castPoint.position, castPoint.rotation);
    }
}

//[TODO]
//Add card prefabs to the cards array in the Unity inspector and set a
//castPoint (a child GameObject of the player where cards will be instantiated).