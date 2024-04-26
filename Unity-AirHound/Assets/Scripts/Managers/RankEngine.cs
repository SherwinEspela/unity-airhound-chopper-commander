using UnityEngine;
using System.Collections;

public class RankEngine : MonoBehaviour {

	//public UISprite spriteRank; 
	//public UILabel labelRank; 

	// Use this for initialization
	void Start () {
		Invoke ("ConfigureRank",1.5f); 
	}

	void ConfigureRank()
	{
		int totalEnemiesDestroyed = 0; 
		if (PlayerPrefs.HasKey("GameCenterTotalEnemiesDestroyedPlayerPrefs")) {
			totalEnemiesDestroyed = PlayerPrefs.GetInt("GameCenterTotalEnemiesDestroyedPlayerPrefs"); 	
		}
		
		if (!MissionLockManager.mission2Locked && totalEnemiesDestroyed >= 200 && totalEnemiesDestroyed < 400) {
			PlayerPrefs.SetInt("PlayerPrefsRank",2);
			//labelRank.text = "Technical Sergeant"; 
		}
		else if (!MissionLockManager.mission3Locked && totalEnemiesDestroyed >= 400 && totalEnemiesDestroyed < 600) {
			PlayerPrefs.SetInt("PlayerPrefsRank",3); 
			//labelRank.text = "Master Sergeant";
		}
		else if (!MissionLockManager.mission4Locked && totalEnemiesDestroyed >= 600 && totalEnemiesDestroyed < 800) {
			PlayerPrefs.SetInt("PlayerPrefsRank",4);
			//labelRank.text = "Senior Master";
		}
		else if (!MissionLockManager.mission4Locked && totalEnemiesDestroyed >= 800 && totalEnemiesDestroyed < 1000) {
			PlayerPrefs.SetInt("PlayerPrefsRank",5); 
			//labelRank.text = "Chief Master";
		}
		else if (!MissionLockManager.mission5Locked && totalEnemiesDestroyed >= 1000 && totalEnemiesDestroyed < 1200) {
			PlayerPrefs.SetInt("PlayerPrefsRank",6); 
			//labelRank.text = "Lieutenant";
		}
		else if (!MissionLockManager.mission6Locked && totalEnemiesDestroyed >= 1200 && totalEnemiesDestroyed < 1400) {
			PlayerPrefs.SetInt("PlayerPrefsRank",7); 
			//labelRank.text = "Captain";
		}
		else if (!MissionLockManager.mission7Locked && totalEnemiesDestroyed >= 1400 && totalEnemiesDestroyed < 1600) {
			PlayerPrefs.SetInt("PlayerPrefsRank",8);
			//labelRank.text = "Major";
		}
		else if (!MissionLockManager.mission8Locked && totalEnemiesDestroyed >= 1600 && totalEnemiesDestroyed < 1800) {
			PlayerPrefs.SetInt("PlayerPrefsRank",9); 
			//labelRank.text = "Colonel";
		}
		else if (!MissionLockManager.mission8Locked && totalEnemiesDestroyed >= 1800 && totalEnemiesDestroyed < 2000) {
			PlayerPrefs.SetInt("PlayerPrefsRank",10); 
			//labelRank.text = "General";
		}
		
		if (PlayerPrefs.HasKey("PlayerPrefsRank")) {
			int spriteNumber = PlayerPrefs.GetInt ("PlayerPrefsRank"); 
			//spriteRank.spriteName = "rank" + spriteNumber; 	
		}
	}
}
