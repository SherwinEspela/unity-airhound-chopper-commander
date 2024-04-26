using UnityEngine;
using UnityEngine.UI; 
using System.Collections;
using System.Collections.Generic; 
using PathologicalGames; 
using AirHound;

public class GameManagerScript : MonoBehaviour {

	public static GameObject gameManagerStatic; 

	// Scenes String
	private string mainMenu = "MainMenu";
	private string loadingScene = "LoadingScene";
	private string adScene = "AdScene"; 

	private bool pause = false;
	public GameObject chopperObject;
	public Transform cameraAdjustment;

	public GameObject enemyBuzzer;
	public GameObject[] enemyDrones; 
	public GameObject[] enemyTanks; 
	public GameObject[] enemyJeeps;
	public Transform spawnPointFrontArialEnemy;
	public Transform spawnPointBackArialEnemy;
	public Transform spawnPointFrontLandEnemy;
	public Transform spawnPointBackLandEnemy;
	private bool chopperIsFacingFront = true;
	private bool chopperIsFacingBack = false; 
	private bool spawningIsActivated = false; 

	private int menuType; 
	enum kMenuType{kPause,kMissionComplete,kMissionFailed}; 
	
	private ControlsVisibilityScript controlsVisibilityScript;
	private MoveEnemyPositionScript moveEnemyPositionScript;
	private MoveEnemyPositionForAirDrone moveEnemyPositionForAirDroneScript;
	private TankRotateOffsetScript tankRotateOffsetScript;
	
	// Enemy Management
	public static int airdronesCount = 0;
	public static int tanksCount = 0;
	public static int jeepsCount = 0;
	public static int airbuzzerCount = 0;
	public int requiredAirdrones = 1;
	public int requiredTanks = 1;
	public int requiredJeeps = 1;
	public int requireAirBuzzer = 1; 
	
	private float nextAirDroneSpawn; 
	private float nextTankSpawn; 
	private float nextJeepSpawn;
	private float nextAirBuzzerSpawn; 

	private bool haltAddingEnemyDrones = false; 
	public static bool haltAddingEnemyTanks = false;
	private bool haltAddingEnemyJeeps = false;
	private bool haltAddingEnemyBuzzer = false;

	private bool airdroneCountingStarted = false; 

	// Timer and Score
	private Text textTimerMinute; 
	private Text textTimerSeconds; 
	public int MissionTimeInSeconds;
	private TimerScript timerScript; 

	public GameObject joystickLeft;
	public GameObject chopperNoseRotationControl; 

	private float timeScaleValueDuringPause = 1f; 
	public GameObject vitalCriticalAudioHolder; 

	public bool allNukeIsRetrieved = false; 
	public bool chopperIsDestroyed = false;

	// CONFIRMATION MESSAGE
	private string goToMainMenuString = "InvokeGoToMainMenu";
	private string goToNextMissionString = "InvokeGoToNextMission";
	private string restartMissionString = "InvokeRestartB";
	private string mainMenuMessageString = "ARE YOU SURE THAT YOU WANT TO\nRETURN TO THE MAIN MENU?"; 
	private string nextMissionMessageString = "ARE YOU SURE THAT YOU WANT TO\nPLAY THE NEXT MISSION?";
	private string restartMissionMessageString = "ARE YOU SURE THAT YOU WANT TO\nRESTART THE CURRENT MISSION?";

	// SOUND MANAGEMENT
	public GameObject musicManager; 

	private GameObject panelMissionOutcome; 
	private GameObject panelPauseButtonsAndStats;
	private GameObject panelPauseSocialSharing; 

	public enum MissionResult
	{
		MissionCompleted,
		MissionFailed
	}

	public static MissionResult resultInThisMission; 
	public static bool gameIsOver = false; 

	void Start()
	{
		gameIsOver = false; 
		gameManagerStatic = this.gameObject; 

		if (DeviceManager.deviceIsIPad) {
			cameraAdjustment.localPosition = new Vector3(0f,0.7f,-170f);
		} else {
			cameraAdjustment.localPosition = new Vector3(0f,0.7f,-135f); 
		}

		// Reset Enemy counts
		airdronesCount = 0; 
		tanksCount = 0; 
		jeepsCount = 0;
		airbuzzerCount = 0;

		airdroneCountingStarted = false; 

		Physics.IgnoreLayerCollision(17,18, true);
		Invoke("AppearMissionLabels",1f); 
		InvokeFadeIn();
		controlsVisibilityScript = gameObject.GetComponent<ControlsVisibilityScript>();
		Invoke ("FindTextTimerUI",1f);  
		ItemPickerScript.gameIsPaused = false;
		ItemPickerScript.isHoldingNuke = false;
		Invoke("FindPanelMissionOutcome",2f); 
		GameObject airhoundFacebookManager = GameObject.Find("AirHoundFacebookManager(Clone)");
	}

