using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{

    public float speed = 25.0f;
    public float turnSpeed = 1f;
    public float rollSpeed = 1f;
    public float pitchSpeed = 1f;
    public float horizontalInput;
    public float verticalInput;
    public float rollInput;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = transform.forward * speed;
        bank();
        altitude();
        roll();
    }

    void bank () {
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(transform.forward * turnSpeed * horizontalInput * Time.deltaTime, Space.Self);
        // transform.Rotate(0, turnSpeed * horizontalInput * Time.deltaTime, 0);

    }

    void altitude() {
        verticalInput = Input.GetAxis("Vertical");

        transform.Rotate(transform.right, pitchSpeed * verticalInput * Time.deltaTime, Space.Self);
    }

    void roll()
    {
        rollInput = Input.GetAxis("Roll");

        transform.Rotate(0, 0, -rollSpeed * rollInput * Time.deltaTime);
    }
}