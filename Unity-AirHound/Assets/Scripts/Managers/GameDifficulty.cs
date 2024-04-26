using UnityEngine;
using System.Collections;

public class GameDifficulty : MonoBehaviour {

	public enum Difficulty
	{
		easy,
		normal,
		hard
	};

	public static Difficulty gameDifficulty = Difficulty.normal;

	// Enemy Constant Damage Values
	// Easy 
	public static float enemyCannondamage_easy = 10f;
	public static float enemyRocketLauncherdamage_easy = 20f;

	// Normal 
	public static float enemyCannondamage_normal = 10f;
	public static float enemyRocketLauncherdamage_normal = 20f;

	// Hard 
	public static float enemyCannondamage_hard = 10f;
	public static float enemyRocketLauncherdamage_hard = 20f;


	public void SetDifficultyToEasy()
	{
		gameDifficulty = Difficulty.easy;
	}

	public void SetDifficultyToNormal()
	{
		gameDifficulty = Difficulty.normal;
	}

	public void SetDifficultyToHard()
	{
		gameDifficulty = Difficulty.hard;
	}
}
