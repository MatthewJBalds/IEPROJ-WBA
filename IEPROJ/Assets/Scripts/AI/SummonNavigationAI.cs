using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SummonNavigationAI : MonoBehaviour
{
    public Vector3 destination;
    public Vector3 finalDestination;

    NavMeshAgent agent;
    public bool isSummon;
    public bool isEnemySummon;
    public bool isStructure;

    public GameObject targetSummon;
    public bool hasTarget = false;

    public float health = 100;
    public float attackCooldown = 2;
    private float attackTimer;

    void Start()
    {
        if (isSummon)
        {
            gameObject.layer = 9;
        }
        else if (isEnemySummon)
        {
            gameObject.layer = 10;
        }

        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destination);

        attackTimer = attackCooldown;
    }

    void Update()
    {
        if (hasTarget && targetSummon != null)
        {
            agent.SetDestination(targetSummon.transform.position);
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0)
            {
                attackTimer = attackCooldown;
                AttackTarget();
            }
        }
        else
        {
            agent.SetDestination(finalDestination);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void AttackTarget()
    {
        if (targetSummon != null)
        {
            SummonNavigationAI targetAI = targetSummon.GetComponent<SummonNavigationAI>();
            if (targetAI != null)
            {
                targetAI.health -= 10;
            }

            if (targetAI.health <= 0)
            {
                targetSummon = null;
                hasTarget = false;
                agent.SetDestination(finalDestination);
            }
        }
    }
}
