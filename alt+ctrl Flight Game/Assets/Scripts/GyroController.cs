using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroController : MonoBehaviour
{
    // Vector3 _rot;
    // Start is called before the first frame update
    void Start()
    {
        //_rot = Vector3.zero;
        Input.gyro.enabled = true; //enable gyroscope on android phones
    }

    // Update is called once per frame
    void Update()
    {
        //_rot.y = -Input.gyro.rotationRateUnbiased.y;
        Debug.Log(Input.gyro.attitude);
        //transform.Rotate(_rot);
        transform.rotation = Input.gyro.attitude;
    }
}