	// Callback Method
	void OnEnable()
	{
		HealthScriptForEnemyDrones.OnEnemyDroneDestroyed += ReduceEnemyDroneQuantity;
		HealthScriptForEnemyClone.OnEnemyTankDestroyed += ReduceEnemyTankQuantity;
		EnemyJeep.OnEnemyJeepDestroyed += ReduceEnemyJeepQuantity;
		EnemyBuzzer.OnEnemyBuzzerDestroyed += ReduceEnemyBuzzerQuantity;
		DespawnByDistance.OnDistanceAwayFromChopper += ReduceEnemyDroneQuantity;
		NoSpawningZoneScript.OnNoSpawnZoneEnter += SpawningDeactivated;
		NoSpawningZoneScript.OnNoSpawnZoneExit += SpawningActivated;
		NoSpawningZoneScript.OnNoSpawnZoneExit += CheckAirdroneQuantity;
	}

	void OnDisable()
	{
		HealthScriptForEnemyDrones.OnEnemyDroneDestroyed -= ReduceEnemyDroneQuantity;
		HealthScriptForEnemyClone.OnEnemyTankDestroyed -= ReduceEnemyTankQuantity;
		EnemyJeep.OnEnemyJeepDestroyed -= ReduceEnemyJeepQuantity;
		EnemyBuzzer.OnEnemyBuzzerDestroyed -= ReduceEnemyBuzzerQuantity;
		DespawnByDistance.OnDistanceAwayFromChopper -= ReduceEnemyDroneQuantity;
		NoSpawningZoneScript.OnNoSpawnZoneEnter -= SpawningDeactivated;
		NoSpawningZoneScript.OnNoSpawnZoneExit -= SpawningActivated;
		NoSpawningZoneScript.OnNoSpawnZoneExit -= CheckAirdroneQuantity;
	}

	void FindTextTimerUI()
	{
		textTimerMinute = GameObject.Find ("TextTimerMinute").GetComponent<Text>(); 
		textTimerSeconds = GameObject.Find ("TextTimerSeconds").GetComponent<Text>();

		timerScript = this.gameObject.GetComponent<TimerScript>();  
		timerScript.CountDownSeconds = MissionTimeInSeconds;
		
		int minuteValue = MissionTimeInSeconds / 60; 
		int secondsValue = MissionTimeInSeconds % 60; 
		
		if (secondsValue < 10) {
			textTimerMinute.text = "0" + minuteValue.ToString(); 
		} else {
			textTimerMinute.text = minuteValue.ToString(); 
		}
		
		if (secondsValue < 10) {
			textTimerSeconds.text = "0" + secondsValue.ToString(); 
		} else {
			textTimerSeconds.text = secondsValue.ToString(); 
		}
	}

	void FindPanelMissionOutcome()
	{
		panelMissionOutcome = GameObject.Find("PanelMissionOutcome(Clone)"); 
		this.gameObject.BroadcastMessage("InitializePanelOutcomeMenus",SendMessageOptions.DontRequireReceiver); 
	}

	void Update()
	{
		if (pause) {
			Time.timeScale = timeScaleValueDuringPause;
		} else {
			Time.timeScale = 1.0f; 
		}

		UpdateAllEnemySpawning(); 
	}

	void AppearMissionLabels()
	{
		//TweenAlpha.Begin(labelMissionNumber,3,1);
		  
	}
	
	void InvokeFadeIn()
	{
		Invoke("FadeOutMissionBG",5);
		Invoke("FadeIn",1);
		Invoke("FadeInMissionLabel",7);
	}
	
	void FadeIn()
	{
//		if(curtain){
//			TweenAlpha.Begin(curtain,1,0);
//		}
	}

	void FadeInMissionLabel()
	{
		//TweenAlpha.Begin(labelMissionNumber,2,0);

	}

	void FadeOutMissionBG()
	{
		//TweenAlpha.Begin(missionIntroFlare,3,0); 
		Invoke("SetPanelMissionIntroInactive",10f); 
	}

	void SetPanelMissionIntroInactive()
	{
		//panelMissionIntro.SetActive(false); 
	}

	void InvokeRestart()
	{
		Invoke("Restart",8);
	}
	
	public void InvokeRestartIn3Sec()
	{
		Invoke("RestartIn3Sec",0.5f);
	}
	
