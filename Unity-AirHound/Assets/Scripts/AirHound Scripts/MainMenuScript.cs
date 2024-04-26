using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	// Missions String
	private string loadingScene = "LoadingScene";
	private string videoAdScene = "VideoAdScene";
	private string adScene = "AdScene"; 
	
	public AnimationClip soundtrack;

	private bool playButtonTapped = false;
	private bool optionButtonTapped = false;
	private bool extraButtonTapped = false;
	private bool gameCenterButtonTapped = false; 
	private bool mainButtonTapped = false; 

	// BUTTONS


	// BUTTON SCRIPTS


	// MENU FLARES
	public GameObject[] menuFlares;

	// VERSION 1.3 MENU

	// Menu Panels
	
	// set the label version string value


	// social media buttons

	//public GameObject airhoundFacebookManager; 

	public GameObject coboltFlareTitle;
	public AnimationClip coboltFlareTitleSlideOut; 
	public AnimationClip coboltFlareTitleSlideIn; 

	public GameObject iceWorldFlare; 
	public AnimationClip iceWorldFlareSlideIn; 
	public AnimationClip iceWorldFlareSlideOut;
	public Animator iceWorldFlareAnimator; 

	public Animator coboltFlareCockpit; 
	

	void Start()
	{
		if (Time.timeScale == 0.0f) {
			Time.timeScale = 1.0f; // to ensure that time is not paused 	
		}


		Invoke("ShowMenuFlares",0.3f);

		FindFacebookManager();
	
		//ConfigureGameCenterLabels ();
	}

	private void FindFacebookManager()
	{
//		GameObject facebookManager = GameObject.Find("AirhoundFacebookManager(Clone)");
//		if (facebookManager == null) {
//			// create clone
//			facebookManager = Instantiate(airhoundFacebookManager) as GameObject; 
//		}
	}

	public void PrepareToPlayAdcolonyVideo()
	{
		DisablePlayMenuButtons(); 
		Invoke("HideMenuFlares",2f);
	}

	public void InvokeGoToLoadingScreen()
	{
		// MissionLockManager.missionIsUnlocked is set in MissionNameLabel Class
		if (MissionLockManager.missionIsUnlocked == true) {
			Invoke("GoToLoadingScreen",4);
			Invoke("HideMenuFlares",2f); 
			DisablePlayMenuButtons(); 
			GetComponent<Animation>().Play(soundtrack.name);
		}
	}
	
	void GoToLoadingScreen()
	{
		Application.LoadLevel(loadingScene);
	}

	public void InvokeGoToVideoAdScene()
	{
		// MissionLockManager.missionIsUnlocked is set in MissionNameLabel Class
		if (MissionLockManager.missionIsUnlocked == true) {
			Invoke("GoToVideoAdScene",4);
			Invoke("HideMenuFlares",2f); 
			DisablePlayMenuButtons(); 
			GetComponent<Animation>().Play(soundtrack.name);
		}
	}

	void GoToVideoAdScene()
	{
		Application.LoadLevel(videoAdScene);
	}

	public void CurtainFadeOut()
	{
		//TweenAlpha.Begin(curtain,2,0);
	}

	public void FadeToBlack()
	{
		HideIceWorldFlareSubMenu(); 
		//TweenAlpha.Begin(curtain,2,1);
		Invoke("HidePanelAllMenus",2f); 
		Invoke("GoToAdScene",2f);
	}

	void GoToAdScene()
	{
		Application.LoadLevel (adScene); 
	}

	public void PlaySelected()
	{
		playButtonTapped = true;
		optionButtonTapped = false;
		extraButtonTapped = false;
		gameCenterButtonTapped = false; 
		mainButtonTapped = false; 
		DisableMainMenuButtons();

//		panelPlayMenu.SetActive(true);
//		panelExtraMenu.SetActive(false);
//		panelGameCenterMenu.SetActive(false);
//		panelOptionsMenu.SetActive(false); 

		// Extra Missions
		//ExtraManager.isExtraMission = false;
		SurvivalMissionScript.isSurvivalMission = false;
	}

	public void optionSelected()
	{
		playButtonTapped = false;
		optionButtonTapped = true;
		extraButtonTapped = false; 
		gameCenterButtonTapped = false;
		mainButtonTapped = false; 
		DisableMainMenuButtons();

//		panelPlayMenu.SetActive(false);
//		panelExtraMenu.SetActive(false);
//		panelGameCenterMenu.SetActive(false);
//		panelOptionsMenu.SetActive(true); 
	}

	// Called in extra Button script
	public void ExtraSelected()
	{
		playButtonTapped = false;
		optionButtonTapped = false;
		extraButtonTapped = true;
		gameCenterButtonTapped = false;
		mainButtonTapped = false; 
		DisableMainMenuButtons();

//		panelPlayMenu.SetActive(false);
//		panelExtraMenu.SetActive(true);
//		panelGameCenterMenu.SetActive(false);
//		panelOptionsMenu.SetActive(false);

		//ExtraManager.isExtraMission = true;
		SurvivalMissionScript.isSurvivalMission = true; 
	}

	public void gameCenterSelected()
	{
		playButtonTapped = false;
		optionButtonTapped = false;
		extraButtonTapped = false;
		gameCenterButtonTapped = true;
		mainButtonTapped = false; 
		DisableMainMenuButtons();

//		panelPlayMenu.SetActive(false);
//		panelExtraMenu.SetActive(false);
//		panelGameCenterMenu.SetActive(true);
//		panelOptionsMenu.SetActive(false);
	}

	void EnableMainMenuButtons()
	{
//		foreach (GameObject button in mainMenuButtons) {
//			button.collider.enabled = true;
//		}
//
//		SetMainMenuButtonsToNormal();
	}

	void DisableMainMenuButtons()
	{
//		foreach (GameObject button in mainMenuButtons) {
//			button.collider.enabled = false; 
//		}
	}

	void SetMainMenuButtonsToNormal()
	{
//		foreach (GameObject buttonBG in mainMenuButtonBGs) {
//			UISlicedSprite buttonBGScript = buttonBG.GetComponent<UISlicedSprite>();
//			buttonBGScript.alpha = 70f/255f;
//		}
	}

	void EnablePlayMenuButtons()
	{
//		foreach (GameObject button in playMenuButtons) {
//			button.collider.enabled = true; 
//		}
//
//		mainMenuButtonBGScript.alpha = 150f/255f;
//		SetSelectMenuButtonsToNormal();
	}

	void DisablePlayMenuButtons()
	{
//		foreach (GameObject button in playMenuButtons) {
//			button.collider.enabled = false; 
//		}
	}

	void SetSelectMenuButtonsToNormal()
	{
//		foreach (GameObject button in selectMissionButtonsBG) {
//			UISlicedSprite buttonScript = button.GetComponent<UISlicedSprite>();
//			buttonScript.alpha = 80f/255f; 
//		}
	}

	void ShowMenuFlares()
	{
		foreach (GameObject flare in menuFlares) {
			flare.SetActive(true); 	
		}

		coboltFlareCockpit.SetBool("shouldFadeOut",false);
	}

	void HideMenuFlares()
	{
		foreach (GameObject flare in menuFlares) {
			flare.SetActive(false); 	
		}
	}

	void DisplayBlurredBackground()
	{
//		if (mainMenuBGBlurred) {
//			TweenAlpha.Begin(mainMenuBGBlurred,0.5f,1);	
//		}
	}

	void HideBlurredBackground()
	{
//		if (mainMenuBGBlurred) {
//			TweenAlpha.Begin(mainMenuBGBlurred,0.5f,0);	
//		}
	}

	void GoToSubMenu()
	{
		//panelAllMenus.animation.Play(panelAllMenusClip.name);
		coboltFlareTitle.GetComponent<Animation>().Play(coboltFlareTitleSlideOut.name); 
		iceWorldFlare.GetComponent<Animation>().Play(iceWorldFlareSlideIn.name); 
		coboltFlareCockpit.SetBool("shouldFadeOut",true); 
	}

	void ReturnToMainMenu()
	{
		coboltFlareCockpit.SetBool("shouldFadeOut",false);
		//panelAllMenus.animation.Play(returnToMainMenuClip.name);
		coboltFlareTitle.GetComponent<Animation>().Play(coboltFlareTitleSlideIn.name); 
		iceWorldFlare.GetComponent<Animation>().Play(iceWorldFlareSlideOut.name); 
	}

	public void ShowIceWorldFlareSubMenu()
	{
		iceWorldFlareAnimator.SetBool("shouldFadeOut",false); 
	}

	public void HideIceWorldFlareSubMenu()
	{
		iceWorldFlareAnimator.SetBool("shouldFadeOut",true); 
	}

	public void DisplayPanelAllMenus()
	{
		//panelAllMenus.SetActive(true); 
	}

	public void HidePanelAllMenus()
	{
		//panelAllMenus.SetActive(false); 
	}

	void DisplaySideBars()
	{
		//TweenAlpha.Begin(sideBarLeft,0.75f,0.3f);	
		//TweenAlpha.Begin(sideBarRight,0.75f,0.3f);
	}

	void HideSideBars()
	{
		//TweenAlpha.Begin(sideBarLeft,0.2f,0);	
		//TweenAlpha.Begin(sideBarRight,0.2f,0);
	}

	public void InvokeShowSocialMediaBG()
	{
		Invoke("ShowSocialMediaBG",0.5f); 	
	}

	void ShowSocialMediaBG()
	{
//		foreach (GameObject button in socialMediaButtonsIphone) {
//			button.collider.enabled = true; 	
//		}
//
//		foreach (GameObject buttonBG in socialMediaButtonBGs) {
//			TweenAlpha.Begin(buttonBG,0.5f,1f);
//		}		
	}
	
	public void HideSocialMediaBG()
	{
//		foreach (GameObject button in socialMediaButtonsIphone) {
//			button.collider.enabled = false; 	
//		}
//
//		foreach (GameObject buttonBG in socialMediaButtonBGs) {
//			TweenAlpha.Begin(buttonBG,0.5f,0);
//		}
	}

	// for iPad Social Medial UI
	public void InvokeShowSocialMediaBgForIpad()
	{
		Invoke("ShowSocialMediaBgForIpad",0.5f); 	
	}
	
	void ShowSocialMediaBgForIpad()
	{
//		foreach (GameObject buttonBG in socialMediaButtonBGsForIpad) {
//			TweenAlpha.Begin(buttonBG,0.5f,1f);
//		}		
	}
	
	public void HideSocialMediaBgForIpad()
	{
//		foreach (GameObject buttonBG in socialMediaButtonBGsForIpad) {
//			TweenAlpha.Begin(buttonBG,0.5f,0);
//		}
	}
}
