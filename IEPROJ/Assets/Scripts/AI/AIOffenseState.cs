using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIOffenseState : AIBaseState
{
    public override void EnterState(AIStateManager aIState)
    {
        Debug.Log("Offense State");
    }

    public override void UpdateState(AIStateManager aIState, Transform target)
    {
        if(Vector3.Distance(target.position, aIState.transform.position) > 1.0f)
        {
            aIState.SwitchState(aIState.collectState);
        }
    }

    public override void OnCollisionState(AIStateManager aIState)
    {

    }
}
