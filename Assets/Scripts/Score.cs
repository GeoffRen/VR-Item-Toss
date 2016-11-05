using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

// Controls scoring
public class Score : MonoBehaviour {

	// The current score
	private int mCurScore;

	// The current normal high scores
	public static int[] normalHighScore;

	// The current hard high scores
	public static int[] hardHighScore;

	// The current impossible high scores
	public static int[] impossibleHighScore;

	// The current high score index, used to help keep track of 
	// which high score place (1st, 2nd, 3rd) the player is currently at
	private int mIndex;

	// Displayes the score
	private Text mScore;

	// Initializes everything
	void Awake () {

		// mIndex is initialized to 3 because index 3 doesn't represent a high
		// score place, it is used to initially test whether a score is a high
		// score
		mCurScore = 0;
		mIndex = 3;

		mScore = GameObject.Find (Constants.SCORE).GetComponent<Text>();

		normalHighScore = new int[] {
			PlayerPrefs.GetInt (Constants.NORMAL_HIGHSCORE_1ST),
			PlayerPrefs.GetInt (Constants.NORMAL_HIGHSCORE_2ND),
			PlayerPrefs.GetInt (Constants.NORMAL_HIGHSCORE_3RD),
			0
		};
		
		hardHighScore = new int[] {
			PlayerPrefs.GetInt (Constants.HARD_HIGHSCORE_1ST),
			PlayerPrefs.GetInt (Constants.HARD_HIGHSCORE_2ND),
			PlayerPrefs.GetInt (Constants.HARD_HIGHSCORE_3RD),
			0
		};

		impossibleHighScore = new int[] {
			PlayerPrefs.GetInt (Constants.IMPOSSIBLE_HIGHSCORE_1ST),
			PlayerPrefs.GetInt (Constants.IMPOSSIBLE_HIGHSCORE_2ND),
			PlayerPrefs.GetInt (Constants.IMPOSSIBLE_HIGHSCORE_3RD),
			0
		};
	}

	// Sets the UI to 0 for the current score and whatever the high score is
	void Start () {
		setScore ();
	}

	// Updates the score
	void Update () {

		// If the ball hit the ground, reset the score
		if (Floor.reset) {
			mCurScore = 0;
			mIndex = 3;
			Floor.reset = false;

			setScore ();
		}
	}

	// When the game ends, save the high score
	void OnDestroy () {
		saveScore ();
	}

	// Displays the score and determines if there's a new high score
	void setScore () {

		// Determines which difficulty high score container to use
		int[] highScore;
		if (Difficulty_Menu.difficulty == Constants.NORMAL) {
			highScore = normalHighScore;

		} else if (Difficulty_Menu.difficulty == Constants.HARD) {
			highScore = hardHighScore;

		} else {
			highScore = impossibleHighScore;
		}
			
		// Inserts the current score into the array 
		highScore[mIndex] = mCurScore;

		// Sorts in descending order
		Array.Sort<int> (highScore, 
			new Comparison<int> (
				(i1, i2) => i2.CompareTo (i1)
			));

		// Finds the index where the current score is in the sorted array
		for (int i = 0; i < highScore.Length; i++) {
			if (highScore [i] == mCurScore) {
				mIndex = i;
				break;
			}
		}

		mScore.text = "Score: " + mCurScore + "\nHigh Score: " + highScore [0];
	}

	// If the ball goes in the bucket, increment, set, and save the score
	void OnCollisionEnter(Collision collision) {
		mCurScore += 1;
		setScore ();
		saveScore ();
	}

	// Saves the score
	public void saveScore() {
		PlayerPrefs.SetInt (Constants.NORMAL_HIGHSCORE_1ST, normalHighScore [0]);
		PlayerPrefs.SetInt (Constants.NORMAL_HIGHSCORE_2ND, normalHighScore [1]);
		PlayerPrefs.SetInt (Constants.NORMAL_HIGHSCORE_3RD, normalHighScore [2]);

		PlayerPrefs.SetInt (Constants.HARD_HIGHSCORE_1ST, hardHighScore [0]);
		PlayerPrefs.SetInt (Constants.HARD_HIGHSCORE_2ND, hardHighScore [1]);
		PlayerPrefs.SetInt (Constants.HARD_HIGHSCORE_3RD, hardHighScore [2]);

		PlayerPrefs.SetInt (Constants.IMPOSSIBLE_HIGHSCORE_1ST, impossibleHighScore [0]);
		PlayerPrefs.SetInt (Constants.IMPOSSIBLE_HIGHSCORE_2ND, impossibleHighScore [1]);
		PlayerPrefs.SetInt (Constants.IMPOSSIBLE_HIGHSCORE_3RD, impossibleHighScore [2]);
	}
}
