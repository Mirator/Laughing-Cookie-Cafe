using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset; // Distance between the camera and the player

    void Update()
    {
        // Check if the player transform has been set
        if (playerTransform != null)
        {
            // Update the camera's position to follow the player, keeping the offset
            transform.position = new Vector3(playerTransform.position.x + offset.x, 
                                             playerTransform.position.y + offset.y, 
                                             offset.z); // Z offset is typically fixed
        }
    }
}
