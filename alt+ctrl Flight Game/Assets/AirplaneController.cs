using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AirplaneController : MonoBehaviour
{
    public float thrustAmount = 100f;
    public float turnSpeed = 50f;
    public float liftAmount = 50f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        ApplyThrust(vertical);
        Turn(horizontal);
        ApplyLift();
    }

    void ApplyThrust(float amount)
    {
        rb.AddForce(transform.forward * thrustAmount * amount);
    }

    void Turn(float direction)
    {
        rb.AddTorque(Vector3.up * direction * turnSpeed);
    }

    void ApplyLift()
    {
        if (rb.velocity.magnitude > 10)
        {
            rb.AddForce(Vector3.up * liftAmount * rb.velocity.magnitude);
        }
    }
}