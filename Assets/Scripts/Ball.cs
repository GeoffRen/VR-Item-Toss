using UnityEngine;
using System.Collections;

// Controls the ball
public class Ball : Objects {

	// Initializes everything 
	void Awake() {
		mBody = this.GetComponent<Rigidbody> ();
		mCam = GameObject.Find (Constants.PLAYER).transform;
		mHoldPos = GameObject.Find (Constants.RESPAWN);
	}

	// Makes the ball the default object
	void Start() {
		hold ();	
	}

	// Controls the physics of the ball
	void FixedUpdate() {

		// Holds the ball
		if (mHolding) {
			this.transform.position = mHoldPos.transform.position;
		} 

		// Applies a spin and horizontal push to the ball
		mBody.AddForce (mForce);
		mBody.AddTorque (mForce);
	}

	// Makes the ball the held object
	public override void hold() {

		// If the ball is held then the gravity should be the ball gravity
		Physics.gravity = Constants.BALL_GRAVITY;
		mForce = randForce ();

		// If you're holding the ball, it shouldn't be moving
		immobile (this.gameObject);
		mHolding = true;
	}

	// Throws the ball
	public override void fling() {

		// The distance thrown depends on difficulty
		float modifier = 1f;
		if (Difficulty_Menu.difficulty == Constants.HARD) {
			modifier = 1.5f;

		} else if (Difficulty_Menu.difficulty == Constants.IMPOSSIBLE) {
			modifier = 1.8f;
		}

		mBody.velocity = modifier * mCam.forward * Constants.BALL_SPEED;
		mobile (this.gameObject);
		mHolding = false;
	}

	// Controls collisions
	void OnCollisionEnter (Collision collision) {

		// If the ball hits the terrain: reset the score, teleport the ball 
		// back to the player and randomize the horizontal force
		if (collision.gameObject.tag != Constants.UNREACTIVE) {

			setZero (this.gameObject);
			mHolding = true;
			immobile (this.gameObject);

			mForce = randForce ();
		}
	}
}
