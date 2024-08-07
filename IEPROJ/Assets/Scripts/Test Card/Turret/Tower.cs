using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour
{
    public GameObject orbPrefab;
    public Transform orbSpawnPoint;
    public float attackInterval = 1.0f;
    public float orbSpeed = 10.0f;
    public Collider shooterRange;

    private Collider currentTarget = null;
    private bool isAttacking = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (currentTarget == null)
            {
                currentTarget = other;
                StartAttacking();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == currentTarget)
        {
            StopAttacking();
            currentTarget = null;
        }
    }

    private void StartAttacking()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            StartCoroutine(AttackRoutine());
        }
    }

    private void StopAttacking()
    {
        isAttacking = false;
        StopCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        while (isAttacking && currentTarget != null)
        {
            ShootOrb();
            yield return new WaitForSeconds(attackInterval);

            if (currentTarget == null || !currentTarget.gameObject.activeInHierarchy)
            {
                StopAttacking();
            }
        }
    }

    private void ShootOrb()
    {
        if (currentTarget != null)
        {
            GameObject orb = Instantiate(orbPrefab, orbSpawnPoint.position, Quaternion.identity);
            Vector3 direction = (currentTarget.transform.position - orbSpawnPoint.position).normalized;
            orb.GetComponent<Rigidbody>().velocity = direction * orbSpeed;

            // Add a component to detect exiting the range
            var orbCollider = orb.AddComponent<OrbRangeChecker>();
            orbCollider.shooterRange = shooterRange;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (currentTarget == null && other.CompareTag("Enemy"))
        {
            currentTarget = other;
            StartAttacking();
        }
    }
}
