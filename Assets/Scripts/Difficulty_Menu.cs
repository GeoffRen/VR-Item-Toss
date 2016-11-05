using UnityEngine;
using System.Collections;

// Class defining the difficulty sub menu buttons and location of the bucket
// according to each difficulty
public class Difficulty_Menu : MonoBehaviour {

	// The difficulty sub menu
	private GameObject mDifficulty_Menu;

	// The main pause menu
	private GameObject mPause_Menu;

	// The bucket
	private Transform mBucket;

	// The current difficulty
	public static string difficulty;

	// Initializes everything
	void Awake () {
		difficulty = Constants.NORMAL;
		mBucket = GameObject.Find (Constants.BUCKET).GetComponent<Transform>();
		mDifficulty_Menu = GameObject.Find (Constants.DIFFICULTY_MENU);
		mPause_Menu = GameObject.Find(Constants.PAUSE_MENU);
	}

	// Button that navigates to the main pause menu
	public void back() {
		mPause_Menu.SetActive (true);
		mDifficulty_Menu.SetActive (false);
	}

	// Button that sets the game difficulty to normal
	public void normal() {

		// Only do if not already normal so you don't reset the score if 
		// you are already on normal
		if (difficulty != Constants.NORMAL) {
			difficulty = Constants.NORMAL;

			// Resets the score and sets the bucket
			Floor.reset = true;;
			setBucket (Constants.NORMAL);
		}

		Pause_Menu.activateGame ();
		mDifficulty_Menu.SetActive (false);
	}

	// Button that sets the game difficulty to hard
	public void hard() {

		// Only do if not already normal so you don't reset the score if 
		// you are already on normal
		if (difficulty != Constants.HARD) {
			difficulty = Constants.HARD;

			// Resets the score and sets the bucket
			Floor.reset = true;;
			setBucket (Constants.HARD);
		}

		Pause_Menu.activateGame ();
		mDifficulty_Menu.SetActive (false);
	}

	// Button that sets the game difficulty to impossible
	public void impossible() {

		// Only do if not already normal so you don't reset the score if 
		// you are already on normal
		if (difficulty != Constants.IMPOSSIBLE) {
			difficulty = Constants.IMPOSSIBLE;

			// Resets the score and sets the bucket
			Floor.reset = true;;
			setBucket (Constants.IMPOSSIBLE);
		}
			
		Pause_Menu.activateGame ();
		mDifficulty_Menu.SetActive (false);
	}

	// Sets the bucket to a certain distance depending on difficulty
	void setBucket(string difficulty) {
		if (difficulty == Constants.NORMAL) {
			mBucket.position = Constants.NORMAL_POSITION;
		}

		if (difficulty == Constants.HARD) {
			mBucket.position = Constants.HARD_POSITION;
		}

		if (difficulty == Constants.IMPOSSIBLE) {
			mBucket.position = Constants.IMPOSSIBLE_POSITION;
		}
	}

	// Button that resumes the game
	public void resume() {
		Pause_Menu.activateGame ();
		mDifficulty_Menu.SetActive (false);
	}
}
