using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target; // Assign the player GameObject to this in the inspector
    public float offset = 3f; // Distance between the camera and the player
    public float smoothSpeed = 5f; // Smoothing factor for camera movement

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + Vector3.back * offset; // Calculate desired position behind the player
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime); // Smoothly transition to desired position
        }
    }
}
