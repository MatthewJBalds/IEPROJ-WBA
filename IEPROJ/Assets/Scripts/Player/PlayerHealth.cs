using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public HealthBar healthBar;
    [SerializeField]
    Transform spawnPoint;
    //[TODO] CREATE HEALTH BAR UI SLIDER; later on for stylized vers.
    //public Slider healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(currentHealth);
        //EventManager.trackMaxHP(currentHealth);
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
        //EventManager.trackHP(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        StartCoroutine(Respawn());
        Debug.Log("Respawn End");
        //Handle player death (e.g., respawn, game over)
        Debug.Log("Player Died");
    }

    IEnumerator Respawn()
    {
        Debug.Log("Respawn Start");

        if(this.tag == "Player")
        {
            this.GetComponentInParent<ThirdPersonUserControl>().enabled = false;
        }
        this.healthBar.gameObject.SetActive(false);
        currentHealth = maxHealth;
        healthBar.setMaxHealth(currentHealth);

        yield return new WaitForSeconds(5);

        this.gameObject.transform.parent.position = spawnPoint.position;
        this.healthBar.gameObject.SetActive(true);

        if (this.tag == "Player")
        {
            this.GetComponentInParent<ThirdPersonUserControl>().enabled = true;
        }
        Debug.Log("Respawn End");
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
    }

}
