using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player; // Reference to the player's transform
    public Vector3 offset; // The offset distance between the player and camera

    void LateUpdate()
    {
        // Set the position of the camera to the player's position with the specified offset
        transform.position = player.position + offset;
    }

}
