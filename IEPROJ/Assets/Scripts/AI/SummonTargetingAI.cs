using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SummonTargetingAI : MonoBehaviour
{
    public List<GameObject> targets = new List<GameObject>();

    public SummonNavigationAI summonScript;
    public bool isSummon;

    void Start()
    {
        summonScript = GetComponentInParent<SummonNavigationAI>();
        isSummon = summonScript.isSummon;
    }

    void Update()
    {
        if (targets.Count > 0)
        {
            GameObject closestTarget = null;
            float closestDistance = Mathf.Infinity;

            foreach (GameObject target in targets)
            {
                float distance = Vector3.Distance(transform.position, target.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestTarget = target;
                }
            }

            if (closestTarget != null)
            {
                summonScript.targetSummon = closestTarget;
                summonScript.hasTarget = true;
            }
        }
        else
        {
            summonScript.hasTarget = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isSummon && other.gameObject.layer == 10)
        {
            if (!targets.Contains(other.gameObject))
            {
                targets.Add(other.gameObject);
            }
        }
        else if (!isSummon && other.gameObject.layer == 9)
        {
            if (!targets.Contains(other.gameObject))
            {
                targets.Add(other.gameObject);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (targets.Contains(other.gameObject))
        {
            targets.Remove(other.gameObject);
        }
    }
}