	void InvokePauseGame()
	{
		Invoke("PauseGame",0.5f);
	}
	
	void InvokeCreateEnemyDrone()
	{
		float randomRange = Random.Range(3,5); 
		Invoke("CreateEnemyDrone",randomRange);
	}
	
	void InvokeCreateEnemyTank()
	{
		float randomRange = Random.Range(6,9); 
		Invoke("CreateEnemyTank",randomRange);
	}

	void InvokeRestartB()
	{
		// Hide the Panel Mission Outcome
		ConfigBeforeChangingScene();

		timeScaleValueDuringPause = 1f;
		Invoke("Restart",1.5f);
	}

	void Restart()
	{	 
		ConfigureBeforeGoingToAdScene(); 
	}

	void ConfigureBeforeGoingToAdScene()
	{
		// Hide the Panel Mission Outcome
		this.gameObject.BroadcastMessage(
			"HideThePanelMissionOutcome",SendMessageOptions.DontRequireReceiver
		); // from MissionOutcomeScript2
		this.gameObject.GetComponent<AudioSource>().enabled = false; 
		chopperObject.GetComponent<AudioSource>().enabled = false; 
		DisableMusic(); 
		Application.LoadLevel(adScene); 
	}

	public void InvokeGoToMainMenu()
	{
		Debug.Log("InvokeGoToMainMenu method..."); 

		// Hide the Panel Mission Outcome
		ConfigBeforeChangingScene();

		// Hide the panel pause buttons
		//panelPauseButtons.SetActive(false); 

		// Close the Confirm Message
		//confirmMessageMenu.SetActive(false); 

		timeScaleValueDuringPause = 1f;
		Invoke("GoToMainMenu",1.5f); 

//		if (curtain) {
//			TweenAlpha.Begin(curtain,1f,1f); 		
//		}
	}

	// Returns to the Main Menu
	public void GoToMainMenu()
	{	 
		Debug.Log("GoToMainMenu method...");

//		if (survivalMissionManager) {
//			SurvivalMissionScript.isSurvivalMission = false; 	
//		}

		Application.LoadLevel(mainMenu);
	}

	public void InvokeGoToNextMission()
	{
		// Hide the Panel Mission Outcome
		ConfigBeforeChangingScene(); 

		// Hide the panel pause buttons
		//panelPauseButtons.SetActive(false);

		// Close the Confirm Message
		//confirmMessageMenu.SetActive(false); 

		timeScaleValueDuringPause = 1f;
		Invoke("GoToNextMission",1.5f); 

//		if (curtain) {
//			TweenAlpha.Begin(curtain,1f,1f); 		
//		}
	}

	// Go to Next Mission
	void GoToNextMission()
	{
		if (SceneIndexManager.sceneIndex < 8) {
			SceneIndexManager.sceneIndex += 1;
			ConfigureBeforeGoingToAdScene(); 
		}
	}

	void ConfigBeforeChangingScene()
	{
		this.gameObject.BroadcastMessage("HideThePanelMissionOutcome",SendMessageOptions.DontRequireReceiver); // from MissionOutcomeScript2
		this.gameObject.BroadcastMessage("SaveGameCenterScoresWhenPausedAndGoingToMainMenu",SendMessageOptions.DontRequireReceiver); // from ScoreManagerScript
		this.gameObject.BroadcastMessage("HideAdBanner",SendMessageOptions.DontRequireReceiver); // from iAdsManager_gameplay	
	}

	public void PauseTheGame()
	{
		pause = true; 
		Invoke("SetTimeScaleValueDuringPause",0.5f); 
		controlsVisibilityScript.ControlsNotRequired();
		ItemPickerScript.gameIsPaused = true;
	}

	public void UnPauseTheGame()
	{
		pause = false; 
		timeScaleValueDuringPause = 1.0f; 
		ItemPickerScript.gameIsPaused = false;
	}

	public void InvokeHideGamepadControllers()
	{
		Invoke ("HideGamepadControllers",2f); 
	}

	public void ShowGamepadControllers()
	{
		controlsVisibilityScript.ControlsRequired (); 
	}

	public void HideGamepadControllers()
	{
		controlsVisibilityScript.ControlsNotRequired(); 
	}

	public void DisplayControlsAndHud()
	{
		controlsVisibilityScript.ControlsRequired();
	}

