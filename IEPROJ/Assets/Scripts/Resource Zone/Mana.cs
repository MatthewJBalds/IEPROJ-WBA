using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int manaValue = 10; // The amount of mana this collectible adds to the player's mana pool

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.AddMana(manaValue);
                Destroy(gameObject);
            }
        }
    }
}
