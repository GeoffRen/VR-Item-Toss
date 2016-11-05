using UnityEngine;
using System.Collections;

// Base class for the ball and rock
public abstract class Objects : MonoBehaviour {

	// Whether the object is being held or not
	protected bool mHolding;

	// Where the object is held
	protected GameObject mHoldPos;

	// The object's rigidbody
	protected Rigidbody mBody;

	// The virtual reality camera
	protected Transform mCam;

	// The horizontal force
	protected Vector3 mForce;

	// Makes the object the held object
	public abstract void hold();

	// Throws the object
	public abstract void fling();

	// Sets an object to have zero movement
	protected void setZero(GameObject obj) {
		obj.transform.rotation = Quaternion.identity;
		obj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
	}

	// Sets an object to ignore physics
	protected void immobile(GameObject obj) {
		obj.GetComponent<Rigidbody> ().useGravity = false;
		obj.GetComponent<Rigidbody> ().isKinematic = true;
	}

	// Sets an object to be affected by physics
	protected void mobile(GameObject obj) {
		obj.GetComponent<Rigidbody> ().useGravity = true;
		obj.GetComponent<Rigidbody> ().isKinematic = false;
	}

	// Creates and displays a random force to the HUD
	protected Vector3 randForce() {

		// Displays the force
		Vector3 force = Vector3.right * Random.Range (-50, 50);
		HUD.set (force);

		return force;
	}
}
