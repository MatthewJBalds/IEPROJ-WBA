using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMoveToCenterState : AIBaseState
{
    private float speed = 5f;
    public override void EnterState(AIStateManager aIState)
    {


    }

    public override void UpdateState(AIStateManager aIState, Transform target)
    {
        aIState.transform.position = Vector3.MoveTowards(aIState.transform.position, target.position, speed * Time.deltaTime);
        aIState.transform.forward = target.position - aIState.transform.position;

        if(aIState.transform.position == target.position)
        {
            aIState.SwitchState(aIState.collectState);
        }
    }

    public override void OnCollisionState(AIStateManager aIState)
    {

    }
}
