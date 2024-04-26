using UnityEngine;
using UnityEngine.UI; 
using System.Collections;
using PathologicalGames; 

public class ChopperHealth : MonoBehaviour {

	private float health = 100f;

	// Enemy Damage Values
	// Variables
	private float enemyCannondamage;
	private float enemyRocketLauncherdamage; 
	
	public GameObject explosion;
	public Transform explosionSpawn; 
	private float nextLoad;
	public Transform gameManager;
	private Image imageHealthIndicator; 
	public GameObject gameObjectToDestroy;
	private bool vitalCriticalAudioPlayed = false;
	public GameObject vitalCriticalAudioHolder; // this object is found in the chopperMain group
	private float nextVitalCriticalWarningAudioPlay; 
	private float vitalCriticalWarningAudioRate = 2.2f;

	// Joystick and Button
	public GameObject JoystickMove; 
	public GameObject JoystickFire; 
	public GameObject ButtonFire1;
	private EasyJoystick easyJoystickMoveScript; 
	private EasyJoystick easyJoystickFireScript; 
	private EasyButton easyButtonFireScript;

	public GameObject tempButtonFireReceiverObject; 
	public GameObject chopperMeshGroup;
	public GameObject itemPickerGroup; 
	public GameObject laserPointerGroup; 
	private bool chopperIsNotDestroyed = true; 
	private bool isNukeDetected = false; 

	public GameObject healthFX; 
	public AudioClip healthFxSound; 
	public Transform healthFXSpawn; 

	private float healthIndicatorFactorValue = 0.7f; 

	// properties
	public float Health
	{
		get;
		set; 
	}

	private Animator imageHealthIndicatorAnimator;
	private Image imageHealthImageScript; 
	private Animator imageHealthAnimator; 
	private Animator imageChopperAnimator; 

	void Start()
	{
		enemyCannondamage = 7f; 
		enemyRocketLauncherdamage = 14f; 

		Invoke ("FindUIElements",1f); 

		easyJoystickMoveScript = JoystickMove.GetComponent<EasyJoystick>();
		easyJoystickFireScript = JoystickFire.GetComponent<EasyJoystick>();
		easyButtonFireScript = ButtonFire1.GetComponent<EasyButton>();
	}

	void FindUIElements()
	{
		GameObject imageHealthIndicatorGo = GameObject.Find ("ImageHealthIndicator"); 
		imageHealthIndicator = imageHealthIndicatorGo.GetComponent<Image>();
		imageHealthIndicatorAnimator = imageHealthIndicatorGo.GetComponent<Animator>();
		imageHealthImageScript = GameObject.Find("ImageHealth").GetComponent<Image>();
		imageHealthAnimator = GameObject.Find("ImageHealth").GetComponent<Animator>();
		imageChopperAnimator = GameObject.Find("ImageChopper").GetComponent<Animator>();
	}

