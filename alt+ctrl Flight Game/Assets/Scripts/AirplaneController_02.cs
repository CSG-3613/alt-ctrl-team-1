using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO.Ports;

public class AirplaneController_02 : MonoBehaviour
{
    //private SerialPort port = new SerialPort("COM5", 38400);
    //private string buttonString;

    public float speed = 25.0f;
	public float normalSpeed = 25.0f; 
	public float boostSpeed = 15.0f;
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
		//port.Open(); //initiate the Serial Port
		//InvokeRepeating("SerialDataReading", 0f, 0.01f); //controls the data reading of the serial port by forcably invoking the function every 0.01f seconds with 0f delay (avoids periodic lag)
	}

	void Update()
	{
		horizontalInput = Input.GetAxis("Horizontal");
		verticalInput = Input.GetAxis("Vertical");

        rb.velocity = transform.forward * speed;

		//if (horizontalInput != 0){
		//	bank();
		//}
		//if (verticalInput != 0){
		//	pitch();
		//}
		//if (rollInput != 0){
		//	roll();	
		//}
	}

	void bank () {		
		transform.Rotate(Vector3.back * horizontalInput * Time.deltaTime * turnSpeed);

		if (horizontalInput > 0)
		{
			rb.velocity += Vector3.right / turnSpeed;
		}
		else
		{
			rb.velocity -= Vector3.right / turnSpeed;
		}
	}

	void pitch() {


		transform.Rotate(Vector3.right * pitchSpeed * verticalInput * Time.deltaTime);
	}

	void roll()
	{
		rollInput = Input.GetAxis("Roll");

		transform.Rotate(0, 0, -rollSpeed * rollInput * Time.deltaTime);
	}

	void SerialDataReading()
	{
		Debug.Log("entered SerialDataReading()");
		//buttonString = port.ReadLine();
		//if (buttonString == "buttonDown")
		//{
		Debug.Log("entered button if");
		//    speed = normalSpeed + boostSpeed;
		// }
		// else
		// {
		Debug.Log("entered button else"); 
        //    speed = normalSpeed;
        //}
		Debug.Log("speed set based on button press");
    }
}