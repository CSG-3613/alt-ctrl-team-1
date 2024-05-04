using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
		horizontalInput = Input.GetAxis("Horizontal");
		verticalInput = Input.GetAxis("Vertical");

		rb.velocity = transform.forward * speed;

		if (horizontalInput != 0){
			bank();
		}
		if (verticalInput != 0){
			pitch();
		}
		if (rollInput != 0){
			roll();	
		}
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
}