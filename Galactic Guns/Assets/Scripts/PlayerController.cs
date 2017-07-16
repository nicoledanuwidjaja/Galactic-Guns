using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// make the class Boundary serialized (visible) in editor
[System.Serializable]
public class Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour 
{

	// multiplier of input
	public float speed;
	public float tilt;

	// call Boundary class to be accessible
	public Boundary boundary;

	// shot position and spawning
	public GameObject shot;
	public Transform shotSpawn;

	// variables for setting up projectile rate
	public float fireRate = 0.5F;

	private float nextFire = 0.5F;

	// declare private variable for rigidbody
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
	}

	// executed before every frame
	void Update()
	{
		// instantiates a projectile every 0.5 seconds if Jump (Spacebar) is pressed
		if (Input.GetButton("Jump") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	// executed once per physics step
	void FixedUpdate()
	{
		// variables for moving left and right
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// control player with user input left and right
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;

		// if player moves outside of the game, constrain it within the game
		rb.position = new Vector3 (
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}
