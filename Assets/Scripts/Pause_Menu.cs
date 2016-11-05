using UnityEngine;
using System.Collections;

// Class defining the pause menu buttons, activation, and deactivation
public class Pause_Menu : MonoBehaviour {

	// The angle that will reset the objects
	private float mToggle = 40f;

	// The virtual reality camera
	private Transform mCam;

	// The difficulty sub menu
	private GameObject mDifficulty_Menu;

	// The object selection sub menu
	private GameObject mObjects_Menu;

	// The main pause menu
	private GameObject mPause_Menu;

	// The scores sub menu
	private GameObject mScores_Menu;

	// The HUD
	private static GameObject mHUD;

	// The UI displaying the score
	private static GameObject mScore;

	// Initializes everything
	void Awake () {
		mCam = GameObject.Find (Constants.PLAYER).transform;
		mPause_Menu = GameObject.Find(Constants.PAUSE_MENU);
		mDifficulty_Menu = GameObject.Find (Constants.DIFFICULTY_MENU);
		mObjects_Menu = GameObject.Find (Constants.OBJECTS_MENU);
		mScores_Menu = GameObject.Find (Constants.SCORE_MENU);
		mHUD = GameObject.Find (Constants.HUD);
		mScore = GameObject.Find (Constants.SCORE);
	}

	// Sets all the menus to inactive initially
	void Start () {
		mPause_Menu.SetActive (false);
		mDifficulty_Menu.SetActive (false);
		mObjects_Menu.SetActive (false);
		mScores_Menu.SetActive (false);
	}

	// If the player looks down, pause
	void Update () {
		if (mCam.eulerAngles.x >= mToggle && mCam.eulerAngles.x <= 90f) {
			disableGame ();	
		}
	}

	// Button that resumes the game
	public void resume() {
		activateGame ();
		mPause_Menu.SetActive (false);
	}

	// Button that navigates to the difficulty sub menu
	public void difficultySelect() {
		mDifficulty_Menu.SetActive (true);
		mPause_Menu.SetActive (false);
	}

	// Button that navigates to the object selection sub menu
	public void objectSelect() {
		mObjects_Menu.SetActive (true);
		mPause_Menu.SetActive (false);
	}

	// Button that navigates to the scores sub menu
	public void scoreDisplay() {
		mScores_Menu.SetActive (true);
		mPause_Menu.SetActive (false);
	}

	// Disables the game by pausing and disabling all UI
	private void disableGame() {
		Time.timeScale = 0;

		mPause_Menu.SetActive (true);
		mHUD.SetActive (false);
		mScore.SetActive (false);
	}

	// Activates the game by unpausing and activating all UI
	public static void activateGame() {
		Time.timeScale = 1;

		mHUD.SetActive (true);
		mScore.SetActive (true);
	}
}
