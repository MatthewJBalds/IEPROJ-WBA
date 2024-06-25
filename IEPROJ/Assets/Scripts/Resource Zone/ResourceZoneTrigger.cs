using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceZoneTrigger : MonoBehaviour
{
    private Color m_oldColor = Color.white;
    private GameObject objectToDestroy;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private bool isPlayerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        Renderer renderer = GetComponent<Renderer>();
        m_oldColor = renderer.material.color;
        renderer.material.color = Color.cyan; //Change the area zone color to visualize that player is in the zone

        // Check if the object that entered the trigger is the player
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInside = true;
            objectToDestroy = other.gameObject;
            initialPosition = objectToDestroy.transform.position;
            initialRotation = objectToDestroy.transform.rotation;
            Invoke("DestroyObject", 3f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<Renderer>().material.color = m_oldColor; //Set color back to default

        // Check if the object that exited the trigger is the player
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInside = false;
            CancelInvoke("DestroyObject");
            RespawnObject();
        }
    }

    private void DestroyObject()
    {
        if (isPlayerInside && objectToDestroy != null)
        {
            Destroy(objectToDestroy);
        }
    }

    private void RespawnObject()
    {
        if (objectToDestroy == null)
        {
            objectToDestroy = new GameObject("RespawnedObject");
            objectToDestroy.transform.position = initialPosition;
            objectToDestroy.transform.rotation = initialRotation;
        
        }
    }
}
