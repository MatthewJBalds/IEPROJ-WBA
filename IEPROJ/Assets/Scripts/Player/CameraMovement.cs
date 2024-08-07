using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 5.0f; // Speed of camera movement

    void Update()
    {
        // Get the input from the "W" and "S" keys
        float moveDirection = Input.GetAxis("Vertical");

        // Calculate the movement direction in world space
        Vector3 move = Vector3.back * moveDirection;

        // Apply the new position to the camera
        transform.Translate(move * speed * Time.deltaTime, Space.World);
    }
}
