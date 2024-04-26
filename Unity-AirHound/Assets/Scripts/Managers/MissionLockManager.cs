using UnityEngine;
using System.Collections;

public class MissionLockManager : MonoBehaviour {

	public static bool mission2Locked = true;
	public static bool mission3Locked = true;
	public static bool mission4Locked = true;
	public static bool mission5Locked = true;
	public static bool mission6Locked = true;
	public static bool mission7Locked = true;
	public static bool mission8Locked = true;
	public static bool missionSurvivalLocked = true;
	public static bool missionExtra2Locked = true; 
	public static bool missionExtra3Locked = true; 
	public static bool missionExtra4Locked = true; 
	public static bool missionExtra5Locked = true; 
	public static bool missionExtra6Locked = true; 
	public static bool missionExtra7Locked = true; 
	public static bool missionExtra8Locked = true; 

	public static bool missionIsUnlocked; 

	void Start()
	{ 
		// PLAYERPREFS
		if (PlayerPrefs.HasKey("Mission2Unlocked")) {
			mission2Locked = false; 	
		}

		if (PlayerPrefs.HasKey("Mission3Unlocked")) {
			mission3Locked = false; 	
		}

		if (PlayerPrefs.HasKey("Mission4Unlocked")) {
			mission4Locked = false; 	
		}

		if (PlayerPrefs.HasKey("Mission5Unlocked")) {
			mission5Locked = false; 	
		}

		if (PlayerPrefs.HasKey("Mission6Unlocked")) {
			mission6Locked = false; 	
		}

		if (PlayerPrefs.HasKey("Mission7Unlocked")) {
			mission7Locked = false; 	
		}

		if (PlayerPrefs.HasKey("Mission8Unlocked")) {
			mission8Locked = false; 	
		}

		if (PlayerPrefs.HasKey("MissionSurvivalUnlocked")) {
			missionSurvivalLocked = false; 	
		}
	}
}
