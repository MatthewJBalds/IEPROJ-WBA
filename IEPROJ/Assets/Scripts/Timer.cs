using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text timeText;
    private float timeValue = 180f;
    private bool timerStarted = false;

    private void Start()
    {
    }

    void Update()
    {
        // Check if there are exactly 2 players in the room and the timer hasn't started yet
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2 && !timerStarted)
        {
            timerStarted = true; // Start the timer
        }

        if (timerStarted)
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                timeValue = 0;
            }

            DisplayTime(timeValue);
            EndGame(timeValue);
        }
    }

    private void EndGame(float timeValue)
    {
        if (timeValue == 0)
        {
            if (TowerManager.Instance.totalEnemyTowerHealth > TowerManager.Instance.totalTowerHealth)
            {
                GameManager.Instance.UpdateGameState(GameState.LOSE);
            }
            else if (TowerManager.Instance.totalEnemyTowerHealth < TowerManager.Instance.totalTowerHealth)
            {
                GameManager.Instance.UpdateGameState(GameState.VICTORY);
            }
            else if (TowerManager.Instance.totalEnemyTowerHealth == TowerManager.Instance.totalTowerHealth)
            {
                GameManager.Instance.UpdateGameState(GameState.TIE);
            }

            //PUT END SCREEN
        }
    }

    private void DisplayTime(float timeValueToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeValueToDisplay / 60f);
        float seconds = Mathf.FloorToInt(timeValueToDisplay % 60f);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
