using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIStateManager : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    AIBaseState currentState;
    public AICollectState collectState = new AICollectState();
    public AIOffenseState offenseState = new AIOffenseState();

    // Start is called before the first frame update
    void Start()
    {

        currentState = collectState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this, target);
    }

    public void SwitchState(AIBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);  
    }
}
