using UnityEngine;
using System.Collections;

public class MissionOutcomeScript2 : MonoBehaviour {

	// New Mission Outcome UI
	//public GameObject panelMissionOutcome; 
	private GameObject gameManager; 
//	private GameObject panelScoreMenu; 
//	private GameObject panelInviteFriendsMenu; 
//	private GameObject panelNavigationMenu; 

//	public AnimationClip panelScoreMenuSlideIn; 
//	public AnimationClip panelScoreMenuSlideOut; 
//	public AnimationClip panelInviteFriendsMenuSlideIn; 
//	public AnimationClip panelInviteFriendsMenuSlideOut;
//	public AnimationClip panelNavigationMenuSlideIn;
//	public AnimationClip panelNavigationMenuSlideOut;

	private Color missionCompleteColor = new Color(28f/255f,113f/255f,251f/255f,255f/255f); 
	private Color missionFailedColor = new Color(255f/255f,0f,0f,255f/255f);

	//private GameObject panelMissionOutcomeObject; 

	// Navigation buttons
//	private GameObject buttonPlayAgain; 
//	private GameObject buttonMainMenu; 
//	private GameObject buttonNextMission;
	//private GameObject buttonRevive;
//	private GameObject panelNavigationButtons; 
//	private GameObject buttonBackPanelNav;
	private bool isFailedByTimeOut; 

//	private GameObject labelNavPlayAgain; 
//	private GameObject labelNavMainMenu; 

//	private GameObject labelRocketInvValue;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager"); 

		// load the panelMissionOutcome prefab
//		GameObject panelMissionOutcomeObject = Instantiate(panelMissionOutcome) as GameObject;
//		Transform panelMenu = GameObject.Find("PanelMenu").transform;
//		panelMissionOutcomeObject.transform.parent = panelMenu;
//		panelMissionOutcomeObject.transform.localPosition = new Vector3(0,0,0); 
//		panelMissionOutcomeObject.transform.localScale = new Vector3(1f,1f,1f);

//		if (DeviceManager.deviceIsIPad) {

//		buttonPlayAgain = GameObject.Find("ButtonPlayAgain"); 
//		buttonMainMenu = GameObject.Find("ButtonMainMenu");
//		buttonNextMission = GameObject.Find("ButtonNextMission"); 
		//buttonRevive = GameObject.Find("ButtonRevive");
//		panelNavigationButtons = GameObject.Find("PanelNavigationButtons"); 
//		buttonBackPanelNav = GameObject.Find("ButtonBackPanelNav");
		//AssignTargetsToButtons();
//		labelNavPlayAgain = GameObject.Find("LabelNavPlayAgain");
//		labelNavMainMenu = GameObject.Find("LabelNavMainMenu"); 

