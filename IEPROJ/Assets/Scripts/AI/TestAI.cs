using UnityEngine;

public abstract class AIBaseState
{
    public abstract void EnterState(AIStateManager aIState);

    public abstract void UpdateState(AIStateManager aIState, Transform target);

    public abstract void OnCollisionState(AIStateManager aIState);  
}
