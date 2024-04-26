using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using GooglePlayGames; 
//using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms; 

public class AirHoundGameCenterManager2 : MonoBehaviour {

//	// Buttons
//	public Button[] gameCenterButtons; 
//	public Image[] gameCenterButtonImages; 
//	public Text[] gameCenterButtonTexts; 
//
//	public Toggle toggleGameCenterSignIn; 
//	public Text labelToggleSignIn; 
//
//	/////////////////////////////////// IOS PROCESS
//
//#if UNITY_IOS
//
//	private static bool gameCenterSignedIn = false;  
//
//	#region Game Center Configuration
//	public static string LeaderBoardHighScoreID = "grp.com.SherwinEspela.AirHound.leaderboard";
//	public static string LeaderBoardTotalEnemiesID = "grp.com.SherwinEspela.AirHound.totalEnemies";
//	public static string LeaderBoardTotalNukesID = "grp.com.SherwinEspela.AirHound.totalNukes";
//	public static string LeaderBoardHighScoreSurvivalID = "grp.com.SherwinEspela.AirHound.highScoreSurvival";
//	public static string LeaderBoardTotalNukesSurvivalID = "grp.com.SherwinEspela.AirHound.totalNukesSurvival";
//	
//	public static string AchievementNewRecruitID = "grp.com.SherwinEspela.AirHound.achievement"; // for New Recruit achievement
//	public static string AchievementNovicePilotID = "grp.com.SherwinEspela.AirHound.achievementNovicePilot";
//	public static string AchievementVeteranPilotID = "grp.com.SherwinEspela.AirHound.achievementVeteranPilot";
//	public static string AchievementSurvivalVeteranID = "grp.com.SherwinEspela.AirHound.achievementSurvivalVeteran";
//	public static string AchievementSurvivalMasterID = "grp.com.SherwinEspela.AirHound.achievementSurvivalMaster";
//	public static string AchievementWarFreakID = "grp.com.SherwinEspela.AirHound.achievementWarFreak";
//	public static string AchievementKillingMachineID = "grp.com.SherwinEspela.AirHound.achievementKillingMachine";
//	public static string AchievementTankBusterID = "grp.com.SherwinEspela.AirHound.achievementTankBuster";
//	public static string AchievementAirKingID = "grp.com.SherwinEspela.AirHound.achievementAirKing";
//	public static string AchievementEliteCommanderID = "grp.com.SherwinEspela.AirHound.achievementEliteCommander";
//	public static string AchievementSupremeCommanderID = "grp.com.SherwinEspela.AirHound.achievementSupremeCommander";
//	
//	#endregion
//
//
//
//	// Use this for initialization
//	void Start () {
//		GameCenterManager.OnAuthFinished += OnAuthFinished;
//		GameCenterSignIn (); 
//	}
//
//	public void GameCenterSignIn()
//	{
//		toggleGameCenterSignIn.isOn = true; 
//		toggleGameCenterSignIn.interactable = false; 
//		labelToggleSignIn.text = "GAMECENTER IS CURRENTLY ENABLED"; 
//
//		GameCenterManager.registerAchievement(AchievementNewRecruitID);  
//		GameCenterManager.registerAchievement(AchievementNovicePilotID);
//		GameCenterManager.registerAchievement(AchievementVeteranPilotID);
//		GameCenterManager.registerAchievement(AchievementSurvivalVeteranID);
//		GameCenterManager.registerAchievement(AchievementSurvivalMasterID);
//		GameCenterManager.registerAchievement(AchievementWarFreakID); 
//		GameCenterManager.registerAchievement(AchievementKillingMachineID); 
//		GameCenterManager.registerAchievement(AchievementTankBusterID); 
//		GameCenterManager.registerAchievement(AchievementAirKingID); 
//		GameCenterManager.registerAchievement(AchievementEliteCommanderID); 
//		GameCenterManager.registerAchievement(AchievementSupremeCommanderID); 
//		
//		// Listen for the Game Center events
//		GameCenterManager.dispatcher.addEventListener(GameCenterManager.GAME_CENTER_ACHIEVEMENTS_LOADED, OnAchievementsLoaded); 
//		GameCenterManager.dispatcher.addEventListener(GameCenterManager.GAME_CENTER_ACHIEVEMENT_PROGRESS, OnAchievementProgress);
//		GameCenterManager.dispatcher.addEventListener(GameCenterManager.GAME_CENTER_ACHIEVEMENTS_RESET, OnAchievementsReset);
//		GameCenterManager.dispatcher.addEventListener(GameCenterManager.GAME_CENTER_LEADER_BOARD_SCORE_LOADED, OnLeaderBoardScoreLoaded);	
//		GameCenterManager.dispatcher.addEventListener(GameCenterManager.GAME_CENTER_PLAYER_AUTHENTICATED, OnAuth);
//		
//		GameCenterManager.init();
//	}
//
//	void OnAuthFinished(ISN_Result res)
//	{
//		if (res.IsSucceeded) {
//			// 1. submit scores and achievements to Game Center
//			ReportScore();
//			ReportAchievementProgress(); 
//			// 2. enable the game center buttons
//			EnableGameCenterButtons();
//			gameCenterSignedIn = true;
//			// 3. 
//			toggleGameCenterSignIn.isOn = true; 
//			toggleGameCenterSignIn.interactable = false; 
//			labelToggleSignIn.text = "GAMECENTER IS CURRENTLY ENABLED"; 
//
//		} else {
//			IOSNativePopUpManager.showMessage("Game Center","Player Auth Failed");
//			gameCenterSignedIn = false;
//			DisableGameCenterButtons(); 
//
//			toggleGameCenterSignIn.isOn = false; 
//			toggleGameCenterSignIn.interactable = true; 
//			labelToggleSignIn.text = "SIGNIN TO GAMECENTER TO ENABLE GAMECENTER FEATURES";
//		}
//	}
//
//	void EnableGameCenterButtons()
//	{
//		foreach (var button in gameCenterButtons) {
//			button.interactable = true;
//		}
//
//		foreach (var image in gameCenterButtonImages) {
//			image.color = new Color(0/255f,0/255f,0/255,255f/255f); 
//		}
//
//		foreach (var text in gameCenterButtonTexts) {
//			text.color = new Color(255f/255f,255f/255f,255f/255f,255f/255f);  	
//		}
//	}
//	
//	void DisableGameCenterButtons()
//	{
//		foreach (var button in gameCenterButtons) {
//			button.interactable = false; 	
//		}
//		
//		foreach (var image in gameCenterButtonImages) {
//			image.color = new Color(0/255f,0/255f,0/255,80f/255f); 	
//		}
//		
//		foreach (var text in gameCenterButtonTexts) {
//			text.color = new Color(255f/255f,255f/255f,255f/255f,80f/255f); 	
//		}
//	}
//	
//	// Show Achivement UI Window
//	public void ShowAchievements()
//	{
//		GameCenterManager.showAchievements(); 
//	}
//	
//	// Show Leaderboard UI Window
//	public void ShowGameCenterLeaderboard()
//	{
//		//gameCenter.ShowLeaderboardUI();
//		GameCenterManager.showLeaderBoards(); 
//	}
//	
//	// Show High Score Leaderboard UI
//	public void ShowHighScoreLeaderboard()
//	{
//		//gameCenter.ShowHighScoreUI();
//		GameCenterManager.showLeaderBoard(LeaderBoardHighScoreID); 
//	}
//	
//	// Show Total Nukes Extracted Leaderboard UI
//	public void ShowTotalNukesExtractedLeaderboard()
//	{
//		GameCenterManager.showLeaderBoard(LeaderBoardTotalNukesID); 
//	}
//	
//	// Show Total Enemies Destroyed Leaderboard UI
//	public void ShowTotalEnemiesDestroyedLeaderboard()
//	{
//		GameCenterManager.showLeaderBoard(LeaderBoardTotalEnemiesID); 
//	}
//	
//	//Report Score
//	public void ReportScore()
//	{
//		if (gameCenterSignedIn) {
//			
//			// GAME CENTER LEADERBOARDS
//			
//			// High Score
//			if (PlayerPrefs.HasKey("GameCenterScorePlayerPrefs")) {
//				GameCenterManager.reportScore(PlayerPrefs.GetInt("GameCenterScorePlayerPrefs"),LeaderBoardHighScoreID); 
//			}
//			
//			// Total Enemies Destroyed
//			if (PlayerPrefs.HasKey("GameCenterTotalEnemiesDestroyedPlayerPrefs")) {
//				GameCenterManager.reportScore(PlayerPrefs.GetInt("GameCenterTotalEnemiesDestroyedPlayerPrefs"),LeaderBoardTotalEnemiesID);
//			}
//			
//			// Total Nukes Extracted
//			if (PlayerPrefs.HasKey("GameCenterTotalNukesExtractedPlayerPrefs")) {
//				GameCenterManager.reportScore(PlayerPrefs.GetInt("GameCenterTotalNukesExtractedPlayerPrefs"),LeaderBoardTotalNukesID);
//			}
//			
//			// High Score Survival
//			if (PlayerPrefs.HasKey("GameCenterHighScoreSurvivalPlayerPrefs")) {
//				GameCenterManager.reportScore(PlayerPrefs.GetInt("GameCenterHighScoreSurvivalPlayerPrefs"),LeaderBoardHighScoreSurvivalID);
//			}
//			
//			// Total Nukes Extracted Survival
//			if (PlayerPrefs.HasKey("GameCenterTotalNukesExtractedSurvivalPlayerPrefs")) {
//				GameCenterManager.reportScore(PlayerPrefs.GetInt("GameCenterTotalNukesExtractedSurvivalPlayerPrefs"),LeaderBoardTotalNukesSurvivalID);
//			}
//		}
//	}
//	
//	//Check if User is authenticated to Game Center
////	public void CheckIfUserIsAuthenticated()
////	{
////		//gameCenter.IsUserAuthenticated();
////	}
//	
//	//Report Achievement Progress
//	public void ReportAchievementProgress()
//	{
//		if (gameCenterSignedIn) {
//			
//			// GAME CENTER ACHIEVEMENTS
//			
//			// New Recruit
//			GameCenterManager.submitAchievement(25.0f,AchievementNewRecruitID); 
//			
//			// Supreme Commander
//			if (PlayerPrefs.HasKey("GameCenterSupremeCommanderAchievement")) {
//				GameCenterManager.submitAchievement(25.0f,AchievementSupremeCommanderID);
//			}
//			
//			// Elite Commander
//			if (PlayerPrefs.HasKey("GameCenterEliteCommanderAchievement")) {
//				GameCenterManager.submitAchievement(25.0f,AchievementEliteCommanderID);
//			}
//			
//			// Novice Pilot
//			if (PlayerPrefs.HasKey("GameCenterNovicePilotAchievement")) {
//				GameCenterManager.submitAchievement(25.0f,AchievementNovicePilotID);
//			}
//			
//			// Veteran Pilot
//			if (PlayerPrefs.HasKey("GameCenterVeteranPilotAchievement")) {
//				GameCenterManager.submitAchievement(25.0f,AchievementVeteranPilotID);
//			}
//			
//			// Survival Veteran
//			if (PlayerPrefs.HasKey("GameCenterSurvivalVeteranAchievement")) {
//				GameCenterManager.submitAchievement(25.0f,AchievementSurvivalVeteranID);
//			}
//			
//			// Survival Master
//			if (PlayerPrefs.HasKey("GameCenterSurvivalMasterAchievement")) {
//				GameCenterManager.submitAchievement(25.0f,AchievementSurvivalMasterID);
//			}
//			
//			// War Freak
//			if (PlayerPrefs.HasKey("GameCenterWarFreakAchievement")) {
//				GameCenterManager.submitAchievement(25.0f,AchievementWarFreakID);
//			}
//			
//			// Killing Machine
//			if (PlayerPrefs.HasKey("GameCenterKillingMachineAchievement")) {
//				GameCenterManager.submitAchievement(25.0f,AchievementKillingMachineID);
//			}
//			
//			// Tank Buster
//			if (PlayerPrefs.HasKey("GameCenterTankBusterAchievement")) {
//				GameCenterManager.submitAchievement(25.0f,AchievementTankBusterID);
//			}
//			
//			// Air King
//			if (PlayerPrefs.HasKey("GameCenterAirKingAchievement")) {
//				GameCenterManager.submitAchievement(25.0f,AchievementAirKingID);
//			}
//		}
//	}
//
//	//--------------------------------
//	// EVENTS
//	//--------------------------------
//
//	private void OnAchievementsLoaded()
//	{
//		Debug.Log("Achievement was loaded from IOS Game Center");
//
//		foreach (AchievementTemplate tpl in GameCenterManager.achievements) {
//			Debug.Log(tpl.id + ": " + tpl.progress); 	
//		}
//	}
//
//	private void OnAchievementsReset()
//	{
//		Debug.Log("All Achievements was reset");
//	}
//
//	private void OnAchievementProgress(CEvent e) 
//	{
//		Debug.Log("OnAchievementProgress");
//
//		AchievementTemplate tpl = e.data as AchievementTemplate; 
//		Debug.Log(tpl.id + ": " + tpl.progress.ToString()); 
//	}
//
//	private void OnLeaderBoardScoreLoaded(CEvent e)
//	{
//		LeaderBoardScoreData data = e.data as LeaderBoardScoreData; 
//		IOSNativePopUpManager.showMessage("Leader Board" + data.leaderBoardId, "Score: " + data.leaderBoardScore + "\n" + "Rank:" + data.GetRank()); 
//	}
//
//	private void OnAuth()
//	{
//		//IOSNativePopUpManager.showMessage("Player Authed", "ID: " + GameCenterManager.player.playerId + "\n" + "Alias: " + GameCenterManager.player.alias); 
//	}
//
//#endif
//
//	/////////////////////////////////// ANDROID PROCESS
//
//#if UNITY_ANDROID
//
//	private bool googleUserAuthenticated = false; 
//	//private bool playGamesPlatformActivated = false; 
//
//	// Google Play Services ID's
//	private string googleLeaderBoardHighScoreID = "CgkIv8rT9IkKEAIQAA";
//	private string googleLeaderBoardTotalEnemiesID = "CgkIv8rT9IkKEAIQAg";
//	private string googleLeaderBoardTotalNukesID = "CgkIv8rT9IkKEAIQAQ";
//
//	private string googleAchievementNewRecruitID = "CgkIv8rT9IkKEAIQAw"; // for New Recruit achievement
//	private string googleAchievementNovicePilotID = "CgkIv8rT9IkKEAIQBA";
//	private string googleAchievementVeteranPilotID = "CgkIv8rT9IkKEAIQBQ";
//	private string googleAchievementWarFreakID = "CgkIv8rT9IkKEAIQBg";
//	private string googleAchievementKillingMachineID = "CgkIv8rT9IkKEAIQBw";
//	private string googleAchievementTankBusterID = "CgkIv8rT9IkKEAIQCA";
//	private string googleAchievementAirKingID = "CgkIv8rT9IkKEAIQCQ";
//	private string googleAchievementEliteCommanderID = "CgkIv8rT9IkKEAIQCg";
//	private string googleAchievementSupremeCommanderID = "CgkIv8rT9IkKEAIQCw";
//
//	void Start()
//	{
//		// Configure Google Play Achievement and Leaderboard
//		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build(); 
//	
//		PlayGamesPlatform.InitializeInstance (config); 
//
//		// recommended for debugging:
//		PlayGamesPlatform.DebugLogEnabled = true;
//
//		PlayGamesPlatform.Activate();
//
//		GameCenterSignIn(); 
//	}
//
//	public void GameCenterSignIn()
//	{
//		Social.localUser.Authenticate ((bool success) => {
//			// handle success or failure
//			if (success) {
//				googleUserAuthenticated = true;
//
//				// 1. submit scores and achievements to Game Center
//				ReportScore();
//				ReportAchievementProgress(); 
//				// 2. enable the game center buttons
//				EnableGameCenterButtons();
//				gameCenterSignedIn = true;
//				// 3. 
//				toggleGameCenterSignIn.isOn = true; 
//				toggleGameCenterSignIn.interactable = false; 
//				labelToggleSignIn.text = "GAMECENTER IS CURRENTLY ENABLED"; 
//			} else {
//				googleUserAuthenticated = false; 
//
//				DisableGameCenterButtons(); 
//
//				toggleGameCenterSignIn.isOn = false; 
//				toggleGameCenterSignIn.interactable = true; 
//				labelToggleSignIn.text = "SIGNIN TO GAMECENTER TO ENABLE GAMECENTER FEATURES";
//			}
//		});
//	}
//
//	void EnableGameCenterButtons()
//	{
//		foreach (var button in gameCenterButtons) {
//			button.interactable = true; 	
//		}
//		
//		foreach (var image in gameCenterButtonImages) {
//			image.color = new Color(0/255f,0/255f,0/255,255f/255f);   	
//		}
//		
//		foreach (var text in gameCenterButtonTexts) {
//			text.color = new Color(255f/255f,255f/255f,255f/255f,255f/255f);  	
//		}
//	}
//	
//	void DisableGameCenterButtons()
//	{
//		foreach (var button in gameCenterButtons) {
//			button.interactable = false; 	
//		}
//		
//		foreach (var image in gameCenterButtonImages) {
//			image.color = new Color(0/255f,0/255f,0/255,100f/255f); 	
//		}
//		
//		foreach (var text in gameCenterButtonTexts) {
//			text.color = new Color(255f/255f,255f/255f,255f/255f,255f/255f); 	
//		}
//	}
//
//	public void ReportAchievementProgress()
//	{
//		if (googleUserAuthenticated) {
//			// New Recruit
//			Social.ReportProgress(googleAchievementNewRecruitID,25f,(bool success) => {});
//			
//			// Supreme Commander
//			if (PlayerPrefs.HasKey("GameCenterSupremeCommanderAchievement")) {
//				Social.ReportProgress(googleAchievementSupremeCommanderID,25f,(bool success) => {});
//			}
//			
//			// Elite Commander
//			if (PlayerPrefs.HasKey("GameCenterEliteCommanderAchievement")) {
//				Social.ReportProgress(googleAchievementEliteCommanderID,25f,(bool success) => {});
//			}
//			
//			// Novice Pilot
//			if (PlayerPrefs.HasKey("GameCenterNovicePilotAchievement")) {
//				Social.ReportProgress(googleAchievementNovicePilotID,25f,(bool success) => {});
//			}
//			
//			// Veteran Pilot
//			if (PlayerPrefs.HasKey("GameCenterVeteranPilotAchievement")) {
//				Social.ReportProgress(googleAchievementVeteranPilotID,25f,(bool success) => {});
//			}
//			
//			// War Freak
//			if (PlayerPrefs.HasKey("GameCenterWarFreakAchievement")) {
//				Social.ReportProgress(googleAchievementWarFreakID,25f,(bool success) => {});
//			}
//			
//			// Killing Machine
//			if (PlayerPrefs.HasKey("GameCenterKillingMachineAchievement")) {
//				Social.ReportProgress(googleAchievementKillingMachineID,25f,(bool success) => {});
//			}
//			
//			// Tank Buster
//			if (PlayerPrefs.HasKey("GameCenterTankBusterAchievement")) {
//				Social.ReportProgress(googleAchievementTankBusterID,25f,(bool success) => {});
//			}
//			
//			// Air King
//			if (PlayerPrefs.HasKey("GameCenterAirKingAchievement")) {
//				Social.ReportProgress(googleAchievementAirKingID,25f,(bool success) => {});
//			}	
//		}
//	}
//
//	//Report Score
//	public void ReportScore()
//	{
//		if (googleUserAuthenticated) {
//			
//			// GAME CENTER LEADERBOARDS
//			
//			// High Score
//			if (PlayerPrefs.HasKey("GameCenterScorePlayerPrefs")) {
//				Social.ReportScore(PlayerPrefs.GetInt("GameCenterScorePlayerPrefs"),googleLeaderBoardHighScoreID,(bool success) => {}); 
//			}
//			
//			// Total Enemies Destroyed
//			if (PlayerPrefs.HasKey("GameCenterTotalEnemiesDestroyedPlayerPrefs")) {
//				Social.ReportScore(PlayerPrefs.GetInt("GameCenterTotalEnemiesDestroyedPlayerPrefs"),googleLeaderBoardTotalEnemiesID,(bool success) => {});
//			}
//			
//			// Total Nukes Extracted
//			if (PlayerPrefs.HasKey("GameCenterTotalNukesExtractedPlayerPrefs")) {
//				Social.ReportScore(PlayerPrefs.GetInt("GameCenterTotalNukesExtractedPlayerPrefs"),googleLeaderBoardTotalNukesID,(bool success) => {}); 
//			}
//		}
//	}
//
//	// Show Achivement UI Window
//	public void ShowAchievements()
//	{
//		Social.ShowAchievementsUI(); 
//	}
//	
//	// Show High Score Leaderboard UI
//	public void ShowHighScoreLeaderboard()
//	{
//		Social.ShowLeaderboardUI();  
//	}
//	
//	// Show Total Nukes Extracted Leaderboard UI
//	public void ShowTotalNukesExtractedLeaderboard()
//	{
//		Social.ShowLeaderboardUI(); 
//	}
//	
//	// Show Total Enemies Destroyed Leaderboard UI
//	public void ShowTotalEnemiesDestroyedLeaderboard()
//	{
//		Social.ShowLeaderboardUI(); 
//	}
//
//#endif

}