		//Invoke("HideThePanelMissionOutcome", 5f); 
	}

	void HideThePanelMissionOutcome()
	{
//		if (panelMissionOutcomeObject) {
//			panelMissionOutcomeObject.SetActive(false);	
//		} else {
//			panelMissionOutcomeObject = GameObject.Find("PanelMissionOutcome(Clone)");
//			panelMissionOutcomeObject.SetActive(false); 
//		}
	}

	public void MissionCompleteEnter()
	{
		//FindPanels(); 
		//panelScoreMenu.animation.Play(panelScoreMenuSlideIn.name); 
	
		// change the top banner colors to blue
		//ChangeTheTopBannerColors(missionCompleteColor); 
	
		// change the score label colors to blue
		//ChangeTheScoreLabelColors(missionCompleteColor);

		// show stars
		//DisplayStars(true); 
	
		// change labelCongratulations message
		//ChangeScoreOutcomeMessage("Congratulations"); 
	
		// change LabelMissionComplete text input to mission complete
		//ChangeLabelMissionCompleteInputText("MISSION-" + SceneIndexManager.sceneIndex + " COMPLETE");

		// configure the navigation buttons
		//RepositionNavigationButtons(116,-23,-162,116); // original positions
		//buttonRevive.SetActive(false); 

		// if it is mission 8, which is the last mission
//		if (buttonNextMission == null) {
//			buttonNextMission = GameObject.Find("ButtonNextMission");	
//		}
		if (SceneIndexManager.sceneIndex == 8 || GameDifficulty.gameDifficulty == GameDifficulty.Difficulty.easy) {
			//buttonNextMission.SetActive(false); 
		} else {
			//buttonNextMission.SetActive(true);
		}

		//GetRocketInventoryValue();
	}

	void FindPanels()
	{
//		if (panelMissionOutcomeObject) {
//			panelMissionOutcomeObject.SetActive(true);	
//		} else {
//			panelMissionOutcomeObject = GameObject.Find("PanelMissionOutcome(Clone)");
//			panelMissionOutcomeObject.SetActive(true); 
//		}
//
//		panelScoreMenu = GameObject.Find("PanelScoreMenu"); 
//		panelInviteFriendsMenu = GameObject.Find("PanelInviteFriendsMenu");
//		panelNavigationMenu = GameObject.Find("PanelNavigationMenu");
	}

	public void SetIsFailedByTimeOut()
	{
		isFailedByTimeOut = true; 
	}

	public void SetIsFailedByDestruction()
	{
		isFailedByTimeOut = false; 
	}

	public void MissionFailedEnter(string inputText)
	{
		//FindPanels();
		//panelScoreMenu.animation.Play(panelScoreMenuSlideIn.name);

		// change the top banner colors to red 
		//ChangeTheTopBannerColors(missionFailedColor);

		// change the score label colors to red
		//ChangeTheScoreLabelColors(missionFailedColor);

		// hide the stars
		//DisplayStars(false);

		// change labelCongratulations message
		//ChangeScoreOutcomeMessage(inputText); 

		// change LabelMissionComplete text input to mission failed
		//ChangeLabelMissionCompleteInputText("MISSION-" + SceneIndexManager.sceneIndex + " FAILED"); 
	
		// configure the navigation buttons
		if (isFailedByTimeOut) {
//			RepositionNavigationButtons(116,-23,-162,116); // original positions
//			labelNavPlayAgain.transform.localPosition = new Vector3(0,-10,-58);
//			labelNavMainMenu.transform.localPosition = new Vector3(0,3.426f,-58); 
			//buttonRevive.SetActive(false);
		} else {
//			RepositionNavigationButtons(-23,-162,-162,116);
//			labelNavPlayAgain.transform.localPosition = new Vector3(0,3.426f,-58);
//			labelNavMainMenu.transform.localPosition = new Vector3(0,15,-58); 
		}

		// disable the next mission button since the player failed the mission
//		if (buttonNextMission == null) {
//			buttonNextMission = GameObject.Find("ButtonNextMission");	
//		}
		//buttonNextMission.SetActive(false); 

		//GetRocketInventoryValue(); 
	}

	void ChangeTheTopBannerColors(Color topBannerColor)
	{
//		GameObject panelScoreTopBanner = GameObject.Find("panelScoreTopBanner"); 
//		GameObject panelInviteFriendsTopBanner = GameObject.Find("panelInviteFriendsTopBanner");
//		GameObject panelNavigationTopBanner = GameObject.Find("panelNavigationTopBanner");
//		
//		GameObject[] topBanners = {panelScoreTopBanner,panelInviteFriendsTopBanner,panelNavigationTopBanner}; 
//		foreach (GameObject topBanner in topBanners) {
//			UISlicedSprite slicedSpriteScript = topBanner.GetComponent<UISlicedSprite>(); 
//			slicedSpriteScript.color = topBannerColor; 
//		}
	}

	void ChangeTheScoreLabelColors(Color scoreLabelColor)
	{
//		GameObject labelTimeRemaining = GameObject.Find("LabelTimeRemaining"); 
//		GameObject labelEnemiesDestroyed = GameObject.Find("LabelEnemiesDestroyed");
//		GameObject labelBonusScore = GameObject.Find("LabelBonusScore");
//		GameObject labelMissionScore = GameObject.Find("LabelMissionScore");
//		GameObject labelTotalScore = GameObject.Find("LabelTotalScore");
//
//		GameObject[] scoreLabels = {labelTimeRemaining,labelEnemiesDestroyed,labelBonusScore,
//									labelMissionScore,labelTotalScore}; 
//		foreach (GameObject scoreLabel in scoreLabels) {
//			UILabel labelScript = scoreLabel.GetComponent<UILabel>(); 
//			labelScript.color = scoreLabelColor; 
//		}
	}

	void DisplayStars(bool decision)
	{
//		GameObject starsLeft = GameObject.Find("starsLeft"); 
//		GameObject starsRight = GameObject.Find("starsRight"); 

		if (decision == true) {
//			if (starsLeft) {
//				starsLeft.SetActive(true); 	
//			}
//			if (starsRight) {
//				starsRight.SetActive(true);	
//			}
		} else {
//			if (starsLeft) {
//				starsLeft.SetActive(false); 	
//			}
//			if (starsRight) {
//				starsRight.SetActive(false);	
//			}
		}
	}

