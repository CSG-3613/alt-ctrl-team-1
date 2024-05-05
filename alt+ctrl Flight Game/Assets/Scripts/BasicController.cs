using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using WiimoteApi;

public class BasicController : MonoBehaviour
{
    Wiimote gyro;

    public float speed = 1.0f; //used to keep the state of the speed (normalSpeed or normalSpeed + boostSpeed)
    public float normalSpeed = 1.0f; //the base speed the plane moves
    public float boostSpeed = 3.0f; //the added speed the plane moves when on buttonDown

    float yawInput; //rotation AROUND y world axis
    float pitchInput; //rotation AROUND x world axis
    float rollInput; //rotation AROUND z local axis

    public float yawMultiplier; //to multiply the player input value (rotation AROUND y world axis)
    public float pitchMultiplier; //to multiply the player input value (rotation AROUND x world axis)
    public float rollMultiplier; //to multiply player input value (rotation AROUND z local axis)

    public Rigidbody rb;

    private SerialPort port = new SerialPort("COM5", 9600);
    private string buttonString;

    // Start is called before the first frame update
    void Start()
    {
        WiimoteManager.FindWiimotes();
        gyro = WiimoteManager.Wiimotes[0];
        gyro.SendDataReportMode(InputDataType.REPORT_BUTTONS_ACCEL_EXT16);
        gyro.Accel.CalibrateAccel(AccelCalibrationStep.LEFT_SIDE_UP);
        gyro.SendPlayerLED(false, false, false, true);

        /*
        foreach (string str in SerialPort.GetPortNames()) //testing for ports on arduino uno
        {
            Debug.Log(string.Format("Existing COM port: {0}", str));
        }*/
        rb = GetComponent<Rigidbody>(); //getting the rigid body for the plane
        port.Open(); //opening port on arduino for button
        Debug.Log("Port is Open");
        StartCoroutine(activateWiimote());
    }

    // Update is called once per frame
    void Update()
    {
        if ( gyro.Button.home)
        {
            gyro.Accel.CalibrateAccel(AccelCalibrationStep.LEFT_SIDE_UP);
        }
        yawInput = Input.GetAxis("Vertical");
        pitchInput = Input.GetAxis("Horizontal");

        speed = SerialDataReading(); ///calls to readLine() input from arduino
        rb.velocity = transform.forward * speed; //uses updated speed from SerialDatatReading() for rigid body velocity

        if (gyro != null)
        {
            Debug.Log("gyro is not null!");
            float[] acell = gyro.Accel.GetCalibratedAccelData();
            yawInput = acell[1];
            //Debug.Log(yawInput.ToString());
            bank();
            pitchInput = acell[0];
            //Debug.Log(pitchInput.ToString());
            //pitch();
            //rollInput = acell[0];
            //roll();
        }
        
    }

    // FixedUpdate has 50 calls per second
    IEnumerator activateWiimote()
    {
        yield return new WaitUntil(() => WiimoteManager.HasWiimote());
    }

    void bank() //incorporated from Ayden's script
    {
        transform.Rotate(Vector3.back * yawInput * Time.deltaTime * yawMultiplier);

        if (yawInput > 0)
        {
            rb.velocity += Vector3.right / yawMultiplier;
        }
        else
        {
            rb.velocity -= Vector3.right / yawMultiplier;
        }
    }

    void pitch() //incorporated from Ayden's script
    {


        transform.Rotate(Vector3.right * pitchMultiplier * pitchInput * Time.deltaTime);
    }

    void roll() //incorporated from Ayden's script
    {
        rollInput = Input.GetAxis("Roll");

        transform.Rotate(0, 0, -rollMultiplier * rollInput * Time.deltaTime);
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
