using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float speed;
    [SerializeField] private float threshold;
    [SerializeField] private Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        Vector3 target_position = target.transform.position + offset;
        Vector3 cam_position = transform.position;

        // Get a vector in direction of target
        Vector3 direction = target_position - cam_position;
        direction.y = 0;

        // Only move if the movement is significant enough
        if (direction.magnitude > threshold)
        {
            direction.Normalize();

            cam_position += direction * speed * Time.deltaTime;
            transform.position = cam_position;
        }
    }
}

// Code sourced from Harlepengren: https://harlepengren.com/learn-how-to-create-a-simple-camera-follow-script-in-unity/