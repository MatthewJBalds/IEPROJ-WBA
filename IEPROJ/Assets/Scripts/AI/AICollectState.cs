using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AICollectState : AIBaseState
{
    private float speed = 5f;
    public override void EnterState(AIStateManager aIState)
    {
    }

    public override void UpdateState(AIStateManager aIState, Transform target)
    {
        if (Vector3.Distance(aIState.transform.position, target.position) > 1.0f)
        {
            aIState.transform.position = Vector3.MoveTowards(aIState.transform.position, target.position,speed *Time.deltaTime);
            aIState.transform.forward =  target.position - aIState.transform.position;
        }
        else
            aIState.SwitchState(aIState.offenseState);
    }

    public override void OnCollisionState(AIStateManager aIState)
    {

    }
}