	void AudioSettingsPaused()
	{
		if (PlayerPrefs.HasKey("MusicVolume")) {
			if (PlayerPrefs.GetFloat("MusicVolume") <= 0.2f) {
				musicManager.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume"); 
			} else {
				musicManager.GetComponent<AudioSource>().volume = 0.2f; 
			}
		}

		if (chopperObject) {
			chopperObject.GetComponent<AudioSource>().enabled = false;	
		}
		if (vitalCriticalAudioHolder) {
			vitalCriticalAudioHolder.GetComponent<AudioSource>().enabled = false; 	
		}
	}

	void AudioSettingsResumed()
	{
		if (PlayerPrefs.HasKey("MusicVolume")) {
			if (PlayerPrefs.GetFloat("MusicVolume") >= 0.8f) {
				musicManager.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume"); 
			} else {
				musicManager.GetComponent<AudioSource>().volume = 0.8f; 
			}
		}

		if (chopperObject) {
			chopperObject.GetComponent<AudioSource>().enabled = true;
		}
		if (vitalCriticalAudioHolder) {
			vitalCriticalAudioHolder.GetComponent<AudioSource>().enabled = true;
		}
	}

	void SetTimeScaleValueDuringPause()
	{
		timeScaleValueDuringPause = 0.0f; 
	}

	void ShowPauseMenu()
	{
//		if (curtain) {
//			TweenAlpha.Begin(curtain,0.5f,0.35f);
//		}
//
//		panelPauseButtons.SetActive(true); 
	}
	
	void HidePauseMenu()
	{
		//CurtainFadeOut(); 
		//panelPauseButtons.SetActive(false); 
	}

	public void InvokeShowMissionCompleteMenu()
	{ 
		Invoke("ShowMissionCompleteMenu",3f); 
	}

	void ShowMissionCompleteMenu()
	{
		allNukeIsRetrieved = true; 
		controlsVisibilityScript.ControlsNotRequired();
		AudioSettingsPaused(); 
		gameObject.BroadcastMessage("MissionCompleteEnter",SendMessageOptions.DontRequireReceiver); // Method found in MissionOutcomeScript2 class	
	}

	public void InvokeShowMissionFailedMenu()
	{
		Invoke("ShowMissionFailedMenu",2f); 
	}

	void ShowMissionFailedMenu()
	{
		pause = true; 
		chopperIsDestroyed = true;
		controlsVisibilityScript.ControlsNotRequired();
		AudioSettingsPaused(); 
		gameObject.BroadcastMessage("MissionFailedEnter","Time has run out",SendMessageOptions.DontRequireReceiver); // Method can be found in MissionOutcomeScript2 class
	}

	public void InvokeShowMissionFailedDestroyedMenu()
	{
		Invoke("ShowMissionFailedDestroyedMenu",2f); 
	}
	
	void ShowMissionFailedDestroyedMenu()
	{
		pause = true; 
		chopperIsDestroyed = true;
		controlsVisibilityScript.ControlsNotRequired();
		AudioSettingsPaused(); 
		
//		if (curtain) {
//			TweenAlpha.Begin(curtain,0.5f,0.55f);	
//		}
		
		//gameObject.BroadcastMessage("MissionFailedEnter","You have been destroyed",SendMessageOptions.DontRequireReceiver); // Method can be found in MissionOutcomeScript2 class
	}

	public void SetChopperIsNotDestroyed()
	{
		chopperIsDestroyed = false; 		
	}
	
	// SPAWNING OF ENEMIES

	void UpdateAllEnemySpawning()
	{
		if (airdronesCount == 0) {
			haltAddingEnemyDrones = false;
		}

		if (tanksCount == 0) {
			haltAddingEnemyTanks = false; 	
		}

		if (jeepsCount == 0) {
			haltAddingEnemyJeeps = false; 	
		}

		if (airbuzzerCount == 0) {
			haltAddingEnemyBuzzer = false; 	
		}

		if (spawningIsActivated) {
			UpdateEnemyDroneSpawning(); // for airdrones
			UpdateEnemyTankSpawning(); // for tanks
			UpdateEnemyJeepSpawning(); // for jeeps
			UpdateEnemyBuzzerSpawning(); // for airbuzzers
		}
	}
	
	// NEW AIRDRONE CREATION
	void ReduceEnemyDroneQuantity()
	{
		airdronesCount--;
		CheckAirdroneQuantity ();
	}

	void CheckAirdroneQuantity()
	{
		if (airdronesCount <= 0) {
			UpdateEnemyDroneSpawnTimeRestart ();
		}
	}
		
	void UpdateEnemyDroneSpawning()
	{
		if (Time.time > nextAirDroneSpawn) {
			AddEnemyDrone();
		}
	}

