using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UnityGUIGamePlayManager : MonoBehaviour {

	private GameObject panelPausedGroup;
	private GameObject panelMissionResultsGroup;
	private GameObject panelConfirmMessage; 
	private GameObject imageCurtainExit;
	private GameObject panelPauseButtons;
	private GameObject panelMissionResultsContents; 
	private Animator animatorImageCurtainExit; 

	private bool fromPausePanel = true;
	private bool playerWantsToRestart = true;
	private bool playerWantsToPlayNextMission = false;

	private string stringAdScene = "AdScene"; 
	private string stringMainMenu = "MainMenu";

//	private Text textConfirmMessage; 
//	private string stringConfirmMessageRestart = "ARE YOU SURE YOU WANT TO RESTART THE GAME?"; 
//	private string stringConfirmMessageGoToMainMenu = "ARE YOU SURE YOU WANT TO GO TO MAIN MENU?";
//	private string stringConfirmMessagePlayNextMission = "ARE YOU SURE YOU WANT TO PLAY THE NEXT MISSION?"; 

	private GameObject textConfirmRestart; 
	private GameObject textConfirmMainMenu;
	private GameObject textConfirmNextMission;

	private Text textTimeRemainingValue; 
	private Text textEnemiesDestroyedValue; 
	private Text textBonusScoreValue; 
	private Text textMissionScoreValue;
	private Text textTotalScoreValue; 

	private Animator animatorPanelMissionResultsGroup; 
	private Image imageMissionResultsTopBG;
	private GameObject textMissionCompleted; 
	private GameObject textMissionFailed;

	private Button buttonNextMission; 
	private Image imageButtonNextMission; 
	private Text textButtonNextMission; 

	// Use this for initialization
	void Start () {
		Invoke ("FindUIElements",3f);  
	}

	void FindUIElements()
	{
		panelPausedGroup = GameObject.Find ("PanelPausedGroup"); 
		panelMissionResultsGroup = GameObject.Find ("PanelMissionResultsGroup");
		animatorPanelMissionResultsGroup = panelMissionResultsGroup.GetComponent<Animator>(); 
		panelConfirmMessage = GameObject.Find ("PanelConfirmMessage");
		imageCurtainExit = GameObject.Find ("ImageCurtainExit");
		animatorImageCurtainExit = imageCurtainExit.GetComponent<Animator>(); 
		panelPauseButtons = GameObject.Find ("PanelPauseButtons"); 
		panelMissionResultsContents = GameObject.Find ("PanelMissionResultsContents");
		textConfirmRestart = GameObject.Find ("TextConfirmRestart"); 
		textConfirmMainMenu = GameObject.Find ("TextConfirmMainMenu");
		textConfirmNextMission = GameObject.Find ("TextConfirmNextMission");

		textTimeRemainingValue = GameObject.Find ("TextTimeRemainingValue").GetComponent<Text>();
		textEnemiesDestroyedValue = GameObject.Find ("TextEnemiesDestroyedValue").GetComponent<Text>();
		textBonusScoreValue = GameObject.Find ("TextBonusScoreValue").GetComponent<Text>();
		textMissionScoreValue = GameObject.Find ("TextMissionScoreValue").GetComponent<Text>();
		textTotalScoreValue = GameObject.Find ("TextTotalScoreValue").GetComponent<Text>();

		imageMissionResultsTopBG = GameObject.Find ("ImageMissionResultsTopBG").GetComponent<Image>();
		textMissionCompleted = GameObject.Find ("TextMissionCompleted");
		textMissionFailed = GameObject.Find ("TextMissionFailed");

		buttonNextMission = GameObject.Find ("ButtonNextMission").GetComponent<Button>();
		imageButtonNextMission = buttonNextMission.gameObject.GetComponent<Image>(); 
		textButtonNextMission = GameObject.Find ("TextButtonNextMission").GetComponent<Text>();

		Invoke ("HideUIElements",1f); 
	}

	void HideUIElements()
	{
		panelPausedGroup.SetActive (false);
		panelMissionResultsGroup.SetActive (false);
		panelConfirmMessage.SetActive (false);
		imageCurtainExit.SetActive (false);
		animatorImageCurtainExit.enabled = true; 
		textMissionFailed.SetActive (false); 
		textConfirmMainMenu.SetActive (false);
		textConfirmNextMission.SetActive (false); 
	}

	public void ShowPanelPausedGroup()
	{
		if (panelPausedGroup) {
			panelPausedGroup.SetActive(true); 	
		} else {
			panelPausedGroup = GameObject.Find ("PanelPausedGroup");	
			panelPausedGroup.SetActive(true);
		}
	}

	public void HidePanelPausedGroup()
	{
		if (panelPausedGroup) {
			panelPausedGroup.SetActive(false); 	
		} else {
			panelPausedGroup = GameObject.Find ("PanelPausedGroup");	
			panelPausedGroup.SetActive(false);
		}
	}

	public void ShowPanelConfirmMessage()
	{
		panelConfirmMessage.SetActive (true); 
	}

	public void HidePanelConfirmMessage()
	{
		panelConfirmMessage.SetActive (false); 
	}

	public void ShowPanelPauseButtons()
	{
		panelPauseButtons.SetActive (true); 
	}
	
	public void HidePanelPauseButtons()
	{
		panelPauseButtons.SetActive (false); 
	}

	public void ConfirmMessageCalledFromPausePanel()
	{
		fromPausePanel = true; 
	}

	public void ConfirmMessageCalledFromMissionResultsPanel()
	{
		fromPausePanel = false; 
	}

	public void SetPlayerWantsToRestart()
	{
		//textConfirmMessage.text = stringConfirmMessageRestart; 
		playerWantsToRestart = true; 
		playerWantsToPlayNextMission = false; 

		textConfirmRestart.SetActive (true); 
		textConfirmMainMenu.SetActive (false);
		textConfirmNextMission.SetActive (false);
	}

	public void SetPlayerWantsToExit()
	{
		//textConfirmMessage.text = stringConfirmMessageGoToMainMenu;
		playerWantsToRestart = false; 
		playerWantsToPlayNextMission = false; 
	
		textConfirmRestart.SetActive (false); 
		textConfirmMainMenu.SetActive (true);
		textConfirmNextMission.SetActive (false);
	}

	public void SetPlayerWantsToPlayNextMission()
	{
		//textConfirmMessage.text = stringConfirmMessagePlayNextMission;
		playerWantsToRestart = false; 
		playerWantsToPlayNextMission = true; 
	
		textConfirmRestart.SetActive (false); 
		textConfirmMainMenu.SetActive (false);
		textConfirmNextMission.SetActive (true);
	}

	public void ButtonNoPressed()
	{
		HidePanelConfirmMessage (); 

		if (fromPausePanel) {
			ShowPanelPauseButtons(); 
		} else {
			ShowPanelMissionResultsContents(); 
		}
	}

	public void ButtonYesPressed()
	{
		ShowImageCurtainExit();

		Invoke ("DoNavigationProcess",1.5f); 
	}

	void DoNavigationProcess()
	{
		if (playerWantsToRestart) {
			Application.LoadLevel(stringAdScene); 
		} 
		else if (playerWantsToPlayNextMission) {
			if (SceneIndexManager.sceneIndex != 8) {
				SceneIndexManager.sceneIndex++; 
				Application.LoadLevel(stringAdScene); 
				//Application.LoadLevel(SceneIndexManager.sceneIndex);	
			}
		}
		else {
			Application.LoadLevel(stringMainMenu);
		}
	}

	public void ShowPanelMissionResultsGroup()
	{
		panelMissionResultsGroup.SetActive (true); 
	}

	public void HidePanelMissionResultsGroup()
	{
		panelMissionResultsGroup.SetActive (false); 
	}

	public void ShowPanelMissionResultsContents()
	{
		panelMissionResultsContents.SetActive (true); 
	}

	public void HidePanelMissionResultsContents()
	{
		panelMissionResultsContents.SetActive (false); 
	}

	public void ShowImageCurtainExit()
	{
		imageCurtainExit.SetActive (true); 
		animatorImageCurtainExit.enabled = true; 
	}

	public void SetTextTimeRemainingValue(string newValue)
	{
		textTimeRemainingValue.text = newValue; 	
	}

	public void SetTextEnemiesDestroyedValue(string newValue)
	{
		textEnemiesDestroyedValue.text = newValue; 	
	}

	public void SetTextBonusScoreValue(string newValue)
	{
		textBonusScoreValue.text = newValue; 	
	}

	public void SetTextMissionScoreValue(string newValue)
	{
		textMissionScoreValue.text = newValue; 	
	}

	public void SetTextTotalScoreValue(string newValue)
	{
		textTotalScoreValue.text = newValue; 	
	}

	public void InvokeTriggerShowPanelMissionResultsGroup(float delay)
	{
		Invoke ("TriggerShowPanelMissionResultsGroup", delay); 
	}

	void TriggerShowPanelMissionResultsGroup()
	{
		animatorPanelMissionResultsGroup.SetTrigger ("TriggerShow");
		Invoke ("InvokePauseTheGame",1.4f); 
	}

	void InvokePauseTheGame()
	{
		GameManagerScript.gameManagerStatic.SendMessage("PauseTheGame",SendMessageOptions.DontRequireReceiver); // from GameManagerScript.cs 
	}

	public void SetImageMissionResultsTopBGColor(Color newColor)
	{
		imageMissionResultsTopBG.color = newColor; 
	}

//	public void SetTextMissionResultTop(string newMessage)
//	{
//		textMissionCompleted.text = newMessage; 
//	}

	public void ShowTextMissionCompleted()
	{
		textMissionCompleted.SetActive (true); 
		textMissionFailed.SetActive (false);
	}

	public void ShowTextMissionFailed()
	{
		textMissionCompleted.SetActive (false); 
		textMissionFailed.SetActive (true);
	}

	public void EnableButtonNextMission()
	{
		buttonNextMission.interactable = true;
		imageButtonNextMission.color = new Color (0,0,0,255f/255f);
		textButtonNextMission.color = new Color (1,1,1,1); 
	}
}
