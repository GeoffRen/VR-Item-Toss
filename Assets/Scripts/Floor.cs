using UnityEngine;
using System.Collections;

// Controls floor collision behavior
public class Floor : MonoBehaviour {

	// Controls whether the score should reset
	public static bool reset = false;

	// If the ball hits the ground, reset the score
	void OnCollisionEnter(Collision collision) {
		reset = true;
	}
}
