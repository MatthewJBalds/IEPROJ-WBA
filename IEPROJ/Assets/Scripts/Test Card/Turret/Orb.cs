using UnityEngine;

public class Orb : MonoBehaviour
{
    public int damage = 10;
    public float lifetime = 5.0f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TowerHealth enemyHealth = collision.gameObject.GetComponent<TowerHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ShooterRange"))
        {
            Destroy(gameObject);
        }
    }
}
