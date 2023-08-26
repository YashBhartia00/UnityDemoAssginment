using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target; // The player's transform
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Camera offset

    void LateUpdate()
    {
        if (target != null)
        {
            // Update the camera position to follow the player
            transform.position = target.position + offset;
        }
    }

}
