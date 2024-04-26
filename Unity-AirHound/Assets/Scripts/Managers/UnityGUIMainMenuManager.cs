using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UnityGUIMainMenuManager : MonoBehaviour {

	public Animator animatorPanelMainMenu; 
	public Animator animatorPanelPlay;
	public Animator animatorPanelLeaderboards;
	public Animator animatorSetings; 
	public Animator animatorImageBGBlurred; 

	public enum SelectedButtonEnum 
	{
		ePlaySelected,
		eLeaderboardsSelected,
		eSettingsSelected
	}

	private SelectedButtonEnum selectedButton = SelectedButtonEnum.ePlaySelected; 

	public Animator[] animatorPanelMissions; 	
	private int currentSelectedPanelMissionsIndex = 0; 

	public Button buttonLaunchMissionScript; 
	public Text buttonTextLaunchMissionScript; 
	public Image buttonImageLaunchMissionScript; 

	private Color colorImageLaunchMission_Disabled = new Color(0/255f,0/255f,0/255f,80/255f); 
	private Color colorImageLaunchMission_Enabled = new Color(0/255f,0/255f,0/255f,255/255f);
	private Color colorTextLaunchMission_Disabled = new Color(255/255f,255/255f,255/255f,80/255f); 
	private Color colorTextLaunchMission_Enabled = new Color(255/255f,255/255f,255/255f,255f/255f);
	private Color colorImageMission_Disabled = new Color(255/255f,255/255f,255/255f,80/255f); 
	private Color colorImageMission_Enabled = new Color(255/255f,255/255f,255/255f,255/255f);
	private Color colorButtonNormalImage_Selected = new Color(0,0,0,180f/255f); 
	private Color colorButtonNormalImage_Unselected = new Color(0,0,0,100f/255f);

	public Image imageMission2; 
	public Image imageMission3;
	public Image imageMission4;
	public Image imageMission5;
	public Image imageMission6;
	public Image imageMission7;
	public Image imageMission8;

	public GameObject imageLockIconMission2; 
	public GameObject imageLockIconMission3;
	public GameObject imageLockIconMission4;
	public GameObject imageLockIconMission5;
	public GameObject imageLockIconMission6;
	public GameObject imageLockIconMission7;
	public GameObject imageLockIconMission8;

	public CanvasGroup canvasGroupPlayButtons; 

	public GameObject panelSettingsMenu; 
	public GameObject panelManualMenu;
	public GameObject panelAboutMenu;
	public GameObject panelSupportMenu;
	private List<GameObject> listPanelSettings; 

	public Image buttonSettings;
	public Image buttonManual;
	public Image buttonSupport;
	public Image buttonAbout;
	private List<Image> listButtonSettings; 

	public Animator animatorImageCurtain;  

	private string adSceneString = "AdScene"; 

	public Button buttonPlay; 
	public Button buttonLeaderboard; 
	public Button buttonOptions; 
	public Button buttonMainMenu;
	public Button buttonFacebook; 
	public Button buttonTwitter; 

//	public Toggle toggleEnglish; 
//	public Toggle toggleFrench;
//	public Toggle toggleChinese;
//	public Toggle toggleSpanish;
//	public Toggle toggleGerman;
//	public Toggle toggleKorean;
//	public Toggle toggleRussian;
//	public Toggle toggleItalian;
//
//	private List<Toggle> listTogglesLanguage = new List<Toggle>(); 

	//public Toggle[] arrayToggleLanguage; 

	public GameObject textSettings; 
	public GameObject textManual; 
	public GameObject textSupport; 
	public GameObject textAbout; 

	// Use this for initialization
	void Start () {
		animatorPanelMissions[0].SetTrigger ("TriggerStartCenter"); 
		animatorPanelMainMenu.SetTrigger ("TriggerAtCenter");
		listPanelSettings = new List<GameObject>();
		listPanelSettings.Add (panelSettingsMenu); 
		listPanelSettings.Add (panelManualMenu);
		listPanelSettings.Add (panelAboutMenu);
		listPanelSettings.Add (panelSupportMenu);
		listButtonSettings = new List<Image>();
		listButtonSettings.Add (buttonSettings); 
		listButtonSettings.Add (buttonManual);
		listButtonSettings.Add (buttonSupport);
		listButtonSettings.Add (buttonAbout);
	
//		listTogglesLanguage.Add (toggleEnglish); 
//		listTogglesLanguage.Add (toggleFrench);
//		listTogglesLanguage.Add (toggleChinese);
//		listTogglesLanguage.Add (toggleSpanish);
//		listTogglesLanguage.Add (toggleGerman);
//		listTogglesLanguage.Add (toggleKorean);
//		listTogglesLanguage.Add (toggleRussian);
//		listTogglesLanguage.Add (toggleItalian);

		//toggleEnglish.interactable = false; 
	}

	public void TriggerGenericPanelMenuShow(Animator panelAnimator)
	{
		panelAnimator.SetTrigger ("TriggerShown"); 
	}

	public void TriggerGenericPanelMenuHide(Animator panelAnimator)
	{
		panelAnimator.SetTrigger ("TriggerHidden"); 
	}

	public void TriggerGenericPanelCenterToRight(Animator panelAnimator)
	{
		panelAnimator.SetTrigger ("TriggerAtRight"); 
	}

	public void TriggerGenericPanelCenterToLeft(Animator panelAnimator)
	{
		panelAnimator.SetTrigger ("TriggerAtLeft"); 
	}

	public void TriggerGenericPanelRightToCenter(Animator panelAnimator)
	{
		panelAnimator.SetTrigger ("TriggerRightToCenter"); 
	}

	public void TriggerGenericPanelLeftToCenter(Animator panelAnimator)
	{
		panelAnimator.SetTrigger ("TriggerLeftToCenter"); 
	}

	public void SelectedButtonIsPlay()
	{
		selectedButton = SelectedButtonEnum.ePlaySelected; 
		TriggerImageBGBlurredShow (); 
	}

	public void SelectedButtonIsLeaderboard()
	{
		selectedButton = SelectedButtonEnum.eLeaderboardsSelected; 
		TriggerImageBGBlurredShow ();
	}

	public void SelectedButtonIsSettings()
	{
		selectedButton = SelectedButtonEnum.eSettingsSelected; 
		TriggerImageBGBlurredShow ();
	}

	public void MoveSelectedPanelToRight()
	{
		TriggerImageBGBlurredHide (); 
		if (selectedButton == SelectedButtonEnum.ePlaySelected) {
			animatorPanelPlay.SetTrigger("TriggerAtLeft"); 	
		}
		else if (selectedButton == SelectedButtonEnum.eLeaderboardsSelected) {
			animatorPanelLeaderboards.SetTrigger("TriggerAtLeft"); 	
		}
		else if (selectedButton == SelectedButtonEnum.eSettingsSelected) {
			animatorSetings.SetTrigger("TriggerAtLeft"); 	
		}
	}

	public void TriggerImageBGBlurredShow()
	{
		animatorImageBGBlurred.SetTrigger ("TriggerShow"); 
	}

	public void TriggerImageBGBlurredHide()
	{
		animatorImageBGBlurred.SetTrigger ("TriggerHide"); 
	}

	public void MoveNextPanelMission()
	{
		if (currentSelectedPanelMissionsIndex != animatorPanelMissions.Length - 1) {
			animatorPanelMissions [currentSelectedPanelMissionsIndex].SetTrigger ("TriggerCenterToLeft"); 
			animatorPanelMissions [currentSelectedPanelMissionsIndex + 1].SetTrigger ("TriggerRightToCenter");
		}

		currentSelectedPanelMissionsIndex++;
		if (currentSelectedPanelMissionsIndex > 7) {
			currentSelectedPanelMissionsIndex = 7; 	
		}

		if (SceneIndexManager.sceneIndex != 8) {
			SceneIndexManager.sceneIndex++;
			if (SceneIndexManager.sceneIndex > 8) {
				SceneIndexManager.sceneIndex = 8; 
			}
		}

		CheckIfMissionIsLocked ();
		TemporaryDisablePanelPlayButtons (); 
	}

	public void MovePreviousPanelMission()
	{
		if (currentSelectedPanelMissionsIndex != 0) {
			animatorPanelMissions [currentSelectedPanelMissionsIndex].SetTrigger ("TriggerCenterToRight"); 
			animatorPanelMissions [currentSelectedPanelMissionsIndex - 1].SetTrigger ("TriggerLeftToCenter");
		}
		
		currentSelectedPanelMissionsIndex--;
		if (currentSelectedPanelMissionsIndex < 0) {
			currentSelectedPanelMissionsIndex = 0; 	
		}

		if (SceneIndexManager.sceneIndex != 1) {
			SceneIndexManager.sceneIndex--;
			if (SceneIndexManager.sceneIndex < 1) {
				SceneIndexManager.sceneIndex = 1; 
			}
		}

		CheckIfMissionIsLocked (); 
		TemporaryDisablePanelPlayButtons ();
	}

	void TemporaryDisablePanelPlayButtons()
	{
		canvasGroupPlayButtons.interactable = false; 
		StartCoroutine (EnablePanelPlayButtons()); 
	}

	IEnumerator EnablePanelPlayButtons()
	{
		yield return new WaitForSeconds (.4f); 
		canvasGroupPlayButtons.interactable = true; 
	}

	void ButtonLaunchMission_EnabledState()
	{
		buttonLaunchMissionScript.interactable = true;  
		buttonTextLaunchMissionScript.color = colorTextLaunchMission_Enabled;
		buttonImageLaunchMissionScript.color = colorImageLaunchMission_Enabled;
	}

	void ButtonLaunchMission_DisabledState()
	{
		buttonLaunchMissionScript.interactable = false;  
		buttonTextLaunchMissionScript.color = colorTextLaunchMission_Disabled;
		buttonImageLaunchMissionScript.color = colorImageLaunchMission_Disabled;
	}

	void CheckIfMissionIsLocked()
	{
		if (SceneIndexManager.sceneIndex == 1){
			MissionLockManager.missionIsUnlocked = true; 
			ButtonLaunchMission_EnabledState(); 
		} 
		else if (SceneIndexManager.sceneIndex == 2) {
			if (MissionLockManager.mission2Locked == true) {
				MissionLockManager.missionIsUnlocked = false;
				ButtonLaunchMission_DisabledState();
				imageLockIconMission2.SetActive(true); 
				imageMission2.color = colorImageMission_Disabled; 
			}
			else {
				MissionLockManager.missionIsUnlocked = true;
				ButtonLaunchMission_EnabledState(); 
				imageLockIconMission2.SetActive(false); 
				imageMission2.color = colorImageMission_Enabled;
			}
		}
		else if (SceneIndexManager.sceneIndex == 3) {
			if (MissionLockManager.mission3Locked == true) {
				MissionLockManager.missionIsUnlocked = false;
				ButtonLaunchMission_DisabledState();
				imageLockIconMission3.SetActive(true); 
				imageMission3.color = colorImageMission_Disabled; 
			}
			else {
				MissionLockManager.missionIsUnlocked = true;
				ButtonLaunchMission_EnabledState();
				imageLockIconMission3.SetActive(false); 
				imageMission3.color = colorImageMission_Enabled;
			}
		}
		else if (SceneIndexManager.sceneIndex == 4) {
			if (MissionLockManager.mission4Locked == true) {
				MissionLockManager.missionIsUnlocked = false;
				ButtonLaunchMission_DisabledState();
				imageLockIconMission4.SetActive(true); 
				imageMission4.color = colorImageMission_Disabled;
			}
			else { 
				MissionLockManager.missionIsUnlocked = true;
				ButtonLaunchMission_EnabledState();
				imageLockIconMission4.SetActive(false); 
				imageMission4.color = colorImageMission_Enabled;
			}
		}
		else if (SceneIndexManager.sceneIndex == 5) {
			if (MissionLockManager.mission5Locked == true) {
				MissionLockManager.missionIsUnlocked = false;
				ButtonLaunchMission_DisabledState();
				imageLockIconMission5.SetActive(true); 
				imageMission5.color = colorImageMission_Disabled;
			}
			else {
				MissionLockManager.missionIsUnlocked = true;
				ButtonLaunchMission_EnabledState();
				imageLockIconMission5.SetActive(false); 
				imageMission5.color = colorImageMission_Enabled;
			}
		}
		else if (SceneIndexManager.sceneIndex == 6) {
			if (MissionLockManager.mission6Locked == true) {
				MissionLockManager.missionIsUnlocked = false;
				ButtonLaunchMission_DisabledState();
				imageLockIconMission6.SetActive(true); 
				imageMission6.color = colorImageMission_Disabled;
			}
			else {
				MissionLockManager.missionIsUnlocked = true;
				ButtonLaunchMission_EnabledState();
				imageLockIconMission6.SetActive(false); 
				imageMission6.color = colorImageMission_Enabled;
			}
		}
		else if (SceneIndexManager.sceneIndex == 7) {
			if (MissionLockManager.mission7Locked == true) {
				MissionLockManager.missionIsUnlocked = false;
				ButtonLaunchMission_DisabledState();
				imageLockIconMission7.SetActive(true); 
				imageMission7.color = colorImageMission_Disabled;
			}
			else {
				MissionLockManager.missionIsUnlocked = true;
				ButtonLaunchMission_EnabledState();
				imageLockIconMission7.SetActive(false); 
				imageMission7.color = colorImageMission_Enabled;
			} 
		}
		else if (SceneIndexManager.sceneIndex == 8) {
			if (MissionLockManager.mission8Locked == true) {
				MissionLockManager.missionIsUnlocked = false;
				ButtonLaunchMission_DisabledState();
				imageLockIconMission8.SetActive(true); 
				imageMission8.color = colorImageMission_Disabled;
			}
			else {
				MissionLockManager.missionIsUnlocked = true;
				ButtonLaunchMission_EnabledState();
				imageLockIconMission8.SetActive(false); 
				imageMission8.color = colorImageMission_Enabled;
			} 
		}
	}

	void DisableAllSettingsPanelAndButtonsNormalImage()
	{
		foreach (var item in listPanelSettings) {
			item.SetActive(false); 	
		}
		foreach (var item in listButtonSettings) {
			item.color = colorButtonNormalImage_Unselected;  	
		}
	}

	public void SelectSettingsMenu()
	{
		DisableAllSettingsPanelAndButtonsNormalImage ();
		panelSettingsMenu.SetActive (true);
		buttonSettings.color = colorButtonNormalImage_Selected; 

		textSettings.SetActive(true);
		textManual.SetActive(false);
		textSupport.SetActive(false);
		textAbout.SetActive(false); 
	}

	public void SelectManualMenu()
	{
		DisableAllSettingsPanelAndButtonsNormalImage ();
		panelManualMenu.SetActive (true); 
		buttonManual.color = colorButtonNormalImage_Selected;

		textSettings.SetActive(false);
		textManual.SetActive(true);
		textSupport.SetActive(false);
		textAbout.SetActive(false);
	}

	public void SelectSupportMenu()
	{
		DisableAllSettingsPanelAndButtonsNormalImage ();
		panelSupportMenu.SetActive (true); 
		buttonSupport.color = colorButtonNormalImage_Selected;

		textSettings.SetActive(false);
		textManual.SetActive(false);
		textSupport.SetActive(true);
		textAbout.SetActive(false);
	}

	public void SelectAboutMenu()
	{
		DisableAllSettingsPanelAndButtonsNormalImage ();
		panelAboutMenu.SetActive (true); 
		buttonAbout.color = colorButtonNormalImage_Selected;

		textSettings.SetActive(false);
		textManual.SetActive(false);
		textSupport.SetActive(false);
		textAbout.SetActive(true);
	}

	public void TriggerShowImageCurtain()
	{
		animatorImageCurtain.SetTrigger ("TriggerShown"); 
	}

	public void TriggerHideImageCurtain()
	{
		animatorImageCurtain.SetTrigger ("TriggerHidden"); 
	}

	public void GoToAdScene()
	{
		StartCoroutine (LoadAdScene()); 
	}

	IEnumerator LoadAdScene()
	{
		yield return new WaitForSeconds (1.25f); 

		Application.LoadLevel (adSceneString);
	}

	public void EnableMainMenuButtons()
	{
		buttonPlay.interactable = true; 
		buttonLeaderboard.interactable = true;
		buttonOptions.interactable = true;
		buttonMainMenu.interactable = false; 

		buttonFacebook.interactable = true; 
		buttonTwitter.interactable = true;
	}

	public void DisableMainMenuButtons()
	{
		buttonPlay.interactable = false; 
		buttonLeaderboard.interactable = false;
		buttonOptions.interactable = false;
		buttonMainMenu.interactable = true;

		buttonFacebook.interactable = false; 
		buttonTwitter.interactable = false;
	}	
}
