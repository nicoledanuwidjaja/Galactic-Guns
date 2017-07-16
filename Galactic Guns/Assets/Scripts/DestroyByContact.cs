using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		// Destroys if the other object isn't Boundary (encapsulating plane)
		if (other.tag == "Boundary")
		{
			return;
		}
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}