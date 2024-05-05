using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BasicController : MonoBehaviour
{
    public float speed = 1.0f; //used to keep the state of the speed (normalSpeed or normalSpeed + boostSpeed)
    public float normalSpeed = 1.0f; //the base speed the plane moves
    public float boostSpeed = 3.0f; //the added speed the plane moves when on buttonDown

    public float yawMultiplier; //to multiply the player input value (rotation AROUND y world axis)
    public float pitchMultiplier; //to multiply the player input value (rotation AROUND x world axis)
    public float rollMultiplier; //to multiply player input value (rotation AROUND z local axis)

    public Rigidbody rb;

    private SerialPort port = new SerialPort("COM5", 9600);
    private string buttonString;

    // Start is called before the first frame update
    void Start()
    {
        foreach (string str in SerialPort.GetPortNames()) //testing for ports on arduino uno
        {
            Debug.Log(string.Format("Existing COM port: {0}", str));
        }
        rb = GetComponent<Rigidbody>(); //getting the rigid body for the plane
        port.Open(); //opening port on arduino for button
        Debug.Log("Port is Open");
    }

    // Update is called once per frame
    void Update()
    {
        float yaw = Input.GetAxis("Vertical");
        float pitch = Input.GetAxis("Horizontal");

        speed = SerialDataReading(); ///calls to readLine() input from arduino
        rb.velocity = transform.forward * speed; //uses updated speed from SerialDatatReading() for rigid body velocity
        rb.AddRelativeTorque(pitch * pitchMultiplier * Time.deltaTime, yaw * yawMultiplier * Time.deltaTime, -yaw * yawMultiplier * Time.deltaTime);
    }

    // FixedUpdate has 50 calls per second
    void FixedUpdate() //called every 0.02 seconds keeping physics movement separate from frame rate
    {
        
    }



    public float SerialDataReading() // reads the input from the button and returns a float for the speed setting based on buttonDown or buttonUp
    {
        Debug.Log("entered SerialDataReading()");
        buttonString = port.ReadLine();
        if (buttonString == "buttonDown")
        {
        Debug.Log("entered button if");
            return speed = normalSpeed + boostSpeed;
        }
        else
        {
        Debug.Log("entered button else");
            return speed = normalSpeed;
        }
    }
}