	void AddEnemyDrone()
	{
		if (!haltAddingEnemyDrones) {
			if (airdronesCount < requiredAirdrones) {
				CreateAnEnemyDrone(); 			
			}	
		}
	}

	void CreateAnEnemyDrone()
	{
		int randomNumber = Random.Range(0,enemyDrones.Length);
		GameObject randomDrone = enemyDrones[randomNumber];

		Transform clone;
		if (chopperIsFacingFront) {
			if (spawnPointFrontArialEnemy) {
				clone = PoolManager.Pools["Enemies"].Spawn(randomDrone.transform, spawnPointFrontArialEnemy.position, spawnPointFrontArialEnemy.rotation);
				moveEnemyPositionForAirDroneScript = clone.GetComponent<MoveEnemyPositionForAirDrone>();
				moveEnemyPositionForAirDroneScript.translateX = -1;
				clone.position = new Vector3(spawnPointFrontArialEnemy.position.x,this.GetRandomYValue(0,4.5f),0); 
			}
		}
		else {
			if (spawnPointBackArialEnemy) {
				clone = PoolManager.Pools["Enemies"].Spawn(randomDrone.transform, spawnPointBackArialEnemy.position, spawnPointBackArialEnemy.rotation); 
				moveEnemyPositionForAirDroneScript = clone.GetComponent<MoveEnemyPositionForAirDrone>();
				moveEnemyPositionForAirDroneScript.translateX = 1;
				clone.position = new Vector3(spawnPointBackArialEnemy.position.x,this.GetRandomYValue(0,4.5f),0);
			}
		}

		airdronesCount++;
		if (airdronesCount == requiredAirdrones) {
			haltAddingEnemyDrones = true; 	
		} else {
			UpdateEnemyDroneSpawnTime(); 
		}
	}

	float GetRandomYValue(float min,float max)
	{
		return Random.Range (min,max); 
	}

	void UpdateEnemyDroneSpawnTime()
	{
		int spawnRate = Random.Range(4,7);
		nextAirDroneSpawn = (int)(Time.time + spawnRate);
	}

	public void UpdateEnemyDroneSpawnTimeRestart()
	{
		int spawnRate = Random.Range(8,10);
		nextAirDroneSpawn = (int)(Time.time + spawnRate);
	}
	
	// SPAWNING FOR BUZZERS
	void ReduceEnemyBuzzerQuantity()
	{
		airbuzzerCount--;
		CheckEnemyBuzzerQuantity ();
	}

	void CheckEnemyBuzzerQuantity()
	{
		if (airbuzzerCount <= 0) {
			UpdateEnemyBuzzerSpawnTimeRestart ();
		}
	}

	// Called on Update()
	void UpdateEnemyBuzzerSpawning()
	{
		if (Time.time > nextAirBuzzerSpawn) {
			AddEnemyBuzzer();
		}
	}
	
	void AddEnemyBuzzer()
	{
		if (!haltAddingEnemyBuzzer) {
			if (airbuzzerCount < requireAirBuzzer) {
				CreateAnEnemyBuzzer(); 			
			}	
		}
	}
	
	void CreateAnEnemyBuzzer()
	{
		Transform clone; 
		if (chopperIsFacingFront) {
			if (spawnPointFrontArialEnemy) {
				clone = PoolManager.Pools["Enemies"].Spawn(enemyBuzzer.transform, spawnPointFrontArialEnemy.position, spawnPointFrontArialEnemy.rotation);
				moveEnemyPositionForAirDroneScript = clone.GetComponent<MoveEnemyPositionForAirDrone>();
				moveEnemyPositionForAirDroneScript.translateX = -1;
				tankRotateOffsetScript = clone.GetComponent<TankRotateOffsetScript>(); 
				tankRotateOffsetScript.SetRotateYOffset(-25); 
				clone.position = new Vector3(spawnPointFrontArialEnemy.position.x,this.GetRandomYValue(0,6.4f),0); 
			}
		}
		else {
			if (spawnPointBackArialEnemy) {
				clone = PoolManager.Pools["Enemies"].Spawn(enemyBuzzer.transform, spawnPointBackArialEnemy.position, spawnPointBackArialEnemy.rotation);
				moveEnemyPositionForAirDroneScript = clone.GetComponent<MoveEnemyPositionForAirDrone>();
				moveEnemyPositionForAirDroneScript.translateX = 1;
				tankRotateOffsetScript = clone.GetComponent<TankRotateOffsetScript>();
				tankRotateOffsetScript.SetRotateYOffset(-225);
				clone.position = new Vector3(spawnPointBackArialEnemy.position.x,this.GetRandomYValue(0,6.4f),0);
			}
		}
		
		airbuzzerCount++;
		if (airbuzzerCount == requireAirBuzzer) {
			haltAddingEnemyBuzzer = true; 	
		} else {
			UpdateEnemyBuzzerSpawnTime(); 
		}
	}
	
