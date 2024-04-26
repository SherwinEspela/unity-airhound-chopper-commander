using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using PathologicalGames; 

public class ControlsVisibilityScript : MonoBehaviour {
	
	public GameObject leftJoystickObject;
	private EasyJoystick leftJoystickScript;
	public GameObject fireJoystickObject;
	private EasyJoystick fireJoystickScript;
	public GameObject buttonFire1Object;
	private EasyButton buttonFire1Script;

	public GameObject buttonRocket;
	private EasyButton buttonRocketScript;

	//public GameObject buttonFire2Object;
	//public GameObject buttonDirectionObject;

	public GameObject buttonDirection2; 
	private EasyButton buttonDirection2Script;

	// NGUI objects
	//public GameObject buttonPause;
	
	private float smooth = 5f;
	private Color transparent; 
	private Color opaque; 
	
	private Vector2 fireJoystickOffsetPosition; 
	private Vector2 fireJoystickProperPosition;
	private Vector2 fireJoystickNewPosition; 
	
	private Vector2 button1OffsetPosition; 
	private Vector2 button1ProperPosition; 
	private Vector2 button1NewPosition;

	// for buttonRocket
	private Vector2 buttonRocketOffsetPosition; 
	private Vector2 buttonRocketProperPosition;
	private Vector2 buttonRocketNewPosition; 

	// for buttonDirection2
	private Vector2 buttonDirection2OffsetPosition; 
	private Vector2 buttonDirection2ProperPosition;
	private Vector2 buttonDirection2NewPosition;

	private Vector3 button2OffsetPosition; 
	private Vector3 button2ProperPosition; 
	private Vector3 button2NewPosition; 
	
	private Vector3 buttonDirectionOffsetPosition; 
	private Vector3 buttonDirectionProperPosition; 
	private Vector3 buttonDirectionNewPosition; 
	
	private Vector3 buttonPauseOffsetPosition; 
	private Vector3 buttonPauseProperPosition; 
	private Vector3 buttonPauseNewPosition;
	
	private bool controlsAreRequired = false;
	public AudioClip beginMissionAudio;

	//public GameObject panelNewHUD;
	private Vector3 panelNewHUDOffsetPosition; 
	private Vector3 panelNewHUDProperPosition = new Vector3(0f,0f,0f);
	private Vector3 panelNewHUDNewPosition; 

	//public Transform panelVitalGroup;

	public GameObject labelReward;
	public GameObject labelRewardRocket; 
	//public GameObject panelReward; 
	public GameObject labelRewardSpawnPoint; 

	//private GameObject panelTopHud; 
	private Animator panelTopHudAnimator; 

	private GameObject imageDirectionArrowForward; 
	private GameObject imageDirectionArrowBackward; 

	private Animator panelHealthIncreaseAnimator; 
	private Animator panelRocketIncreaseAnimator;
	private Text textHealthIncrease; 
	private Text textRocketIncrease;

