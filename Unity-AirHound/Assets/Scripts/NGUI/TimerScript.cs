using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class TimerScript : MonoBehaviour {
		
	public GameObject gameManager; 
	private Text textTimerMinute;
	private Text textTimerSeconds;

	private float startTime; 
	private float restSeconds;
	private int roundedRestSeconds; 
	private float displaySeconds;
	private float displayMinutes;
	private int countDownSeconds;
	private float timeLeft;
	private string minuteText;
	private string secondsText; 
	private bool startTimer = false;

	private bool only2MinutesLeft = false; 
	private bool only30SecondsLeft = false;
	private bool sirenIsPlayed = false;
	private bool timeRunOutPlayed = false; 
	//public GameObject panelMessagePrompt; 
	public int CountDownSeconds
	{
		get{return countDownSeconds;} 
		set{countDownSeconds = value;}
	}
	private int survivalMissionResetTimeValue = 180; 
	//public GameObject panelTimer; 
	//public GameObject labelTimeValue;
	//private UILabel labelTimeValueScript; 
	public AudioClip[] gameOverVoices; 

	// Use this for initialization
	void Awake() {
		if (gameManager == null) {
			gameManager = GameObject.Find("GameManager"); 
		}
		Invoke ("FindUIElements",1f); 
		Invoke("StartTheTimer",9f); 
		//labelTimeValueScript = labelTimeValue.GetComponent<UILabel>(); 
	}

	void FindUIElements()
	{
		textTimerMinute = GameObject.Find ("TextTimerMinute").GetComponent<Text>(); 
		textTimerSeconds = GameObject.Find ("TextTimerSeconds").GetComponent<Text>();
	}

	// Update is called once per frame
	void Update () {
		if (startTimer) {
			PlayTimer(); 	
		}
	}

	void PlayTimer()
	{
		timeLeft = Time.time - startTime; 
		restSeconds = CountDownSeconds - (timeLeft);
		roundedRestSeconds = Mathf.CeilToInt(restSeconds);

		displaySeconds = roundedRestSeconds % 60; 
		displayMinutes = (roundedRestSeconds / 60) % 60;
		minuteText = displayMinutes.ToString(); 

		if(displayMinutes > 9)
		{
			minuteText = displayMinutes.ToString(); 
		} else {
			minuteText = "0" + displayMinutes.ToString(); 
		}

		if(displaySeconds > 9)
		{
			secondsText = displaySeconds.ToString(); 
		} else {
			secondsText = "0" + displaySeconds.ToString(); 
		}

		textTimerMinute.text = minuteText;
		textTimerSeconds.text = secondsText; 
		//labelTimeValueScript.text = minuteText + ":" + secondsText;

		if (displayMinutes == 2) {
			if (displaySeconds == 0) {
				playOnly2MinutesLeftChatter();
			}
		}

		if (displayMinutes == 0) {
			if (displaySeconds == 35) {
				playOnly30SecondsLeftChatter();
			}
		}

		if (displayMinutes == 0) {
			if (displaySeconds == 16) {
				playSiren();
				//playTimeRunningOutChatter();
			}
		}

		if (displayMinutes == 0) {
			if (displaySeconds == 11) {
				playTimeRunningOutChatter();
			}
		}

		if (displayMinutes == 0) {
			if (displaySeconds <= 0) {
				GameManagerScript.gameIsOver = true; 
				startTimer = false; 

				GameManagerScript.resultInThisMission = GameManagerScript.MissionResult.MissionFailed; 
				gameObject.SendMessage("SetIsFailedByTimeOut",SendMessageOptions.DontRequireReceiver); // MissionOutcomeScript

				GameManagerScript.gameManagerStatic.SendMessage("HideGamepadControllers",SendMessageOptions.DontRequireReceiver); // from GameManagerScript.cs
				GameManagerScript.gameManagerStatic.SendMessage("HidePanelTopHud",SendMessageOptions.DontRequireReceiver); // from ControlsVisibilityScript.cs
				this.gameObject.BroadcastMessage("SpawningDeactivated",SendMessageOptions.DontRequireReceiver); // from GameManagerScript
				this.gameObject.BroadcastMessage("DisableProjectileSpawners",SendMessageOptions.DontRequireReceiver); // from RevivePlayer
				Invoke("playGameOverVoice",2f); 

				GameManagerScript.gameManagerStatic.SendMessage("DisablePanelEventMessage",SendMessageOptions.DontRequireReceiver); // from EventMessageScript.cs
				GameManagerScript.gameManagerStatic.SendMessage("ShowTextMissionFailed",SendMessageOptions.DontRequireReceiver); // from UnityGUIGamePlayManager.cs
				//GameManagerScript.gameManagerStatic.SendMessage("SetTextMissionResultTop","TIME HAS RUN OUT!",SendMessageOptions.DontRequireReceiver); // from UnityGUIGamePlayManager.cs
				GameManagerScript.gameManagerStatic.SendMessage("SetImageMissionResultsTopBGColor",Color.red,SendMessageOptions.DontRequireReceiver); // from UnityGUIGamePlayManager.cs
				GameManagerScript.gameManagerStatic.SendMessage("ShowPanelMissionResultsGroup",SendMessageOptions.DontRequireReceiver); // from UnityGUIGamePlayManager.cs
				GameManagerScript.gameManagerStatic.SendMessage("InvokeTriggerShowPanelMissionResultsGroup",1f,SendMessageOptions.DontRequireReceiver); // from UnityGUIGamePlayManager.cs
			}
		}
	}

	void StartTheTimer()
	{
		startTime = Time.time;
		startTimer = true; 
	}

	public void SetTheTimerIn3Minutes()
	{
		startTime = Time.time;
		CountDownSeconds = survivalMissionResetTimeValue;
	}

	public void StopTheTimer()
	{
		CountDownSeconds = roundedRestSeconds;
		startTimer = false;
	}

	public void ResumeTheTimer()
	{
		startTimer = true; 
		startTime = Time.time;
	}

	public float GetMinutesValue()
	{
		return displayMinutes;
	}

	public float GetSecondsValue()
	{
		return displaySeconds;
	}

	void playOnly2MinutesLeftChatter()
	{
		if (!only2MinutesLeft) {
			gameManager.SendMessage("InvokeOnly2MinutesLeftChatter",SendMessageOptions.DontRequireReceiver);
			only2MinutesLeft = true; 
		}
	}

	void playOnly30SecondsLeftChatter()
	{
		if (!only30SecondsLeft) {
			gameManager.SendMessage("InvokeOnly30SecondsLeftChatter",SendMessageOptions.DontRequireReceiver);
			only30SecondsLeft = true; 
		}
	}

	void playSiren()
	{
		if (!sirenIsPlayed) {
			gameManager.SendMessage("InvokePlaySiren",SendMessageOptions.DontRequireReceiver);
			sirenIsPlayed = true; 
		}
	}

	void playTimeRunningOutChatter()
	{
		if (!timeRunOutPlayed) {
			gameManager.SendMessage("InvokeTimeIsRunningOutChatter",SendMessageOptions.DontRequireReceiver);
			timeRunOutPlayed = true; 
		}
	}

	void playGameOverVoice()
	{
		if (GetComponent<AudioSource>()){
			if (gameOverVoices.Length > 0) {
				GetComponent<AudioSource>().PlayOneShot(gameOverVoices[Random.Range(0,gameOverVoices.Length)]); 
			}
		}
	}
}
