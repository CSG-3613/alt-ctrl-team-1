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

		rb.velocity = transform.forward * speed;

		if (horizontalInput != 0){
			bank();
		}

		altitude();
		roll();
	}

	void bank () {		
		transform.Rotate(new Vector3(0,0,1) * horizontalInput * Time.deltaTime * turnSpeed);

		//if (horizontalInput > 0) {
		//	rb.velocity += Vector3.right * turnSpeed;
		//} else {
		//	rb.velocity -= Vector3.right * turnSpeed;
		//}
	}

	void altitude() {
		verticalInput = Input.GetAxis("Vertical");

		transform.Rotate(transform.right, pitchSpeed * verticalInput * Time.deltaTime);
	}

	void roll()
	{
		rollInput = Input.GetAxis("Roll");

		transform.Rotate(0, 0, -rollSpeed * rollInput * Time.deltaTime);
	}
}