	void UpdateEnemyBuzzerSpawnTime()
	{
		int spawnRate = Random.Range(3,4); 
		nextAirBuzzerSpawn = (int)(Time.time + spawnRate);
	}

	public void UpdateEnemyBuzzerSpawnTimeRestart()
	{
		int spawnRate = Random.Range(5,8);
		nextAirBuzzerSpawn = (int)(Time.time + spawnRate);
	}

	// NEW TANKS CREATION
	void ReduceEnemyTankQuantity()
	{
		tanksCount--;
		CheckTankQuantity ();
	}

	void CheckTankQuantity()
	{
		if (tanksCount <= 0) {
			UpdateEnemyTankSpawnTimeRestart ();
		}
	}

	// Called on Update()
	void UpdateEnemyTankSpawning()
	{
		if (Time.time > nextTankSpawn) {
			AddEnemyTank();
		}
	}
	
	void AddEnemyTank()
	{
		if (!haltAddingEnemyTanks) {
			if (tanksCount < requiredTanks) {
				CreateAnEnemyTank(); 			
			}	
		}
	}
	
	void CreateAnEnemyTank()
	{
		string tank1 = "enemyTank1"; 
		string tank2 = "enemyTank2";
		string tank3 = "enemyTank3";

		int randomNumber = Random.Range(0,enemyTanks.Length);
		GameObject randomTank = enemyTanks[randomNumber];
		
		Transform clone; 
		
		// Tanks going left
		if (chopperIsFacingFront) {	
			
			clone = PoolManager.Pools["Enemies"].Spawn(randomTank.transform, spawnPointFrontLandEnemy.position, spawnPointFrontLandEnemy.rotation);
			
			moveEnemyPositionScript = clone.GetComponent<MoveEnemyPositionScript>();
			tankRotateOffsetScript = clone.GetComponent<TankRotateOffsetScript>(); 

			tankRotateOffsetScript.SetRotateYOffset(-25); 

			string tankName = clone.name;
			if (tankName.Contains(tank1)) {
				moveEnemyPositionScript.translateX = -1;
				moveEnemyPositionScript.smooth = 1f; 
			}
			else if (tankName.Contains(tank2)) {
				moveEnemyPositionScript.translateX = -1;
				moveEnemyPositionScript.smooth = 0.7f; 
			}
			else if (tankName.Contains(tank3)) {
				moveEnemyPositionScript.translateX = -1;
				moveEnemyPositionScript.smooth = 1.3f; 
			}
		}
		
		// Tanks going right
		else {
			clone = PoolManager.Pools["Enemies"].Spawn(randomTank.transform, spawnPointBackLandEnemy.position, spawnPointBackLandEnemy.rotation);
			
			moveEnemyPositionScript = clone.GetComponent<MoveEnemyPositionScript>();
			tankRotateOffsetScript = clone.GetComponent<TankRotateOffsetScript>();

			tankRotateOffsetScript.SetRotateYOffset(-155); 

			string tankName = clone.name;
			if (tankName.Contains(tank1)) {
				moveEnemyPositionScript.translateX = 1;
				moveEnemyPositionScript.smooth = 1f; 
			}
			else if (tankName.Contains(tank2)) {
				moveEnemyPositionScript.translateX = 1;
				moveEnemyPositionScript.smooth = 0.7f; 
			}
			else if (tankName.Contains(tank3)) {
				moveEnemyPositionScript.translateX = 1;
				moveEnemyPositionScript.smooth = 1.3f; 
			}

		}
		
		tanksCount++;
		if (tanksCount == requiredTanks) {
			haltAddingEnemyTanks = true; 	
		} 

		else {
			UpdateEnemyTankSpawnTime(); 
		}
	}
	
	void UpdateEnemyTankSpawnTime()
	{
		int spawnRate = Random.Range(6,8);
		nextTankSpawn = (int)(Time.time + spawnRate);
	}

	public void UpdateEnemyTankSpawnTimeRestart()
	{
		int spawnRate = Random.Range(6,8);
		nextTankSpawn = (int)(Time.time + spawnRate);
	}

	// NEW JEEPS CREATION
	void ReduceEnemyJeepQuantity()
	{
		jeepsCount--;
		CheckEnemyJeepQuantity ();
	}

