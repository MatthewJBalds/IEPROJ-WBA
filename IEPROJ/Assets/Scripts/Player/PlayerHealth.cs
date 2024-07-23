using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public HealthBar healthBar;
    //[TODO] CREATE HEALTH BAR UI SLIDER; later on for stylized vers.
    //public Slider healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(currentHealth);
        //healthBar.maxValue = maxHealth;
        //healthBar.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //healthBar.value = currentHealth;
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
        healthBar.setHealth(currentHealth); 

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Handle player death (e.g., respawn, game over)
        Debug.Log("Player Died");
    }
}
