using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private GameObject winUI, loseUI, tieUI;

    private GameState _state;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(this.gameObject);

    }
    private void Start()
    {
        this._state = GameState.PLAY;
    }

    public void UpdateGameState(GameState newState)
    {
        this._state = newState;
        switch(newState)
        {
            case GameState.PLAY:
                //HandlePlay();
                break;
            case GameState.LOSE:
                HandleLose();
                Debug.Log("Lose");
                break;
            case GameState.VICTORY:
                HandleWin();
                Debug.Log("Win");
                break;
            case GameState.TIE:
                HandleTie();
                Debug.Log("DRAW");
                break;
            case GameState.PAUSE: 
                break;
               
            default:
                //Debugging purposes
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }


        EventManager.updateState(newState);

    }

    // Update is called once per frame
    void Update()
    {
        this.UpdateGameState(_state);
        //Debug.Log(EnemyTowerHealthList.Count);
    }

    private void HandleLose()
    {
        loseUI.SetActive(true);
    }

    private void HandleWin()
    {
        winUI.SetActive(true);
    }
    private void HandleTie()
    {
        tieUI.SetActive(true);
    }
}
