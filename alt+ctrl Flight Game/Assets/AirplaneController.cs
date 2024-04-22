using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{

    public float speed = 25.0f;
    public float turnSpeed = 1f;
    public float horizontalInput;
    public float verticalInput;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        bank();
    }

    void bank () {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.rotation.z > -45 || transform.rotation.z < 45) {
            transform.Rotate(0, 0, -turnSpeed * horizontalInput * Time.deltaTime);
            transform.Rotate(0, turnSpeed * horizontalInput * Time.deltaTime, 0);
        }
    }

    void zero() { 
        
    }
}