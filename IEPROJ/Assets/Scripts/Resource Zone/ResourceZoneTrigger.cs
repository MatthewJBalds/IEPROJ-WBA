using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceZoneTrigger : MonoBehaviour
{
    private Color m_oldColor = Color.white;
    private bool isPlayerInside = false;
    public GameObject objectToSpawn; // Assign the prefab of the object to spawn in the Inspector
    public Transform spawnPoint; // Assign the spawn point in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        Renderer renderer = GetComponent<Renderer>();
        m_oldColor = renderer.material.color;
        renderer.material.color = Color.cyan; // Change the area zone color to visualize that player is in the zone

        // Check if the object that entered the trigger is the player
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone.");
            isPlayerInside = true;
            StartSpawning();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<Renderer>().material.color = m_oldColor; // Set color back to default

        // Check if the object that exited the trigger is the player
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exited the trigger zone.");
            isPlayerInside = false;
            StopSpawning();
        }
    }

    private void StartSpawning()
    {
        Debug.Log("Started Spawning objects.");
        InvokeRepeating("SpawnObject", 0f, 2f); // Start spawning immediately and repeat every 2 seconds
    }

    private void StopSpawning()
    {
        Debug.Log("Stopped Spawning objects.");
        CancelInvoke("SpawnObject");
    }

    private void SpawnObject()
    {
        if (isPlayerInside && objectToSpawn != null && spawnPoint != null)
        {
            Debug.Log("Spawning an object.");
            Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogWarning("Spawn conditions not met. isPlayerInside: " + isPlayerInside + ", objectToSpawn: " + objectToSpawn + ", spawnPoint: " + spawnPoint);
        }
    }
}
