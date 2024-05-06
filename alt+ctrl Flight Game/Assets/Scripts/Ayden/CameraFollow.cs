/* Script edited by Bridget Kurr May 2024 */
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Transform targetT;
    [SerializeField] private float speed;
    [SerializeField] private float threshold;
    [SerializeField] private Vector3 offset;
    


    // Update is called once per frame
    void Update()
    {
        Debug.Log("Entered Camera Update Method");
        Vector3 target_position = target.transform.position ;
        Debug.Log("target's position: " + target_position);
        Vector3 cam_position = target_position + offset;
        Debug.Log("camera position values: " + cam_position);

        Quaternion target_rotation = target.transform.rotation;
        Debug.Log("target's rotation: " + target_rotation);
        Quaternion cam_rotation = target_rotation;
        cam_rotation.z = 0;
        Debug.Log("camera rotation values: " + cam_rotation);

        transform.position = cam_position;
        transform.rotation = cam_rotation;
        transform.LookAt(targetT);

        // Get a vector in direction of target
        /*Vector3 direction = target_position - cam_position;
        //direction.y = 0;

        // Only move if the movement is significant enough
        if (direction.magnitude > threshold)
        {
            direction.Normalize();

            cam_position += direction * speed * Time.deltaTime;
            transform.position = cam_position;
            transform.rotation = cam_rotation;
        }*/
    }
}

// Code sourced from Harlepengren: https://harlepengren.com/learn-how-to-create-a-simple-camera-follow-script-in-unity/