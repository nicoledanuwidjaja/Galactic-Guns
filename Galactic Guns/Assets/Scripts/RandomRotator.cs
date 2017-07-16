using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	// maximum tumble value
	public float tumble;

	//instantiate rigidbody
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		// how fast a rigidbody object is rotating
		rb.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