	void HealthChangesEvent()
	{
		if (health <= 0) {
			if (chopperIsNotDestroyed) {

				vitalCriticalAudioHolder.SendMessage("stopVitalCriticalWarningAudio",SendMessageOptions.DontRequireReceiver);
				gameManager.SendMessage("DisableChopperSound",SendMessageOptions.DontRequireReceiver); // from GameManagerScript.cs 

				GameManagerScript.gameIsOver = true; 

				GameManagerScript.resultInThisMission = GameManagerScript.MissionResult.MissionFailed; 
				chopperMeshGroup.SetActive(false);
				itemPickerGroup.SetActive(false); 
				laserPointerGroup.SetActive(false);

				Instantiate (explosion, explosionSpawn.position, explosionSpawn.rotation);
				
				//panelMessagePrompt.SetActive(false); 
				 
				gameManager.SendMessage("StopTheTimer",SendMessageOptions.DontRequireReceiver);
				gameManager.SendMessage("InvokeRunScoreManagerScript",false,SendMessageOptions.DontRequireReceiver); 
				gameManager.SendMessage("InvokePlayChopperDownChatter",SendMessageOptions.DontRequireReceiver);
				gameManager.SendMessage("SetIsFailedByDestruction",SendMessageOptions.DontRequireReceiver); // from MissionOutcome
				GameManagerScript.gameManagerStatic.SendMessage("HideGamepadControllers",SendMessageOptions.DontRequireReceiver); // from GameManagerScript.cs
				GameManagerScript.gameManagerStatic.SendMessage("HidePanelTopHud",SendMessageOptions.DontRequireReceiver); // from ControlsVisibilityScript.cs
				gameManager.SendMessage("SpawningDeactivated",SendMessageOptions.DontRequireReceiver); // from GameManagerScript
				gameManager.SendMessage("DisableProjectileSpawners",SendMessageOptions.DontRequireReceiver); // from RevivePlayer

				chopperIsNotDestroyed = false; 

				GameManagerScript.gameManagerStatic.SendMessage("DisablePanelEventMessage",SendMessageOptions.DontRequireReceiver); // from EventMessageScript.cs
				GameManagerScript.gameManagerStatic.SendMessage("ShowTextMissionFailed",SendMessageOptions.DontRequireReceiver); // from UnityGUIGamePlayManager.cs
				//GameManagerScript.gameManagerStatic.SendMessage("SetTextMissionResultTop","YOU HAVE BEEN DESTROYED!",SendMessageOptions.DontRequireReceiver); // from UnityGUIGamePlayManager.cs
				GameManagerScript.gameManagerStatic.SendMessage("SetImageMissionResultsTopBGColor",Color.red,SendMessageOptions.DontRequireReceiver); // from UnityGUIGamePlayManager.cs
				GameManagerScript.gameManagerStatic.SendMessage("ShowPanelMissionResultsGroup",SendMessageOptions.DontRequireReceiver); // from UnityGUIGamePlayManager.cs
				GameManagerScript.gameManagerStatic.SendMessage("InvokeTriggerShowPanelMissionResultsGroup",1f,SendMessageOptions.DontRequireReceiver); // from UnityGUIGamePlayManager.cs
				vitalCriticalAudioHolder.SendMessage("stopVitalCriticalWarningAudio",SendMessageOptions.DontRequireReceiver);
			}
		}
		
		else if (health <= 25) {
			if (Time.time > nextVitalCriticalWarningAudioPlay) {
				nextVitalCriticalWarningAudioPlay = Time.time + vitalCriticalWarningAudioRate;
				vitalCriticalAudioHolder.SendMessage("playVitalCriticalWarningAudio",SendMessageOptions.DontRequireReceiver);  
			}
			
			if (!vitalCriticalAudioPlayed) {
				gameManager.SendMessage("playVitalCriticalChatter",SendMessageOptions.DontRequireReceiver);
				vitalCriticalAudioPlayed = true; 
			}

			imageHealthIndicatorAnimator.SetBool("healthIndicatorIsLow",true); 
			imageHealthAnimator.SetBool("healthIndicatorIsLow",true);
			imageHealthImageScript.color = new Color(255f/255,0,0); 
			imageChopperAnimator.SetBool("healthIndicatorIsLow",true);
		}
		
		else if (health > 25) {
			vitalCriticalAudioHolder.SendMessage("stopVitalCriticalWarningAudio",SendMessageOptions.DontRequireReceiver);
			imageHealthIndicatorAnimator.SetBool("healthIndicatorIsLow",false);
			imageHealthAnimator.SetBool("healthIndicatorIsLow",false);
			imageHealthImageScript.color = new Color(0,159f/255,34f/255);
			imageChopperAnimator.SetBool("healthIndicatorIsLow",false);
		}
	}
	
	void OnCollisionEnter (Collision col)
	{
		ReduceChopperHealth (col); 
	}

	public void ReduceChopperHealth(Collision col)
	{
		if (col.gameObject.name.Contains("tankCannon")) {
			health -= enemyCannondamage;	
		}
		
		else if (col.gameObject.name.Contains("turretRocket")) {
			health -= enemyRocketLauncherdamage;	
		}
		
		else if (col.gameObject.name.Contains("drone2Rocket")) {
			health -= enemyRocketLauncherdamage;	
		}
		
		UpdateHealthBar(); 
		HealthChangesEvent();
	}

	void DamageChopperByCollision(float collisionDamage)
	{
		health -= collisionDamage; 
		UpdateHealthBar(); 
		HealthChangesEvent(); 
	}
	
	void UpdateHealthBar()
	{
		if (health < 0) {
			health = 0; 
		}
		
		float healthBarSize = health * healthIndicatorFactorValue / 100f;
		imageHealthIndicator.fillAmount = healthBarSize; 
	}
	
	public void AddHealth(float bonusHealth)
	{
		ShowHealthIncreaseFX();

		health += bonusHealth;
		if (health > 100) {
			health = 100; 
		}

		UpdateHealthBar();
		HealthChangesEvent(); 
	}

	public void SetChopperMeshGroupToActive()
	{
		chopperMeshGroup.SetActive(true);
		itemPickerGroup.SetActive(true);
		if (isNukeDetected == true) {
			laserPointerGroup.SetActive(true); 	
		}
	}

	public void SetChopperIsDestroyed()
	{
		chopperIsNotDestroyed = true; 
	}

	public void RestoreChopperToFullHealth()
	{
		health = 100f; 
		UpdateHealthBar();
		HealthChangesEvent(); 
	}

	public void SetNukeIsDetected()
	{
		isNukeDetected = true; 
	}

	public void SetNukeIsNotDetected()
	{
		isNukeDetected = false; 
	}

	void ShowHealthIncreaseFX()
	{
		if (GetComponent<AudioSource>()) {
			GetComponent<AudioSource>().PlayOneShot(healthFxSound); 	
		}
		GameObject healthFXClone = Instantiate(healthFX,healthFXSpawn.position,healthFX.transform.rotation) as GameObject; 
		healthFXClone.transform.parent = healthFXSpawn; 
	}
}