//	void ChangeScoreOutcomeMessage(string message)
//	{
//		GameObject labelOutcomeMessage = GameObject.Find("LabelOutcomeMessage"); 
//		UILabel labelScript = labelOutcomeMessage.GetComponent<UILabel>(); 
//		labelScript.text = message;
//	}

//	void ChangeLabelMissionCompleteInputText(string input)
//	{
//		GameObject labelMissionComplete = GameObject.Find("LabelMissionComplete"); 
//		UILabel labelScript = labelMissionComplete.GetComponent<UILabel>();
//		labelScript.text = input; 
//	}

	void GetRocketInventoryValue()
	{
//		if (gameManager == null) {
//			gameManager = GameObject.Find("GameManager");	
//		}
//
//		WeaponsInventoryScript wis = gameManager.GetComponent<WeaponsInventoryScript>(); 
//		int rocketValue = wis.GetRocketInventory();
//
//		if (labelRocketInvValue == null) {
//			labelRocketInvValue = GameObject.Find("LabelRocketInvValue");	
//		}
//		UILabel labelScript = labelRocketInvValue.GetComponent<UILabel>(); 
//
//		if (rocketValue >= 10) {
//			labelScript.text = rocketValue.ToString();
//		} else {
//			labelScript.text = "0" + rocketValue; 
//		} 
	}

	void AssignTargetsToButtons()
	{
//		GameObject buttonNextPanelScore = GameObject.Find("ButtonNextPanelScore"); 
//		GameObject buttonBackPanelInvite = GameObject.Find("ButtonBackPanelInvite");
//		GameObject buttonNextPanelInvite = GameObject.Find("ButtonNextPanelInvite");
//		//buttonBackPanelNav = GameObject.Find("ButtonBackPanelNav");
//		GameObject[] buttons = {buttonNextPanelScore,buttonBackPanelInvite,
//								buttonNextPanelInvite,buttonBackPanelNav}; 
//
//		foreach (GameObject button in buttons) {
//			UIButtonMessage bmScript = button.GetComponent<UIButtonMessage>();
//			bmScript.target = gameManager;	
//		}
	}

//	void RepositionNavigationButtons(int yPos_playAgain,int yPos_mainMenu,int yPos_nextMission,int yPos_revive)
//	{
//		buttonPlayAgain.transform.localPosition = new Vector3(0,yPos_playAgain,buttonPlayAgain.transform.localPosition.z); 
//		buttonMainMenu.transform.localPosition = new Vector3(0,yPos_mainMenu,buttonMainMenu.transform.localPosition.z);
//		buttonNextMission.transform.localPosition = new Vector3(0,yPos_nextMission,buttonNextMission.transform.localPosition.z); 
//		//buttonRevive.transform.localPosition = new Vector3(0,yPos_revive,buttonRevive.transform.localPosition.z);
//	}

