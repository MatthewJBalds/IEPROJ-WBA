using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class AICollectState : AIBaseState
{
    private float speed = 5f;
    private List<GameObject> collectables;
    private int number;
    private int index = 0;
    private EnemyMana mana;
    public override void EnterState(AIStateManager aIState)
    {
        mana = aIState.GetComponentInChildren<EnemyMana>();
        collectables = ResourceZoneTrigger.instance.spawnPool;
        Debug.Log("Collect: " + collectables.Count);

    }

    public override void UpdateState(AIStateManager aIState, Transform target)
    {
        for (int i = 0; i < collectables.Count && index == 0; i++)
        {
            if (collectables[i] != null)
            {
                number = i;
                index = -1;
            }
          
        }

        if (index == -1)
        {
            if (mana.manaPool >= 30)
            {
                aIState.SwitchState(aIState.offenseState);
            }
            if (collectables[number] == null)
            {
                collectables = ResourceZoneTrigger.instance.spawnPool;
                index = 0;
            }
            aIState.transform.position = Vector3.MoveTowards(aIState.transform.position, collectables[number].transform.position, speed * Time.deltaTime);
            aIState.transform.forward = collectables[number].transform.position - aIState.transform.position;
            
        }
        //if (Vector3.Distance(aIState.transform.position, target.position) > 1.0f)
        //{
        //    aIState.transform.position = Vector3.MoveTowards(aIState.transform.position, target.position,speed *Time.deltaTime);
        //    aIState.transform.forward =  target.position - aIState.transform.position;
        //}
        //else
        //    aIState.SwitchState(aIState.offenseState);
    }

    public override void OnCollisionState(AIStateManager aIState)
    {

    }
}