	// Use this for initialization
	void Start () {
		fireJoystickScript = fireJoystickObject.GetComponent<EasyJoystick>();
		buttonFire1Script = buttonFire1Object.GetComponent<EasyButton>();
		buttonRocketScript = buttonRocket.GetComponent<EasyButton>();
		buttonDirection2Script = buttonDirection2.GetComponent<EasyButton>(); 
		fireJoystickOffsetPosition = fireJoystickScript.JoystickPositionOffset;
		button1OffsetPosition = buttonFire1Script.Offset;
		buttonRocketOffsetPosition = buttonRocketScript.Offset;
		buttonDirection2OffsetPosition = buttonDirection2Script.Offset;

		//button2OffsetPosition = buttonFire2Object.transform.position;
		//buttonDirectionOffsetPosition = buttonDirectionObject.transform.position;

		fireJoystickNewPosition = fireJoystickScript.JoystickPositionOffset;
		button1NewPosition = buttonFire1Script.Offset;
		button2NewPosition = button2OffsetPosition;
		buttonDirectionNewPosition = buttonDirectionOffsetPosition; 

		Invoke("ControlsRequired",7);
		Invoke("PlayBeginMissionAudio",5);

		if (DeviceManager.deviceIsIPad) {
			// for buttonPause
			//buttonPause.transform.localPosition = new Vector3(600f,366f,-6f); 
			//buttonPause.transform.localScale = new Vector3(0.32f,0.32f,1f); 
			buttonPauseProperPosition = new Vector3(494f,366f,-6f);

			//panelVitalGroup.localPosition = new Vector3(70f,62f,0f); 
			//panelVitalGroup.localScale = new Vector3(0.84f,0.84f,1f);

			//panelReward.transform.localPosition = new Vector3(-508,224,0f);
			//panelReward.transform.localScale = new Vector3(0.75f,0.75f,1f); 
		} else {
			// for buttonPause
			//buttonPause.transform.localPosition = new Vector3(750,338,-6); 
			//buttonPause.transform.localScale = new Vector3(0.7f,0.7f,1f); 
			buttonPauseProperPosition = new Vector3(638f,338f,-6f);

			//panelVitalGroup.localPosition = new Vector3(0f,0f,0f); 
			//panelVitalGroup.localScale = new Vector3(1f,1f,1f);

			//panelReward.transform.localPosition = new Vector3(-670,224,0f);
			//panelReward.transform.localScale = new Vector3(1f,1f,1f); 
		}

		//buttonPauseOffsetPosition = buttonPause.transform.localPosition;
		//buttonPauseNewPosition = buttonPauseOffsetPosition;

		fireJoystickProperPosition = new Vector2(0f,0f);
		button1ProperPosition = new Vector2(-30f,-30f);
		buttonRocketProperPosition = new Vector2(-20,-202);
		buttonDirection2ProperPosition = new Vector2(-208,-20); 
		button2ProperPosition = new Vector3(1.1f,-0.3f,1.7f); 
		buttonDirectionProperPosition = new Vector3(0.6f,-0.7f,1.7f);

		//panelNewHUDOffsetPosition = panelNewHUD.transform.localPosition;
	
		Invoke ("FindUIElements",1f); 
		Invoke ("FindPanelTopHudAnimatorComponent",1f); 
		Invoke ("ShowPanelTopHud",7f);
	}

	void FindUIElements()
	{
		imageDirectionArrowForward = GameObject.Find ("ImageDirectionArrowForward"); 
		imageDirectionArrowBackward = GameObject.Find ("ImageDirectionArrowBackward");
		imageDirectionArrowBackward.SetActive (false); 

		panelHealthIncreaseAnimator = GameObject.Find ("PanelHealthIncrease").GetComponent<Animator> (); 
		panelRocketIncreaseAnimator = GameObject.Find ("PanelRocketIncrease").GetComponent<Animator> ();

		textHealthIncrease = GameObject.Find ("TextHealthIncrease").GetComponent<Text> ();
		textRocketIncrease = GameObject.Find ("TextRocketIncrease").GetComponent<Text> ();
	}

	public void SetTextHealthIncrease(string newText)
	{
		textHealthIncrease.text = newText; 
	}

	public void SetTextRocketIncrease(string newText)
	{
		textRocketIncrease.text = newText; 
	}

	public void ShowPanelIncrease()
	{
		if (!GameManagerScript.gameIsOver) {
			panelHealthIncreaseAnimator.SetBool ("panelIncreaseIsShown",true);
			panelRocketIncreaseAnimator.SetBool ("panelIncreaseIsShown",true);
			Invoke ("HidePanelIncrease",0.5f); 
			panelHealthIncreaseAnimator.GetComponent<AudioSource>().Play ();
		}
	}

	void HidePanelIncrease()
	{
		panelHealthIncreaseAnimator.SetBool ("panelIncreaseIsShown",false);
		panelRocketIncreaseAnimator.SetBool ("panelIncreaseIsShown",false);
	}

	public void ShowImageDirectionArrowForward()
	{
		imageDirectionArrowForward.SetActive (true);
		imageDirectionArrowBackward.SetActive (false);
	}

	public void ShowImageDirectionArrowBackward()
	{
		imageDirectionArrowForward.SetActive (false);
		imageDirectionArrowBackward.SetActive (true);
	}

	public void HideBothImageDirectionArrows()
	{
		imageDirectionArrowForward.SetActive (false);
		imageDirectionArrowBackward.SetActive (false);
	}

	void FindPanelTopHudAnimatorComponent()
	{
		panelTopHudAnimator = GameObject.Find("PanelTopHud").GetComponent<Animator>();
	}

	public void InvokeHidePanelTopHud()
	{
		Invoke ("HidePanelTopHud",2f); 
	}

	public void ShowPanelTopHud()
	{
		if (panelTopHudAnimator) {
			panelTopHudAnimator.SetBool ("panelTopHudIsShown",true);	
		}
	}

