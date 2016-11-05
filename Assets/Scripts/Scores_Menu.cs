using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

// Class defining the scores sub menu buttons
public class Scores_Menu : MonoBehaviour {

	// The main pause menu
	private GameObject mPause_Menu;

	// The scores sub menu
	private GameObject mScores_Menu;

	// The normal scores sub menu
	private Text mNormal_Scores;

	// The hard scores sub menu
	private Text mHard_Scores;

	// The impossible scores sub menu
	private Text mImpossible_Scores;

	// Initializes everything
	void Awake () {
		mPause_Menu = GameObject.Find(Constants.PAUSE_MENU);
		mScores_Menu = GameObject.Find (Constants.SCORE_MENU);
		mNormal_Scores = GameObject.Find 
			(Constants.NORMAL_SCORES).GetComponent<Text> ();
		mHard_Scores = GameObject.Find 
			(Constants.HARD_SCORES).GetComponent<Text> ();
		mImpossible_Scores = GameObject.Find 
			(Constants.IMPOSSIBLE_SCORES).GetComponent<Text> ();
	}

	// Displays all the scores, called when the scores menu is brought up
	public void showScores() {
		mNormal_Scores.text = "1st\t" + Score.normalHighScore [0] +
			"\n2nd\t" + Score.normalHighScore [1] +
			"\n3rd\t" + Score.normalHighScore [2];

		mHard_Scores.text = "1st\t" + Score.hardHighScore [0] +
			"\n2nd\t" + Score.hardHighScore [1] +
			"\n3rd\t" + Score.hardHighScore [2];

		mImpossible_Scores.text = "1st\t" + Score.impossibleHighScore [0] +
			"\n2nd\t" + Score.impossibleHighScore [1] +
			"\n3rd\t" + Score.impossibleHighScore [2];
	}

	// Button that navigates to the main pause menu
	public void back () {
		mPause_Menu.SetActive (true);
		mScores_Menu.SetActive (false);
	}

	// Button that resumes the game
	public void resume () {
		Pause_Menu.activateGame ();
		mScores_Menu.SetActive (false);
	}

	// Button that resets the current and saved scores
	public void reset () {
		Floor.reset = true;;
		Array.Clear (Score.normalHighScore, 0, Score.normalHighScore.Length);
		Array.Clear (Score.hardHighScore, 0, Score.hardHighScore.Length);
		Array.Clear (Score.impossibleHighScore, 0, Score.impossibleHighScore.Length);
		PlayerPrefs.DeleteAll ();
	}
}
