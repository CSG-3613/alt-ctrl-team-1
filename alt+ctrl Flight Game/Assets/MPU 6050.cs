using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class MPU6050 : MonoBehaviour
{
	
	SerialPort stream = new SerialPort("COM4", 115200);

	public string strRecieved;
	public string[] strData = new string[4];
	public string[] strData_recieved = new string[4];
	public float qw, qx, qy, qz;
	public float rollSpeed = 5f;
	public float pitchSpeed = 5f;
	public float yawSpeed = 5f;

	// Start is called before the first frame update
	void Start()
	{
		stream.Open();
	}

	// Update is called once per frame
	void Update()
	{
		strRecieved = stream.ReadLine(); // Read the information.

		strData = strRecieved.Split(new char[] { ',' });
		if (strData[0] != "" && strData[1] != "" && strData[2] != "" && strData[3] != "") {
			strData_recieved[0] = strData[0];
			strData_recieved[1] = strData[1];
			strData_recieved[2] = strData[2];
			strData_recieved[3] = strData[3];

			qw = float.Parse(strData_recieved[0]);
			qx = float.Parse(strData_recieved[1]);
			qy = float.Parse(strData_recieved[2]);
			qz = float.Parse(strData_recieved[3]);

			// transform.rotation = new Quaternion(-qx, qz, -qy, qw);
			transform.Rotate(-qx * rollSpeed, -qz * pitchSpeed, -qy * yawSpeed);
		}
	}
}