	void CheckEnemyJeepQuantity()
	{
		if (jeepsCount <= 0) {
			UpdateEnemyJeepSpawnTimeRestart ();
		}
	}
		
	// Called every Update()
	void UpdateEnemyJeepSpawning()
	{
		if (Time.time > nextJeepSpawn) {
			AddEnemyJeep();
		}
	}
	
	void AddEnemyJeep()
	{
		if (!haltAddingEnemyJeeps) {
			if (jeepsCount < requiredJeeps) {
				CreateAnEnemyJeep(); 			
			}	
		}
	}
	
	void CreateAnEnemyJeep()
	{
		int randomNumber = Random.Range(0,enemyJeeps.Length);
		GameObject randomJeep = enemyJeeps[randomNumber]; 
		Transform clone;
		
		// Jeeps going right
		if (chopperIsFacingFront) {	
			clone = PoolManager.Pools["Enemies"].Spawn(randomJeep.transform, spawnPointBackLandEnemy.position, spawnPointBackLandEnemy.rotation);
			
			moveEnemyPositionScript = clone.GetComponent<MoveEnemyPositionScript>();
			tankRotateOffsetScript = clone.GetComponent<TankRotateOffsetScript>(); 

			tankRotateOffsetScript.SetRotateYOffset(-155); 
			moveEnemyPositionScript.translateX = 2;
			moveEnemyPositionScript.smooth = 1.2f; 
		}
		
		// Jeeps going left
		else {
			clone = PoolManager.Pools["Enemies"].Spawn(randomJeep.transform, spawnPointFrontLandEnemy.position, spawnPointFrontLandEnemy.rotation);
			
			moveEnemyPositionScript = clone.GetComponent<MoveEnemyPositionScript>();
			tankRotateOffsetScript = clone.GetComponent<TankRotateOffsetScript>(); 

			tankRotateOffsetScript.SetRotateYOffset(-25); 
			moveEnemyPositionScript.translateX = -2;
			moveEnemyPositionScript.smooth = 1.2f; 
		}
		
		jeepsCount++;
		if (jeepsCount == requiredJeeps) {
			haltAddingEnemyJeeps = true; 	
		} 
		
		else {
			UpdateEnemyJeepSpawnTime(); 
		}
	}
	
	void UpdateEnemyJeepSpawnTime()
	{
		int spawnRate = Random.Range(5,7);
		nextJeepSpawn = (int)(Time.time + spawnRate);
	}

	public void UpdateEnemyJeepSpawnTimeRestart()
	{
		int spawnRate = Random.Range(6,10);
		nextJeepSpawn = (int)(Time.time + spawnRate);
	}


	// CHOPPER ORIENTATION

	void ChopperFacesFront()
	{
		chopperIsFacingFront = true;
		chopperIsFacingBack = false; 
		joystickLeft.SendMessage("ChopperIsFacingFront",SendMessageOptions.DontRequireReceiver); 
		chopperNoseRotationControl.SendMessage("ChopperIsFacingFront",SendMessageOptions.DontRequireReceiver); 
	}
	
	void ChopperFacesBack()
	{
		chopperIsFacingFront = false;
		chopperIsFacingBack = true; 
		joystickLeft.SendMessage("ChopperIsFacingBack",SendMessageOptions.DontRequireReceiver);
		chopperNoseRotationControl.SendMessage("ChopperIsFacingBack",SendMessageOptions.DontRequireReceiver);
	}
	
	public void SpawningActivated()
	{
		spawningIsActivated = true; 
	}
	
	public void SpawningDeactivated()
	{
		spawningIsActivated = false; 
	}

	public void DisplayPanelPauseElements()
	{
		if (panelPauseButtonsAndStats == null) {
			panelPauseButtonsAndStats = GameObject.Find("PanelPauseButtonsAndStats");
			panelPauseButtonsAndStats.SetActive(true); 
		} else {
			panelPauseButtonsAndStats.SetActive(true);
		}

		if (panelPauseSocialSharing == null) {
			panelPauseSocialSharing = GameObject.Find("PanelPauseSocialSharing");
			panelPauseSocialSharing.SetActive(true); 
		} else {
			panelPauseSocialSharing.SetActive(true);
		}
	}

