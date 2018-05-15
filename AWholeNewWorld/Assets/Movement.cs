using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float speed = 1.0f;

	float z = 0;
	float x = 0;
	
	void Update () {
		z = Input.GetAxis("Vertical") * speed;
		x = Input.GetAxis("Horizontal") * speed;
		GetComponent<Rigidbody>().AddForce(Vector3.forward * z);
		GetComponent<Rigidbody>().AddForce(Vector3.right * x);
	}
}
