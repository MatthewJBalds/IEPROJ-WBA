using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab; // Player prefab to instantiate
    public Transform spawnPointP1; // Spawn point for P1
    public Transform spawnPointP2; // Spawn point for P2

    private void Start()
    {
        Vector3 spawnPosition;
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            // This is the first player (P1)
            spawnPosition = spawnPointP1.position;
            PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);
            // Set the player's name to P1
            PhotonNetwork.NickName = "P1";
        }
        else if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            // This is the second player (P2)
            spawnPosition = spawnPointP2.position;
            PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);
            // Set the player's name to P2
            PhotonNetwork.NickName = "P2";
        }
    }
}
