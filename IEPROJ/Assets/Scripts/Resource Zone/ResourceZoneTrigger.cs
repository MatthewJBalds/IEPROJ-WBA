using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceZoneTrigger : MonoBehaviour
{
    public static ResourceZoneTrigger instance;
    private bool isPlayerInside = false;
    private int numSpawned = 0; // Number of mana objects spawned in the current batch
    private bool isFirstSpawn = true; // Flag to check if it's the first spawn
    public GameObject objectToSpawn; // Assign the prefab of the object to spawn in the Inspector
    public int spawnPoolSize = 10; // Number of objects to spawn in each pool
    public List<GameObject> spawnPool = new List<GameObject>();


    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
        EventManager.ManaCollected += ManaObjectCollected;
        // Spawn the initial pool of objects
        SpawnObjectPool();
    }
    private void OnDisable()
    {
        EventManager.ManaCollected -= ManaObjectCollected;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        // Check if the object that entered the trigger is the player
        if (other.gameObject.CompareTag("Player") || other.tag == "Enemy")
        {
            Debug.Log("Player entered the trigger zone.");
            isPlayerInside = true;

            // Check if it's the first spawn or all previous mana objects are collected
            if (isFirstSpawn || numSpawned >= spawnPoolSize)
            {
                StartSpawning();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object that exited the trigger is the player
        if (other.gameObject.CompareTag("Player") || other.tag == "Enemy")
        {
            Debug.Log("Player exited the trigger zone.");
            isPlayerInside = false;
            StopSpawning();
        }
    }

    private void StartSpawning()
    {
        Debug.Log("Started Spawning objects.");
        isFirstSpawn = false; // Reset the first spawn flag
        SpawnObjectPool();
    }

    private void StopSpawning()
    {
        Debug.Log("Stopped Spawning objects.");
        CancelInvoke("SpawnObjectPool");
    }

    private void SpawnObjectPool()
    {
        if (isPlayerInside && objectToSpawn != null)
        {
            Debug.Log("Spawning a pool of objects.");
            for (int i = 0; i < spawnPoolSize; i++)
            {
                Vector3 randomPosition = GetRandomPositionInZone();
                GameObject spawn = Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
                spawnPool.Add(spawn);
            }
            numSpawned = 0; // Reset spawned count for the new batch
        }
        else
        {
            Debug.LogWarning("Spawn conditions not met. isPlayerInside: " + isPlayerInside + ", objectToSpawn: " + objectToSpawn);
        }
    }

    public void ManaObjectCollected()
    {
        numSpawned++;
        spawnPool = spawnPool.Where(spawn => spawn != null).ToList();
        Debug.Log("Mana object collected. Count: " + numSpawned);

        // Check if all mana objects in the current batch have been collected
        if (numSpawned >= spawnPoolSize)
        {
            if (isPlayerInside)
            {
                SpawnObjectPool(); // Trigger spawning of the next batch
            }
        }
    }

    private Vector3 GetRandomPositionInZone()
    {
        Collider zoneCollider = GetComponent<Collider>();
        Vector3 zoneCenter = zoneCollider.bounds.center;
        Vector3 zoneSize = zoneCollider.bounds.size;

        float randomX = Random.Range(zoneCenter.x - zoneSize.x / 2, zoneCenter.x + zoneSize.x / 2);
        float randomZ = Random.Range(zoneCenter.z - zoneSize.z / 2, zoneCenter.z + zoneSize.z / 2);

        Vector3 randomPosition = new Vector3(randomX, zoneCenter.y, randomZ);

        return randomPosition;
    }
}