	public void HidePanelPauseElements()
	{
		if (panelPauseButtonsAndStats == null) {
			panelPauseButtonsAndStats = GameObject.Find("PanelPauseButtonsAndStats");
			panelPauseButtonsAndStats.SetActive(false); 
		} else {
			panelPauseButtonsAndStats.SetActive(false);
		}
		
		if (panelPauseSocialSharing == null) {
			panelPauseSocialSharing = GameObject.Find("PanelPauseSocialSharing");
			panelPauseSocialSharing.SetActive(false); 
		} else {
			panelPauseSocialSharing.SetActive(false);
		}
	}

//	public void OpenConfirmMessageByPauseMenu()
//	{
//		menuType = 1;  
//		buttonYesButtonMessageScript.functionName = goToMainMenuString;
//		confirmMessageLabelScript.text = mainMenuMessageString;
//		confirmMessageMenu.SetActive(true);
//	}
//
//	public void OpenConfirmMessageByMissionCompleteMenu()
//	{
//		menuType = 2; 
//		this.gameObject.BroadcastMessage("HideNavigationButtons",SendMessageOptions.DontRequireReceiver); // from MissionOutcomeScript2
//		buttonYesButtonMessageScript.functionName = goToMainMenuString;
//		confirmMessageLabelScript.text = mainMenuMessageString;
//		confirmMessageMenu.SetActive(true); 
//	}
//
//	public void OpenConfirmMessageByMissionFailedMenu()
//	{
//		menuType = 3; 
//		gameObject.BroadcastMessage("HideMissionFailedOutcome");
//		confirmMessageLabelScript.text = mainMenuMessageString;
//		buttonYesButtonMessageScript.functionName = goToMainMenuString;
//		confirmMessageMenu.SetActive(true); 
//	}

//	public void OpenConfirmMessageByNextMissionButton()
//	{
//		menuType = 2;
//		this.gameObject.BroadcastMessage("HideNavigationButtons",SendMessageOptions.DontRequireReceiver); // from MissionOutcomeScript2
//		confirmMessageLabelScript.text = nextMissionMessageString; 
//		buttonYesButtonMessageScript.functionName = goToNextMissionString;
//		confirmMessageMenu.SetActive(true); 
//	}
//
//	public void OpenConfirmMessageByRestart()
//	{
//		menuType = 1;  
//		buttonYesButtonMessageScript.functionName = restartMissionString;
//		confirmMessageLabelScript.text = restartMissionMessageString;
//		confirmMessageMenu.SetActive(true);
//	}
//
//	public void OpenConfirmMessageByRestartDuringMissionOutcome()
//	{
//		menuType = 2; 
//		this.gameObject.BroadcastMessage("HideNavigationButtons",SendMessageOptions.DontRequireReceiver); // from MissionOutcomeScript2
//		buttonYesButtonMessageScript.functionName = restartMissionString;
//		confirmMessageLabelScript.text = restartMissionMessageString;
//		confirmMessageMenu.SetActive(true);
//	}

//	public void OpenConfirmMessageByRestartDuringMissionFailed()
//	{
//		menuType = 3; 
//		buttonYesButtonMessageScript.functionName = restartMissionString;
//		confirmMessageLabelScript.text = restartMissionMessageString;
//		confirmMessageMenu.SetActive(true);
//	}

	public void OpenGameOptions()
	{ 
		//panelGameOptionsGroup.SetActive(true);
		HidePanelPauseElements(); 
	}

	public void CloseGameOptions()
	{  
		DisplayPanelPauseElements();
		//panelGameOptionsGroup.SetActive(false);
	}

	public void CloseConfirmMessage()
	{
		switch (menuType) {
			case 1:
			{
				DisplayPanelPauseElements(); 
				//confirmMessageMenu.SetActive(false);	
				break;
			}

			case 2:
			{
				this.gameObject.BroadcastMessage("DisplayNavigationButtons",SendMessageOptions.DontRequireReceiver); // from MissionOutcomeScript2
				//confirmMessageMenu.SetActive(false);	
				break;
			}

			case 3:
			{
				this.gameObject.BroadcastMessage("DisplayNavigationButtons",SendMessageOptions.DontRequireReceiver); // from MissionOutcomeScript2
				//confirmMessageMenu.SetActive(false);	
				break;
			}

			default:
				break;
		}
	}

	public void HideThePanelMissionOutcome()
	{
		panelMissionOutcome.SetActive(false); 
	}

	public void SavePreferences()
	{
		PlayerPrefs.Save(); 
	}

	public void EnableMusic()
	{
		musicManager.GetComponent<AudioSource>().Play(); 
	}

	public void DisableMusic()
	{
		musicManager.GetComponent<AudioSource>().Pause();
	}

	public void DisableChopperSound()
	{
		chopperObject.GetComponent<AudioSource>().enabled = false; 
	}
}
