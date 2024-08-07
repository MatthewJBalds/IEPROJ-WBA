using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIOffenseState : AIBaseState
{
    private Vector3 spawnPosition;
    float speed = 5f;
    private PlayerHealth health;
    public override void EnterState(AIStateManager aIState)
    {
        health = aIState.GetComponent<PlayerHealth>();
        Debug.Log("Offense State");
        EventManager.ReduceEnemyMana(5);
        spawnPosition = new Vector3(aIState.playerTarget.position.x, aIState.playerTarget.position.y + 10f, aIState.playerTarget.position.z);
        
    }

    public override void UpdateState(AIStateManager aIState, Transform target)
    {
        aIState.cast(spawnPosition);
        //aIState.cast(spawnPosition);
        aIState.SwitchState(aIState.collectState);

        if(health.CurrentHealth == 0)
        {
            aIState.SwitchState(aIState.deadState);
        }
        //saIState.transform.position = Vector3.MoveTowards(aIState.transform.position, aIState.playerTarget.position, speed * Time.deltaTime);
    }

    public override void OnCollisionState(AIStateManager aIState)
    {

    }
}
