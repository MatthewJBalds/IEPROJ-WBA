using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int manaValue = 10; // The amount of mana this collectible adds to the player's mana pool

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.tag == "Enemy")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.AddMana(manaValue);
                EventManager.manaCollected();
                Destroy(gameObject);
            }
            Debug.Log("No Player");
            EnemyMana enemy = other.GetComponent<EnemyMana>();
            if(enemy != null) 
            {
                Debug.Log("Collect");
                enemy.AddMana(manaValue);
                EventManager.manaCollected();
                Destroy(gameObject);
            }
        }
    }
}
