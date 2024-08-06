using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private bool isRespawned = false;

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
        if (!isRespawned)
        {
            StartCoroutine(Respawn());
            isRespawned = false;
        }

        this.gameObject.transform.position = spawnPoint.position;
        this.gameObject.SetActive(true);
        currentHealth = maxHealth;
        healthBar.setMaxHealth(currentHealth) ;

        //Handle player death (e.g., respawn, game over)
        Debug.Log("Player Died");
    }

    IEnumerator Respawn()
    {
        this.gameObject.SetActive(false);
        yield return new WaitForSeconds(5);
        isRespawned = true;
    }

}
