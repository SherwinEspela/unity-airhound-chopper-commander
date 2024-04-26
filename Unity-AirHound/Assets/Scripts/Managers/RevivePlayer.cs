using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class RevivePlayer : MonoBehaviour {

	public GameObject chopperHealthCollider; 
	private GameObject panelMissionOutcome; 
	public GameObject chopperNoseRotationControl; 
	public AnimationClip noseUpClip;
	public GameObject chopperMain; 
	private GameObject[] nukeCrates; 
	private GameObject[] nukeHealthCols;
	private List<GameObject> projectileSpawners; 
	public GameObject adColonyMainSettings; 
	public static int tokens;
	public static bool isRevivingPlayer = false; 
	public AudioClip extraLifeVoice; 

	private GameObject panelScoreMenu; 
	private GameObject panelInviteFriendsMenu; 
	private GameObject panelNavigationMenu; 

	void Start()
	{
		if(PlayerPrefs.HasKey("TokenCreditsPlayerPrefs")){
			tokens = PlayerPrefs.GetInt("TokenCreditsPlayerPrefs");  
		} else {
			tokens = 2;
			PlayerPrefs.SetInt("TokenCreditsPlayerPrefs",tokens);
		}
		LoadTheNukeCrates();
		LoadTheNukeHealthCols(); 
		panelMissionOutcome = GameObject.Find("PanelMissionOutcome(Clone)"); 
		projectileSpawners = new List<GameObject>(); 
	}

	public void LoadTheNukeCrates()
	{
		nukeCrates = GameObject.FindGameObjectsWithTag("NukeCrateTag");
	}

	public void LoadTheNukeHealthCols()
	{
		nukeHealthCols = GameObject.FindGameObjectsWithTag("NukeHealthTag");
	}

	public void PlayAdColonyV4VC()
	{
		adColonyMainSettings.SendMessage("PlayAdColonyV4VC",SendMessageOptions.DontRequireReceiver); 
	}

	public void ReviveThePlayer()
	{
		if (tokens > 0) {
			this.gameObject.BroadcastMessage("EnableMusic",SendMessageOptions.DontRequireReceiver);

			// Proceed to reviving the player
			ProcessRevivingPlayer();

			// reduce extra life value
			tokens--; 
			isRevivingPlayer = false; 

		} else {
			this.gameObject.BroadcastMessage("DisableMusic",SendMessageOptions.DontRequireReceiver); 
			isRevivingPlayer = true; 
			PlayAdColonyV4VC(); 
		}
	}

	public void ProcessRevivingPlayer()
	{
		// Dismiss the GUIs
		this.gameObject.BroadcastMessage("EnablePauseButton",SendMessageOptions.DontRequireReceiver);
		this.gameObject.BroadcastMessage("HideAdBanner",SendMessageOptions.DontRequireReceiver);

		// Set chopper health to 100%
		chopperHealthCollider.SendMessage("RestoreChopperToFullHealth",SendMessageOptions.DontRequireReceiver); 

		// Set the chopper mesh to visible
		chopperHealthCollider.SendMessage("SetChopperMeshGroupToActive",SendMessageOptions.DontRequireReceiver);

		// Reset the Panel Mission Outcome
		panelScoreMenu.transform.position = new Vector3(1350,0,0); 
		panelInviteFriendsMenu.transform.position = new Vector3(1350,0,0);
		panelNavigationMenu.transform.position = new Vector3(1350,0,0); 

		// Hide the Panel Mission Outcome
		this.gameObject.BroadcastMessage("HideThePanelMissionOutcome",SendMessageOptions.DontRequireReceiver); // from MissionOutcomeScript2

		// enable projectile spawners and clear the list
		foreach (var item in projectileSpawners) {
			item.SetActive(true); 	
		}
		projectileSpawners.Clear(); 

		// Set the chopperIsDestroyed bool value to false
		this.gameObject.BroadcastMessage("SetChopperIsNotDestroyed",SendMessageOptions.DontRequireReceiver); 

		// Set bool value of chopperIsNotDestroyed to true; 
		chopperHealthCollider.SendMessage("SetChopperIsDestroyed",SendMessageOptions.DontRequireReceiver); 

		// Place chopper to default position and set to normal pose
		chopperMain.transform.localPosition = new Vector3(chopperMain.transform.localPosition.x,3f,0f); 
		chopperNoseRotationControl.GetComponent<Animation>().Play(noseUpClip.name); 
		
		// Destroy all aerial enemies in the scene
		GameObject[] aerialEnemyHealthCols = GameObject.FindGameObjectsWithTag("MovingEnemyHealth"); 
		foreach (GameObject aerialEnemyHealthCol in aerialEnemyHealthCols) {
			aerialEnemyHealthCol.SendMessage("DecreaseObjectsHealth",100,SendMessageOptions.DontRequireReceiver); 
		}

		// If Chopper collided with Nuke then set the nuke object active
		foreach (GameObject nukeCrate in nukeCrates) {
			nukeCrate.SetActive(true); 
		}

		// Replenish nuke health value to 20
		foreach (GameObject nukeHealthCol in nukeHealthCols) {
			nukeHealthCol.SendMessage("ReplenishNukeHealth",SendMessageOptions.DontRequireReceiver); 
			nukeHealthCol.SendMessage("SetNukeIsNotDestroyed",SendMessageOptions.DontRequireReceiver);
		}

		// enable controls and hud displays   
		this.gameObject.BroadcastMessage("DisplayControlsAndHud",SendMessageOptions.DontRequireReceiver);
		this.gameObject.BroadcastMessage("CurtainFadeOut",SendMessageOptions.DontRequireReceiver); // to hide the curtain

		// Disable chopper main audio
		chopperMain.GetComponent<AudioSource>().enabled = false; 
		Invoke("PlayExtraLifeVoice",2f); 

		// activate spawning
		this.gameObject.BroadcastMessage("SpawningActivated",SendMessageOptions.DontRequireReceiver); // from GameManagerScript

		// Set music to normal level and resume the timer
		this.gameObject.BroadcastMessage("ResumeTheTimer",SendMessageOptions.DontRequireReceiver); 
		this.gameObject.BroadcastMessage("AudioSettingsResumed",SendMessageOptions.DontRequireReceiver); 
	}

	void PlayExtraLifeVoice()
	{
		if (GetComponent<AudioSource>()) {
			if (extraLifeVoice) {
				GetComponent<AudioSource>().PlayOneShot(extraLifeVoice);	
			}
		}
	}

	public void InitializePanelOutcomeMenus()
	{
		if (panelMissionOutcome == null) {
			panelMissionOutcome = GameObject.Find("PanelMissionOutcome(Clone)");
		}
		if (panelScoreMenu == null) {
			panelScoreMenu = GameObject.Find("PanelScoreMenu"); 
		}
		if (panelInviteFriendsMenu == null) {
			panelInviteFriendsMenu = GameObject.Find("PanelInviteFriendsMenu"); 	
		}
		if (panelNavigationMenu == null) {
			panelNavigationMenu = GameObject.Find("PanelNavigationMenu"); 	
		}
	}

	public void DisableProjectileSpawners()
	{
		GameObject[] projectileSpawnersArray = GameObject.FindGameObjectsWithTag("ProjectileSpawner");
		foreach (GameObject ps in projectileSpawnersArray) {
			ps.SetActive(false); 
			projectileSpawners.Add(ps); 
		}
	}
}
