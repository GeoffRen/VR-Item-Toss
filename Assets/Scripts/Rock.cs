using UnityEngine;
using System.Collections;

// Controls the rock
public class Rock : Objects {

	// Initializes everything
	void Awake() {
		mBody = this.GetComponent<Rigidbody> ();
		mCam = GameObject.Find (Constants.PLAYER).transform;
		mHoldPos = GameObject.Find (Constants.RESPAWN);
	}

	// The rock is not held at first
	void Start() {
		this.gameObject.SetActive (false);
	}

	// Controls the physics of the rock
	void FixedUpdate() {
		
		// Holds the rock
		if (mHolding) {
			this.transform.position = mHoldPos.transform.position;
		} 

		// Applies a spin and horizontal push to the rock
		mBody.AddForce (mForce);
		mBody.AddTorque (mForce);
	}

	// Makes the rock the held object
	public override void hold() {

		// If the rock is held then the gravity should be the rock gravity
		Physics.gravity = Constants.ROCK_GRAVITY;
		mForce = randForce ();

		// If you're holding the rock, it shouldn't be moving
		immobile (this.gameObject);
		mHolding = true;
	}

	// Throws the rock
	public override void fling() {

		// The distance thrown depends on difficulty
		float modifier = 1f;
		if (Difficulty_Menu.difficulty == Constants.HARD) {
			modifier = 1.3f;

		} else if (Difficulty_Menu.difficulty == Constants.IMPOSSIBLE) {
			modifier = 1.7f;
		}

		mBody.velocity = modifier * mCam.forward * Constants.ROCK_SPEED;
		mobile (this.gameObject);
		mHolding = false;
	}

	// Controls collisions
	void OnCollisionEnter (Collision collision) {

		// If the rock hits the ground, reset the score, teleport the rock 
		// back to the player and randomize the horizontal force
		if (collision.gameObject.tag != Constants.UNREACTIVE) {

			setZero (this.gameObject);

			mHolding = true;
			immobile (this.gameObject);

			mForce = 2f * randForce ();
		}
	}
}
