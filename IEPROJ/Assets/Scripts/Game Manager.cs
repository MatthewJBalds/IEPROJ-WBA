using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        if (Instance != null && Instance == this)
        {
            Instance = this;
        }
        else
            Destroy(this);
    }
    
    public void UpdateGameState(GameState newState)
    {
        switch(newState)
        {
            case GameState.PLAYER_TURN:
                break;
            case GameState.ENEMY_TURN: 
                break;
            case GameState.LOSE: 
                break;
            case GameState.VICTORY: 
                break;
            case GameState.PAUSE: 
                break;
            default:
                //Debugging purposes
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
