using UnityEngine;
using System.Collections;

// Class defining the object selection sub menu buttons
public class Objects_Menu : MonoBehaviour {

	// The object selection sub menu
	private GameObject mObjects_Menu;

	// The main pause menu
	private GameObject mPause_Menu;

	// The ball
	private GameObject mBall;

	// The rock
	private GameObject mRock;

	// Initializes everything
	void Awake() {
		mPause_Menu = GameObject.Find (Constants.PAUSE_MENU);
		mObjects_Menu = GameObject.Find(Constants.OBJECTS_MENU);
		mBall = GameObject.Find (Constants.BALL);
		mRock = GameObject.Find (Constants.ROCK);
	}

	// Button that navigates to the main pause menu
	public void back() {
		mPause_Menu.SetActive (true);
		mObjects_Menu.SetActive (false);
	}

	// Button that selects the ball
	public void ball() {
		mBall.SetActive (true);
		mRock.SetActive (false);

		Pause_Menu.activateGame ();
		mObjects_Menu.SetActive (false);
	}

	// Button that selects the rock
	public void rock() {
		mBall.SetActive (false);
		mRock.SetActive (true);

		Pause_Menu.activateGame ();
		mObjects_Menu.SetActive (false);
	}

	// Button that resumes the game
	public void resume() {
		Pause_Menu.activateGame ();
		mObjects_Menu.SetActive (false);
	}
}
