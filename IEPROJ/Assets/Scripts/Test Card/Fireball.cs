using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour
{
    public float fallSpeed = 20.0f; 
    public float explosionRadius = 5.0f;
    public float explosionForce = 700.0f;
    public int damage = 50;
    public GameObject explosionEffect;

    private bool hasExploded = false;

    private void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasExploded && collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            hasExploded = true;
            Explode();
        }
    }

    private void Explode()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.identity);

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}
