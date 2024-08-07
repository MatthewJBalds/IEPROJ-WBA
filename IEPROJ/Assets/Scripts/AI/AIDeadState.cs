using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIDeadState : AIBaseState
{
    private Vector3 previousPos;
    public override void EnterState(AIStateManager aIState)
    {
        previousPos = aIState.transform.position;
    }

    public override void UpdateState(AIStateManager aIState, Transform target)
    {
       if (previousPos != aIState.transform.position) {
            aIState.SwitchState(aIState.moveState);
         
       }
    }

    public override void OnCollisionState(AIStateManager aIState)
    {

    }
}
