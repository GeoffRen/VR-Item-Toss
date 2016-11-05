using UnityEngine;
using System.Collections;

// Class containing Constants
public static class Constants {

	// The ball
	public const string BALL = "Ball";

	// The rock
	public const string ROCK = "Rock";

	// The bucket 
	public const string BUCKET = "Bucket";

	// The rock throw speed
	public const float ROCK_SPEED = 75f;

	// The ball throw speed
	public const float BALL_SPEED = 50f;

	// The pointer
	public const string POINTER = "Pointer";

	// The object the pointer will point to at all times
	public const string DIRECTION = "Direction";

	// The horizontal force display 
	public const string WIND = "Wind";

	// The HUD
	public const string HUD = "HUD";

	// The main pause menu
	public const string PAUSE_MENU = "Pause_Menu";

	// The object selection menu
	public const string OBJECTS_MENU = "Objects_Menu";

	// The scores sub menu
	public const string SCORE_MENU = "Scores_Menu";

	// The difficulty sub menu
	public const string DIFFICULTY_MENU = "Difficulty_Menu";

	// The normal score sub menu
	public const string NORMAL_SCORES = "Normal_Scores";

	// The hard score sub menu
	public const string HARD_SCORES = "Hard_Scores";

	// The impossible score sub menu
	public const string IMPOSSIBLE_SCORES = "Impossible_Scores";

	// The normal difficulty
	public const string NORMAL = "Normal";

	// The hard difficulty
	public const string HARD = "Hard";

	// The impossible difficulty
	public const string IMPOSSIBLE = "Impossible";

	// The highest score for the normal difficulty
	public const string NORMAL_HIGHSCORE_1ST = "Normal 1st";

	// The second highest score for the normal difficulty
	public const string NORMAL_HIGHSCORE_2ND = "Normal 2nd";

	// The third highest score for the normal difficulty
	public const string NORMAL_HIGHSCORE_3RD = "Normal 3rd";

	// The highest score for the hard difficulty
	public const string HARD_HIGHSCORE_1ST = "Hard 1st";

	// The second highest score for the hard difficulty
	public const string HARD_HIGHSCORE_2ND = "Hard 2nd";

	// The third highest score for the hard difficulty
	public const string HARD_HIGHSCORE_3RD = "Hard 3rd";

	// The highest score for the impossible difficulty
	public const string IMPOSSIBLE_HIGHSCORE_1ST = "Impossible 1st";

	// The second highest score for the impossible difficulty
	public const string IMPOSSIBLE_HIGHSCORE_2ND = "Impossible 2nd";

	// The third highest score for the impossible difficulty
	public const string IMPOSSIBLE_HIGHSCORE_3RD = "Impossible 3rd";

	// Tag representing objects that the thrown object bounces off of
	public const string UNREACTIVE = "Unreactive";

	// The player 
	public const string PLAYER = "Head";

	// The respawn object, the held object appears at this location
	public const string RESPAWN = "Respawn";

	// The score 
	public const string SCORE = "Score";

	// The position of the bucket on normal difficulty
	public static Vector3 NORMAL_POSITION { get { return new Vector3 (-4.3f, 1f, -55f); } }

	// The position of the bucket on hard difficulty
	public static Vector3 HARD_POSITION { get { return new Vector3 (-4.3f, 1f, -15f); } }

	// The position of the bucket on impossible difficulty
	public static Vector3 IMPOSSIBLE_POSITION { get { return new Vector3 (-4.3f, 1f, 25f); } }

	// The gravity of the rock
	public static Vector3 ROCK_GRAVITY { get { return new Vector3 (0, -75f, 0); } }

	// The gravity of the ball
	public static Vector3 BALL_GRAVITY { get { return new Vector3 (0, -50f, 0); } }
}