	public void HidePanelTopHud()
	{
		if (panelTopHudAnimator) {
			panelTopHudAnimator.SetBool ("panelTopHudIsShown",false);	
		}
	}

	// Update is called once per frame
	void Update() {				
		controlsPositionChange();
	}

	void controlsPositionChange()
	{
		if (controlsAreRequired) {
			leftJoystickObject.SetActive(true); 
			fireJoystickNewPosition = fireJoystickProperPosition;
			button1NewPosition = button1ProperPosition;

			buttonRocketNewPosition = buttonRocketProperPosition;
			buttonDirection2NewPosition = buttonDirection2ProperPosition;

			button2NewPosition = button2ProperPosition; 
			buttonDirectionNewPosition = buttonDirectionProperPosition;
			buttonPauseNewPosition = buttonPauseProperPosition;

			panelNewHUDNewPosition = panelNewHUDProperPosition;
		}
		
		else {
			leftJoystickObject.SetActive(false); 
			fireJoystickNewPosition = fireJoystickOffsetPosition;
			button1NewPosition = button1OffsetPosition;

			buttonRocketNewPosition = buttonRocketOffsetPosition;
			buttonDirection2NewPosition = buttonDirection2OffsetPosition;

			button2NewPosition = button2OffsetPosition; 
			buttonDirectionNewPosition = buttonDirectionOffsetPosition; 
			buttonPauseNewPosition = buttonPauseOffsetPosition; 

			panelNewHUDNewPosition = panelNewHUDOffsetPosition;
		}

		fireJoystickScript.JoystickPositionOffset = Vector2.Lerp(fireJoystickScript.JoystickPositionOffset,fireJoystickNewPosition,Time.deltaTime*smooth); 
		buttonFire1Script.Offset = Vector2.Lerp(buttonFire1Script.Offset,button1NewPosition,Time.deltaTime*smooth); 

		buttonRocketScript.Offset = Vector2.Lerp(buttonRocketScript.Offset,buttonRocketNewPosition,Time.deltaTime*smooth);
		buttonDirection2Script.Offset = Vector2.Lerp(buttonDirection2Script.Offset,buttonDirection2NewPosition,Time.deltaTime*smooth);

		//buttonFire2Object.transform.position = Vector3.Lerp(buttonFire2Object.transform.position,button2NewPosition,Time.deltaTime*smooth);
		//buttonDirectionObject.transform.position = Vector3.Lerp(buttonDirectionObject.transform.position,buttonDirectionNewPosition,Time.deltaTime*smooth);
		//buttonPause.transform.localPosition = Vector3.Lerp(buttonPause.transform.localPosition,buttonPauseNewPosition,Time.deltaTime*smooth);

		//panelNewHUD.transform.localPosition = Vector3.Lerp(panelNewHUD.transform.localPosition,panelNewHUDNewPosition,Time.deltaTime*smooth);
	}
		
	public void ControlsRequired()
	{
		controlsAreRequired = true; 
	}
	
	public void ControlsNotRequired()
	{
		controlsAreRequired = false; 
	}
	
	void PlayBeginMissionAudio()
	{
		GetComponent<AudioSource>().PlayOneShot(beginMissionAudio);
	}

	void DisablePauseButton()
	{
		//buttonPause.collider.enabled = false; 
	}

	void EnablePauseButton()
	{
		//buttonPause.collider.enabled = true;
	}

	public void DisplayRewards(string rewardString)
	{
//		Transform clone = PoolManager.Pools["Miscs"].Spawn(labelReward.transform,labelRewardSpawnPoint.transform.localPosition,labelRewardSpawnPoint.transform.localRotation);
//		//clone.transform.parent = panelReward.transform;
//		UILabel labelScript = clone.GetComponent<UILabel>();
//		labelScript.text = rewardString;
//		TweenAlpha.Begin(clone.gameObject,1.4f,0);
	}

	public void DisplayRewardsRocket(string rewardString)
	{
//		Transform clone = PoolManager.Pools["Miscs"].Spawn(labelRewardRocket.transform,labelRewardSpawnPoint.transform.localPosition,labelRewardSpawnPoint.transform.localRotation);
//		//clone.transform.parent = panelReward.transform;
//		UILabel labelScript = clone.GetComponent<UILabel>();
//		labelScript.text = rewardString;
//		TweenAlpha.Begin(clone.gameObject,1.7f,0);
	}
}
