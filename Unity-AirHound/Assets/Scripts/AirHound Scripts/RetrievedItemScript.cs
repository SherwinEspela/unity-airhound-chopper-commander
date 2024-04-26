using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic; 

public class RetrievedItemScript : MonoBehaviour {

	// private variables
	private int retrievedItems;
	private string loadingScene = "LoadingScene";
	private GameObject panelNukeIndicator;
	private List<Image> listOfImageNukeIndicators = new List<Image>();

	// public variables
	public GameManagerScript gameManagerScript; 
	public GameObject gameManager; 
	public int itemsToRetrieve;
	public AudioClip victoryVoice; 
	public GameObject imageNukeIndicatorPrefab; 
	//public GameObject[] cratesInTheScene;

	// Use this for initialization
	void Start () {
		Invoke ("FindUIElements",1f); 
		gameManagerScript = gameObject.GetComponent<GameManagerScript>(); 
	}

	void FindUIElements()
	{
		retrievedItems = 0; 
		panelNukeIndicator = GameObject.Find ("PanelNukeIndicator"); 
		RectTransform rtScriptTemp = imageNukeIndicatorPrefab.GetComponent<RectTransform>();
		float indicatorWidth = rtScriptTemp.rect.width;
		float gap = indicatorWidth / 1.5f; 
		float positionX = 0; 
		
		//cratesInTheScene = GameObject.FindGameObjectsWithTag ("NukeCrateTag"); 
		//itemsToRetrieve = cratesInTheScene.Length; 

		for (int i = 0; i < itemsToRetrieve ; i++) {
			GameObject inipClone = Instantiate(imageNukeIndicatorPrefab) as GameObject;
			inipClone.transform.SetParent(panelNukeIndicator.transform); 
			RectTransform rtScript = inipClone.GetComponent<RectTransform>();
			rtScript.anchoredPosition = new Vector2(positionX,0); 
			positionX += indicatorWidth + gap;
			rtScript.localScale = new Vector3(1.3f,1.3f,1f); 
			
			listOfImageNukeIndicators.Add(inipClone.GetComponent<Image>()); 
		}
		
		foreach (var item in listOfImageNukeIndicators) {
			item.color = new Color(70f/255,70f/255,70f/255,185f/255); // 0,154,27,185 = green 	
		}
	}

	public void DecreaseItemsRetrived()
	{
		itemsToRetrieve--;
		retrievedItems++;

		for (int i = 0; i < listOfImageNukeIndicators.Count ; i++) {
			listOfImageNukeIndicators[i].color = new Color(0,154f/255,27f/255,185f/255); 	
			if (i + 1 == retrievedItems) {
				break; 
			}
		}

		gameManager.SendMessage("SetNukesLeft",itemsToRetrieve,SendMessageOptions.DontRequireReceiver);
		this.gameObject.BroadcastMessage("LoadTheNukeCrates",SendMessageOptions.DontRequireReceiver); 
		if (itemsToRetrieve <= 0) {
			GameManagerScript.gameIsOver = true; 
			GameManagerScript.resultInThisMission = GameManagerScript.MissionResult.MissionCompleted; 
			gameManager.SendMessage("StopTheTimer",SendMessageOptions.DontRequireReceiver);
			gameManager.SendMessage("InvokeRunScoreManagerScript",true,SendMessageOptions.DontRequireReceiver);
			this.gameObject.BroadcastMessage("InvokeHideGamepadControllers",SendMessageOptions.DontRequireReceiver); // from GameManagerScript.cs
			GameManagerScript.gameManagerStatic.SendMessage("InvokeHidePanelTopHud",SendMessageOptions.DontRequireReceiver); // from ControlsVisibilityScript.cs
			gameManager.SendMessage("SpawningDeactivated",SendMessageOptions.DontRequireReceiver); // from GameManagerScript 

			UnlockMission();
			Invoke("playVictoryVoice",2f); 

			GameManagerScript.gameManagerStatic.SendMessage("DisablePanelEventMessage",SendMessageOptions.DontRequireReceiver); // from EventMessageScript.cs
			GameManagerScript.gameManagerStatic.SendMessage("EnableButtonNextMission",SendMessageOptions.DontRequireReceiver); // from UnityGUIGamePlayManager.cs
			GameManagerScript.gameManagerStatic.SendMessage("ShowTextMissionCompleted",SendMessageOptions.DontRequireReceiver); // from UnityGUIGamePlayManager.cs
			//GameManagerScript.gameManagerStatic.SendMessage("SetTextMissionResultTop","MISSION-" + SceneIndexManager.sceneIndex + " COMPLETED",SendMessageOptions.DontRequireReceiver); // from UnityGUIGamePlayManager.cs
			GameManagerScript.gameManagerStatic.SendMessage("ShowPanelMissionResultsGroup",SendMessageOptions.DontRequireReceiver); // from UnityGUIGamePlayManager.cs
			GameManagerScript.gameManagerStatic.SendMessage("InvokeTriggerShowPanelMissionResultsGroup",3f,SendMessageOptions.DontRequireReceiver); // from UnityGUIGamePlayManager.cs
		}
	}

	public void IncreaseItemsRetrieved()
	{
		itemsToRetrieve++;
		this.gameObject.BroadcastMessage("LoadTheNukeCrates",SendMessageOptions.DontRequireReceiver);
	}

	void UnlockMission()
	{
		if (SceneIndexManager.sceneIndex == 1) {
			MissionLockManager.mission2Locked = false;
			PlayerPrefs.SetInt("Mission2Unlocked",1);
		} 
		else if (SceneIndexManager.sceneIndex == 2) {
			MissionLockManager.mission3Locked = false;
			PlayerPrefs.SetInt("Mission3Unlocked",1);
		}
		else if (SceneIndexManager.sceneIndex == 3) {
			MissionLockManager.mission4Locked = false;
			PlayerPrefs.SetInt("Mission4Unlocked",1);
		}
		else if (SceneIndexManager.sceneIndex == 4) {
			MissionLockManager.mission5Locked = false;
			PlayerPrefs.SetInt("Mission5Unlocked",1);

			// Game Center Achievement
			PlayerPrefs.SetInt("GameCenterEliteCommanderAchievement",1);
		}
		else if (SceneIndexManager.sceneIndex == 5) {
			MissionLockManager.mission6Locked = false;
			PlayerPrefs.SetInt("Mission6Unlocked",1);
		}
		else if (SceneIndexManager.sceneIndex == 6) {
			MissionLockManager.mission7Locked = false;
			PlayerPrefs.SetInt("Mission7Unlocked",1);
		}
		else if (SceneIndexManager.sceneIndex == 7) {
			MissionLockManager.mission8Locked = false;
			PlayerPrefs.SetInt("Mission8Unlocked",1);
		}
		else if (SceneIndexManager.sceneIndex == 8) {
			MissionLockManager.missionSurvivalLocked = false;
			PlayerPrefs.SetInt("MissionSurvivalUnlocked",1);

			// Game Center Achievement
			PlayerPrefs.SetInt("GameCenterSupremeCommanderAchievement",1);
		}
	}

	void playVictoryVoice()
	{
		if (GetComponent<AudioSource>()) {
			GetComponent<AudioSource>().PlayOneShot(victoryVoice); 	
		}
	}
}
