using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BasicController : MonoBehaviour
{
    public float speed = 25.0f;
    public float normalSpeed = 25.0f;
    public float boostSpeed = 15.0f;

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
        rb = GetComponent<Rigidbody>();
        port.Open();
        Debug.Log("Port is Open");
    }

    // Update is called once per frame
    void Update()
    {
        speed = SerialDataReading();

        rb.velocity = -transform.up * speed;
    }

    public float SerialDataReading()
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
