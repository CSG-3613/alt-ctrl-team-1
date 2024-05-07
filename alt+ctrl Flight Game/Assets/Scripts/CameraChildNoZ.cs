using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChildNoZ : MonoBehaviour
{
    [SerializeField] private GameObject target;
    
    // Update is called once per frame
    void Update()
    {
        Quaternion target_rotation = target.transform.rotation;
        Quaternion cam_rotation = target_rotation;
        cam_rotation.z = 0;
        transform.rotation = cam_rotation;
    }
}
