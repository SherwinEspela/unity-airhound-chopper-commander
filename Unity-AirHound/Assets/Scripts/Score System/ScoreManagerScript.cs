using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class ScoreManagerScript : MonoBehaviour {

	// score labels
	private Text textScoreValue;
	private GameObject labelEnemiesDestroyedValue;
	private GameObject labelTimeValue;
	private GameObject labelBonusScoreValue; 
	private GameObject labelMissionScoreValue;
	private GameObject labelTotalScoreValue;
	//public GameObject countDownLabel; 

	// score label scripts
	//private UILabel scoreLabelScript;
//	private UILabel enemiesDestroyedLabelScript;
//	private UILabel timeValueLabelScript;
//	private UILabel bonusScoreLabelScript;
//	private UILabel missionScoreLabelScript; 
//	private UILabel totalScoreLabelScript; 
	//private UILabel countdownLabelScript;

	// score values
	private int enemiesDestroyed = 0;
	private int enemyTanksDestroyed = 0;
	private int enemyAirDronesDestroyed = 0;
	private int bonusScore = 0;
	private int missionScore = 0;
	private int totalScore = 0; 
	private string timeString; 
	private int nukesExtracted = 0; 

	private bool missionCompleted = true;

	private int gameCenterTotalHighScore;
	private int gameCenterTotalEnemiesDestroyed;
	private int gameCenterTotalEnemyTanksDestroyed; 
	private int gameCenterTotalEnemyAirDronesDestroyed;
	private int gameCenterTotalNukesExtracted; 
	private int gameCenterHighScoreSurvival; 
	private int gameCenterTotalNukesExtractedSurvival; 

	void Start()
	{
		Invoke ("FindUIElements",1f); 
		//Invoke("FindScoreLabels", 1f); 

		if (PlayerPrefs.HasKey("GameCenterScorePlayerPrefs")) {
			gameCenterTotalHighScore = PlayerPrefs.GetInt("GameCenterScorePlayerPrefs");	
		}

		if (PlayerPrefs.HasKey("GameCenterTotalEnemiesDestroyedPlayerPrefs")) {
			gameCenterTotalEnemiesDestroyed = PlayerPrefs.GetInt("GameCenterTotalEnemiesDestroyedPlayerPrefs");	
		}

		if (PlayerPrefs.HasKey("GameCenterTotalEnemyTanksDestroyedPlayerPrefs")) {
			gameCenterTotalEnemyTanksDestroyed = PlayerPrefs.GetInt("GameCenterTotalEnemyTanksDestroyedPlayerPrefs");	
		}

		if (PlayerPrefs.HasKey("GameCenterTotalEnemyAirDronesDestroyedPlayerPrefs")) {
			gameCenterTotalEnemyAirDronesDestroyed = PlayerPrefs.GetInt("GameCenterTotalEnemyAirDronesDestroyedPlayerPrefs");	
		}

		if (PlayerPrefs.HasKey("GameCenterTotalNukesExtractedPlayerPrefs")) {
			gameCenterTotalNukesExtracted = PlayerPrefs.GetInt("GameCenterTotalNukesExtractedPlayerPrefs");	
		}

		if (PlayerPrefs.HasKey("GameCenterHighScoreSurvivalPlayerPrefs")) {
			gameCenterHighScoreSurvival = PlayerPrefs.GetInt("GameCenterHighScoreSurvivalPlayerPrefs");	
		}

		if (PlayerPrefs.HasKey("GameCenterTotalNukesExtractedSurvivalPlayerPrefs")) {
			gameCenterTotalNukesExtractedSurvival = PlayerPrefs.GetInt("GameCenterTotalNukesExtractedSurvivalPlayerPrefs");	
		}
	}

	void FindUIElements()
	{
		GameObject tsvGo = GameObject.Find ("TextScoreValue");
		textScoreValue = tsvGo.GetComponent<Text>(); 
//		if (DeviceManager.deviceIsIPad) {
//			textScoreValue.transform.localPosition = new Vector3(416f,358f,0f);
//			textScoreValue.transform.localScale = new Vector3(80f,80f,1f); 
//		} else {
//			textScoreValue.transform.localPosition = new Vector3(553f,349f,0f);
//			textScoreValue.transform.localScale = new Vector3(100f,100f,1f);
//		}
	}

	private void FindScoreLabels()
	{
//		labelEnemiesDestroyedValue = GameObject.Find("LabelEnemiesDestroyedValue"); 
//		enemiesDestroyedLabelScript = labelEnemiesDestroyedValue.GetComponent<UILabel>(); 
//		labelTimeValue = GameObject.Find("LabelTimeValue"); 
//		timeValueLabelScript = labelTimeValue.GetComponent<UILabel>(); 
//		labelMissionScoreValue = GameObject.Find("LabelMissionScoreValue"); 
//		missionScoreLabelScript = labelMissionScoreValue.GetComponent<UILabel>();
//		labelBonusScoreValue = GameObject.Find("LabelBonusScoreValue"); 
//		bonusScoreLabelScript = labelBonusScoreValue.GetComponent<UILabel>();
//		labelTotalScoreValue = GameObject.Find("LabelTotalScoreValue"); 
//		totalScoreLabelScript = labelTotalScoreValue.GetComponent<UILabel>();
	}

	// Called from PointsScript class
	public void AddPointsToScore(int points)
	{
		missionScore += points; 
		if (missionScore > 999999) {
			missionScore = 999999; 	
		}

		if (missionScore <= 9) {
			textScoreValue.text = "00000" + missionScore.ToString();	
		}
		else if (missionScore <= 99) {
			textScoreValue.text = "0000" + missionScore.ToString();	
		}
		else if (missionScore <= 999) {
			textScoreValue.text = "000" + missionScore.ToString();	
		}
		else if (missionScore <= 9999) {
			textScoreValue.text = "00" + missionScore.ToString();	
		}
		else if (missionScore <= 99999) {
			textScoreValue.text = "0" + missionScore.ToString();	
		} 
		else {
			textScoreValue.text = missionScore.ToString();
		}
	}

	// Called from PointsScript class
	public void AddPointsToEnemyDestroyed()
	{
		enemiesDestroyed += 1;
		//enemiesDestroyedLabelScript.text = enemiesDestroyed.ToString(); 
	}

	// Called from PointsScript class
	public void AddPointsToEnemyTanksDestroyed()
	{
		enemyTanksDestroyed++; 
	}

	// Called from PointsScript class
	public void AddPointsToEnemyAirDronesDestroyed()
	{
		enemyAirDronesDestroyed++;
	}

	// Called from ItemPickerScript class, OnCollisionEnter method
	public void AddPointsToNukesExtracted()
	{
		nukesExtracted++;
	}

	public void ComputeBonusScore()
	{
		TimerScript timerScript = gameObject.GetComponent<TimerScript>();
		GameManagerScript gameManagerScript = gameObject.GetComponent<GameManagerScript>();

		float finishedMinutesValue = timerScript.GetMinutesValue();
		float finishedSecondsValue = timerScript.GetSecondsValue();

		if (finishedSecondsValue <= 9) {
			string secondsValue = "0" + finishedSecondsValue;
			SetTimeFinished(finishedMinutesValue.ToString(),secondsValue); 
		} else {
			SetTimeFinished(finishedMinutesValue.ToString(),finishedSecondsValue.ToString()); 
		}

		int finishedTimeInSeconds = (int)(finishedMinutesValue * 60) + (int)(finishedSecondsValue); 

		int timeBonus = finishedTimeInSeconds * 10;
		int enemiesDestroyedBonus = enemiesDestroyed * 10; 

		// therefore
		if (missionCompleted) {
			bonusScore = timeBonus + enemiesDestroyedBonus;	
		} else {
			bonusScore = enemiesDestroyedBonus; 
		}
	}

	private void SetTimeFinished(string minute, string seconds)
	{
		timeString = minute + " : " + seconds;
	}

	private string GetTimeFinished()
	{
		return timeString;  
	}

	public void DisplayMissionScoreDetails()
	{
		//timeValueLabelScript.text = GetTimeFinished(); 
		this.gameObject.BroadcastMessage ("SetTextTimeRemainingValue",GetTimeFinished(),SendMessageOptions.DontRequireReceiver); // from UnityGUIGamePlayManager.cs 
		//bonusScoreLabelScript.text = bonusScore.ToString();
		this.gameObject.BroadcastMessage ("SetTextBonusScoreValue",bonusScore.ToString(),SendMessageOptions.DontRequireReceiver); // from UnityGUIGamePlayManager.cs
		//missionScoreLabelScript.text = missionScore.ToString(); 
		this.gameObject.BroadcastMessage ("SetTextMissionScoreValue",missionScore.ToString(),SendMessageOptions.DontRequireReceiver); // from UnityGUIGamePlayManager.cs
		totalScore = bonusScore + missionScore;
		//totalScoreLabelScript.text = totalScore.ToString(); 
		this.gameObject.BroadcastMessage ("SetTextTotalScoreValue",totalScore.ToString(),SendMessageOptions.DontRequireReceiver); // from UnityGUIGamePlayManager.cs

		// Save GameCenter Leaderboards
		SaveGameCenterScore(totalScore);
		SaveGameCenterTotalEnemiesDestroyed(enemiesDestroyed);
		SaveGameCenterTotalNukesExtracted();

		if (SurvivalMissionScript.isSurvivalMission) {
			SaveGameCenterHighScoreSurvival(totalScore);
			SaveGameTotalNukesExtractedSurvival();
		}
	}

	public void InvokeRunScoreManagerScript(bool missionOutcome)
	{
		missionCompleted = missionOutcome; 
		Invoke("RunScoreManagerScript",1f); 
	}

	void RunScoreManagerScript()
	{
		//this.gameObject.BroadcastMessage("HidePanelTopHud",SendMessageOptions.DontRequireReceiver); // from ControlsVisibilityScript.cs
		ComputeBonusScore();
		DisplayMissionScoreDetails();
	}

	// Called in DisplayMissionScoreDetails method
	void SaveGameCenterScore(int totalMissionScore)
	{
		gameCenterTotalHighScore += totalMissionScore;
		PlayerPrefs.SetInt("GameCenterScorePlayerPrefs",gameCenterTotalHighScore);
	}

	// Called in DisplayMissionScoreDetails method
	void SaveGameCenterTotalEnemiesDestroyed(int totalEnemiesDestroyed)
	{
		// for Total Enemies Destroyed
		gameCenterTotalEnemiesDestroyed += totalEnemiesDestroyed;
		if (gameCenterTotalEnemiesDestroyed >= 1000) {
			// Game Center Achievement - War Freak
			PlayerPrefs.SetInt("GameCenterWarFreakAchievement",1);	
		}
		if (gameCenterTotalEnemiesDestroyed >= 10000) {
			// Game Center Achievement - Killing Machine
			PlayerPrefs.SetInt("GameCenterKillingMachineAchievement",1);	
		}

		PlayerPrefs.SetInt("GameCenterTotalEnemiesDestroyedPlayerPrefs",gameCenterTotalEnemiesDestroyed);

		// For Total Tanks destroyed
		gameCenterTotalEnemyTanksDestroyed += enemyTanksDestroyed;
		if (gameCenterTotalEnemyTanksDestroyed >= 1000) {
			// Game Center Achievement - Tank Buster
			PlayerPrefs.SetInt("GameCenterTankBusterAchievement",1);	
		}
		PlayerPrefs.SetInt("GameCenterTotalEnemyTanksDestroyedPlayerPrefs",gameCenterTotalEnemyTanksDestroyed);

		// For Total Air Drones destroyed
		gameCenterTotalEnemyAirDronesDestroyed += enemyAirDronesDestroyed;
		if (gameCenterTotalEnemyAirDronesDestroyed >= 1000) {
			// Game Center Achievement - Air King
			PlayerPrefs.SetInt("GameCenterAirKingAchievement",1);
		}
		PlayerPrefs.SetInt("GameCenterTotalEnemyAirDronesDestroyedPlayerPrefs",gameCenterTotalEnemyAirDronesDestroyed);
	}

	// Called in DisplayMissionScoreDetails method
	void SaveGameCenterTotalNukesExtracted()
	{
		gameCenterTotalNukesExtracted += nukesExtracted;
		if (gameCenterTotalNukesExtracted >= 100) {
			// Game Center Achievement - Novice Pilot
			PlayerPrefs.SetInt("GameCenterNovicePilotAchievement",1);			
		}

		if (gameCenterTotalNukesExtracted >= 1000) {
			// Game Center Achievement - Veteran Pilot
			PlayerPrefs.SetInt("GameCenterVeteranPilotAchievement",1);			
		}

		PlayerPrefs.SetInt("GameCenterTotalNukesExtractedPlayerPrefs",gameCenterTotalNukesExtracted);
	}

	// Called in DisplayMissionScoreDetails method
	void SaveGameCenterHighScoreSurvival(int totalMissionScore)
	{
		gameCenterHighScoreSurvival += totalMissionScore;
		PlayerPrefs.SetInt("GameCenterHighScoreSurvivalPlayerPrefs",gameCenterHighScoreSurvival);
	}

	// Called in DisplayMissionScoreDetails method
	void SaveGameTotalNukesExtractedSurvival()
	{
		gameCenterTotalNukesExtractedSurvival += nukesExtracted;
		if (gameCenterTotalNukesExtractedSurvival >= 100) {
			// Game Center Achievement - Survival Veteran
			PlayerPrefs.SetInt("GameCenterSurvivalVeteranAchievement",1);	
		}

		if (gameCenterTotalNukesExtractedSurvival >= 1000) {
			// Game Center Achievement - Survival Master
			PlayerPrefs.SetInt("GameCenterSurvivalMasterAchievement",1);	
		}

		PlayerPrefs.SetInt("GameCenterTotalNukesExtractedSurvivalPlayerPrefs",gameCenterTotalNukesExtractedSurvival);
	}

	// Called by YES Button when the game is paused and player wants to go to Main Menu
	public void SaveGameCenterScoresWhenPausedAndGoingToMainMenu()
	{
		if (ItemPickerScript.gameIsPaused) {
			// Save GameCenter Leaderboards
			SaveGameCenterScore(totalScore);
			SaveGameCenterTotalEnemiesDestroyed(enemiesDestroyed);
			SaveGameCenterTotalNukesExtracted();
			
			if (SurvivalMissionScript.isSurvivalMission) {
				SaveGameCenterHighScoreSurvival(totalScore);
				SaveGameTotalNukesExtractedSurvival();
			}	
		}
	}
}
