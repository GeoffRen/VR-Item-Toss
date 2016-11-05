using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

// Controls the HUD for wind direction and magnitude
public class HUD : MonoBehaviour {

	// The direction the wind points in
	private Transform mDirection;

	// The mesh of the pointer part of the HUD
	private static MeshRenderer mMesh;

	// The pointer part of the HUD
	private Transform mPointer;

	// The display for the magnitude that the object will be pushed by
	private static Text mText;

	// The current force
	private static Vector3 mForce;

	// Initializes everything
	void Awake() {
		mMesh = GameObject.Find (Constants.POINTER).GetComponent<MeshRenderer> ();
		mText = GameObject.Find (Constants.WIND).GetComponent<Text> ();
		mDirection = GameObject.Find (Constants.DIRECTION).GetComponent<Transform> ();
		mPointer = GameObject.Find (Constants.POINTER).GetComponent<Transform> ();
	}

	// Updates where the pointer part of the HUD points
	void Update () {
		
		// mDirection is a gameobject that will be placed either very far to the
		// left or right depending on the magnitude of the wind force
		Vector3 tmp = mDirection.position;

		// This will either make mDirection's x component 10000f or -10000f, or 
		// 0 if the wind force is 0
		tmp.x = mForce.x / Math.Max(1f, Math.Abs(mForce.x)) * 10000f;

		// mDirection is placed depending on the wind force magnitude and the 
		// HUD pointer is forced to point to it at all times
		mDirection.position = tmp;
		mPointer.LookAt (mDirection);	
	}

	// Sets the HUD to the current force
	public static void set(Vector3 force) {
		mForce = force;
		mMesh.enabled = true;
		mText.text = (Vector3.Magnitude(mForce)).ToString();
	}
}