//	public void DisplayNavigationButtons()
//	{
//		buttonBackPanelNav.collider.enabled = true; 
//		panelNavigationButtons.SetActive(true);
//	}
//
//	public void HideNavigationButtons()
//	{
//		buttonBackPanelNav.collider.enabled = false;
//		panelNavigationButtons.SetActive(false); 
//	}
//
//	public void PanelScoreMenuToInviteFriendsMenu()
//	{
//		panelScoreMenu.animation[panelScoreMenuSlideOut.name].speed = 1.0f; 
//		panelInviteFriendsMenu.animation[panelInviteFriendsMenuSlideIn.name].speed = 1.0f; 
//		panelScoreMenu.animation.Play(panelScoreMenuSlideOut.name); 
//		panelInviteFriendsMenu.animation.Play(panelInviteFriendsMenuSlideIn.name);
//	}
//
//	public void PanelInviteFriendsMenuToScoreMenu()
//	{
//		panelScoreMenu.animation[panelScoreMenuSlideOut.name].speed = -1.0f; 
//		panelScoreMenu.animation[panelScoreMenuSlideOut.name].time = panelScoreMenu.animation[panelScoreMenuSlideOut.name].length; 
//		panelInviteFriendsMenu.animation[panelInviteFriendsMenuSlideIn.name].speed = -1.0f; 
//		panelInviteFriendsMenu.animation[panelInviteFriendsMenuSlideIn.name].time = panelInviteFriendsMenu.animation[panelInviteFriendsMenuSlideIn.name].length;
//		panelScoreMenu.animation.Play(panelScoreMenuSlideOut.name); 
//		panelInviteFriendsMenu.animation.Play(panelInviteFriendsMenuSlideIn.name);
//	}

//	public void PanelInviteFriendsToNavigationMenu()
//	{
//		panelInviteFriendsMenu.animation[panelInviteFriendsMenuSlideOut.name].speed = 1.0f; 
//		panelNavigationMenu.animation[panelNavigationMenuSlideIn.name].speed = 1.0f; 
//		panelInviteFriendsMenu.animation.Play(panelInviteFriendsMenuSlideOut.name); 
//		panelNavigationMenu.animation.Play(panelNavigationMenuSlideIn.name);
//	}
//
//	public void PanelNavigationToInviteFriendsMenu()
//	{
//		panelInviteFriendsMenu.animation[panelInviteFriendsMenuSlideOut.name].speed = -1.0f; 
//		panelInviteFriendsMenu.animation[panelInviteFriendsMenuSlideOut.name].time = panelInviteFriendsMenu.animation[panelInviteFriendsMenuSlideOut.name].length; 
//		panelNavigationMenu.animation[panelNavigationMenuSlideIn.name].speed = -1.0f; 
//		panelNavigationMenu.animation[panelNavigationMenuSlideIn.name].time = panelNavigationMenu.animation[panelNavigationMenuSlideIn.name].length;
//		panelInviteFriendsMenu.animation.Play(panelInviteFriendsMenuSlideOut.name); 
//		panelNavigationMenu.animation.Play(panelNavigationMenuSlideIn.name);
//	}
//
//	public void PanelScoreMenuToNavMenu()
//	{
//		panelScoreMenu.animation[panelScoreMenuSlideOut.name].speed = 1.0f;  
//		panelScoreMenu.animation.Play(panelScoreMenuSlideOut.name); 
//
//		panelNavigationMenu.animation[panelNavigationMenuSlideIn.name].speed = 1.0f;  
//		panelNavigationMenu.animation.Play(panelNavigationMenuSlideIn.name);
//	}

//	public void PanelNavMenuToScoreMenu()
//	{ 
//		panelNavigationMenu.animation[panelNavigationMenuSlideIn.name].speed = -1.0f; 
//		panelNavigationMenu.animation[panelNavigationMenuSlideIn.name].time = panelNavigationMenu.animation[panelNavigationMenuSlideIn.name].length; 
//		panelNavigationMenu.animation.Play(panelNavigationMenuSlideIn.name);
//
//		panelScoreMenu.animation[panelScoreMenuSlideOut.name].speed = -1.0f; 
//		panelScoreMenu.animation[panelScoreMenuSlideOut.name].time = panelScoreMenu.animation[panelScoreMenuSlideOut.name].length; 
//		panelScoreMenu.animation.Play(panelScoreMenuSlideOut.name); 
//	}
}
