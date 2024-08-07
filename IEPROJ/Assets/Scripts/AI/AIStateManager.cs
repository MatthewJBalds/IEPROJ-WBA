using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIStateManager : MonoBehaviour
{
    public Transform target;
    public Transform playerTarget;
    public GameObject fireballPrefab;
    private bool spawn = false;

    AIBaseState currentState;
    public AIMoveToCenterState moveState = new AIMoveToCenterState();
    public AICollectState collectState = new AICollectState();
    public AIOffenseState offenseState = new AIOffenseState();

    // Start is called before the first frame update
    private void Start()
    {

        currentState = moveState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    private void Update()
    {
        currentState.UpdateState(this, target);
    }

    public void SwitchState(AIBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);  
    }

    public void cast(Vector3 spawnPosition)
    {
        StartCoroutine(SpawnFireBall(spawnPosition));
        spawn = false;
    }

    IEnumerator SpawnFireBall(Vector3 spawnPosition)
    {
        if (!spawn)
        {
            Instantiate(fireballPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(2);
            spawn = true;
        }
    }
}
