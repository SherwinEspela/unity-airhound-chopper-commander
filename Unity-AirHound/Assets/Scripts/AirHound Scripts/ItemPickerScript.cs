using UnityEngine;
using System.Collections;

public class ItemPickerScript : MonoBehaviour {
	
	public GameObject chopperMain; 
	private GameObject gameManager;
	private GameObject chopperHealthCollider; 
	private Transform nukeCrate;
	private GameObject nukeCrateGroup;
	private GameObject nukeCrateOnly;
	private Transform dropZone;
	public Transform pickedNukeCollector; 
	//private Transform nukeHealthCol;

	public Transform deliveryTruck;
	public Transform truckWheel1;
	public Transform truckWheel2;
	public Transform truckWheel3;
	public Transform truckWheel4;

	private GameObject nukePickerCollider; 
	private float liftForce = 4f; 
	private bool pickerIsLowered = false;
	private bool nukeIsPicked = false;
	private bool readyToDrop = false;
	private bool nukeIsDropped = false;
	public static bool isHoldingNuke = false;
	
	public GameObject hatchRight; 
	public GameObject hatchLeft;
	public AnimationClip hatchRightOpenClip;
	public AnimationClip hatchRightCloseClip;
	public AnimationClip hatchLeftOpenClip;
	public AnimationClip hatchLeftCloseClip;
	private bool hatchIsOpen = false; 

	private MoveEnemyPositionScript moveEnemyPositionScript;
	private WheelRotation wheelRotation1; 
	private WheelRotation wheelRotation2; 
	private WheelRotation wheelRotation3; 
	private WheelRotation wheelRotation4; 
	public GameObject deliveryTruckZone; 

	// Character Controller
	private CharacterController chopperCharacterCtrl; 
	private Vector3 characterCtrlCenterVector3Normal = new Vector3(-2.12f,0.41f,0.71f);  
	private float characterCtrlHeightNormal = 2.11f;
	private Vector3 characterCtrlCenterVector3WithNuke = new Vector3(-2.12f,-0.19f,0.71f);
	private float characterCtrlHeightWithNuke = 3.15f;

	private GameObject nukeMessage;
	private GameObject nukeFXHolder; 
	public GameObject dropMessage;
	private GameObject nukeDamageCollider1; 
	private GameObject nukeDamageCollider2; 
	private bool nukeDetected = false;
	public GameObject dropZoneObject; 

	public AudioClip hatchOpeningAudio; 
	public AudioClip nukePickedAudio;
	public AudioClip nukeDroppedAudio; 

	public GameObject laserPointerGroup;
	public static bool laserIsOn = false;

	public static bool gameIsPaused; 

	public GameObject survivalMissionManager;  

	private float bonusHealthNukePick = 15f;
	private float bonusRocketNukePick = 5f;
	private float bonusHealthNukeDrop = 35f; 

	private const float displayPanelIncreaseDelay = 1f; 

	void Start()
	{
		gameManager = GameObject.Find("GameManager");
		chopperHealthCollider = GameObject.Find("chopper_healthCollider");
		GetComponent<Rigidbody>().useGravity = false;
		nukePickerCollider = GameObject.Find("itemPickerCollider");
		nukePickerCollider.GetComponent<Collider>().enabled = false; 

		moveEnemyPositionScript = deliveryTruck.GetComponent<MoveEnemyPositionScript>();
		wheelRotation1 = truckWheel1.GetComponent<WheelRotation>();
		wheelRotation2 = truckWheel2.GetComponent<WheelRotation>();
		wheelRotation3 = truckWheel3.GetComponent<WheelRotation>();
		wheelRotation4 = truckWheel4.GetComponent<WheelRotation>();

		chopperCharacterCtrl = chopperMain.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit; 
		Ray nukeCrateRay = new Ray(transform.position, Vector3.down);
		
		if (!pickerIsLowered) {
			if (Physics.Raycast(nukeCrateRay, out hit)) {
				if (hit.collider.name == "NukeCrate") {

					if (!isHoldingNuke) {
						 
						laserPointerGroup.SetActive(false); 

						nukeCrate = hit.collider.transform;
						SurvivalMissionScript.nukeCrateRotation = nukeCrate.localRotation;

						nukeCrateOnly = nukeCrate.gameObject;
						Transform nukeCrateGroupTransform = nukeCrate.root; 
						nukeCrateGroup = nukeCrateGroupTransform.gameObject;

						nukeMessage = nukeCrateGroup.transform.Find("nukeMessage").gameObject;
						nukeFXHolder = nukeCrateGroup.transform.Find("nukeFXHolder").gameObject;
						nukeDamageCollider1 = nukeCrateGroup.transform.Find("damageCollider1").gameObject;
						nukeDamageCollider2 = nukeCrateGroup.transform.Find("damageCollider2").gameObject;

						HatchOpen(); 
						if (!gameIsPaused) {
							GetComponent<Rigidbody>().useGravity = true;	
						} else {
							GetComponent<Rigidbody>().useGravity = false; 
						}

						if (nukeMessage) {
							nukeMessage.SetActive(false);	
						}
					}


				} 
				
				else if (hit.collider.name == "DropZone") {
					if (readyToDrop) {
						dropZone = hit.collider.transform; 
						if (!gameIsPaused) {
							GetComponent<Rigidbody>().useGravity = true;	
						} else {
							GetComponent<Rigidbody>().useGravity = false; 
						}

						dropMessage.SetActive(false); 
					}
				} 
				
				else {
					AddUpwardForce();
					if (nukeDetected) {
						if (nukeMessage) {
							nukeMessage.SetActive(true);
						}
						if (isHoldingNuke) {
							dropMessage.SetActive(true);
						}
					}
				}
			} 	
		}
		
		if (nukeIsPicked) {
			AddUpwardForce(); 
		}
		
		if (nukeIsDropped) {
			AddUpwardForce();
		}
	}
	
	void OnCollisionEnter(Collision col)
	{
		if (col.transform.name == "NukeCrate") {

			string nukeCrateMainName = col.transform.parent.name; 
			gameManager.SendMessage("HideNukeIndicator",nukeCrateMainName,SendMessageOptions.DontRequireReceiver); // from ProgressBarManager.cs

			GetComponent<AudioSource>().PlayOneShot(nukePickedAudio); 
			nukeFXHolder.SendMessage("ShowNukeEffects",SendMessageOptions.DontRequireReceiver);

			pickerIsLowered = true; 
			nukeCrate.parent = this.transform; 
			nukeFXHolder.transform.parent = this.transform; 
			GetComponent<Rigidbody>().useGravity = false;
			nukePickerCollider.GetComponent<Collider>().enabled = true; 
			nukeIsPicked = true;
			isHoldingNuke = true; 

			chopperHealthCollider.SendMessage("AddHealth",bonusHealthNukePick);
			if (bonusHealthNukePick > 1.0f) {
				int bonusHealthInt = (int)(bonusHealthNukePick);
				string rewardString = "+" + bonusHealthInt + " ARMOUR";
				gameManager.SendMessage("DisplayRewards",rewardString,SendMessageOptions.DontRequireReceiver);	
			}

			gameManager.SendMessage("AddRocketInventory",bonusRocketNukePick,SendMessageOptions.DontRequireReceiver);

			gameManager.SendMessage("SetTextHealthIncrease",bonusHealthNukePick.ToString(),SendMessageOptions.DontRequireReceiver); // from ControlsVisibilityScript.cs
			gameManager.SendMessage("SetTextRocketIncrease",bonusRocketNukePick.ToString(),SendMessageOptions.DontRequireReceiver); // from ControlsVisibilityScript.cs

			chopperCharacterCtrl.center = characterCtrlCenterVector3WithNuke;
			chopperCharacterCtrl.height = characterCtrlHeightWithNuke;

			if (SurvivalMissionScript.isSurvivalMission) {
				nukeCrateGroup.SetActive(false); 
			} else {
				Destroy(nukeMessage);
				Destroy(nukeDamageCollider1);
				Destroy(nukeDamageCollider2);
			}
			dropMessage.SetActive(true);
			dropZoneObject.SetActive(true); 

			gameManager.SendMessage("InvokeDisplayEventMessage","RETURN TO BASE");
			gameManager.SendMessage("ShowImageDirectionArrowBackward",SendMessageOptions.DontRequireReceiver); // from ControlsVisibilityScript.cs

			Invoke("ShowPanelIncrease",displayPanelIncreaseDelay);
		}
		
		else if (col.transform.name == "itemPickerCollider") {
			pickerIsLowered = false; 
			nukeIsPicked = false; 
			readyToDrop = true;
			nukeCrate.GetComponent<Collider>().enabled = false; 
		}
		
		else if (col.transform.name == "itemPickerColliderInChopper") {
			pickerIsLowered = false; 
			nukeIsPicked = false; 
			readyToDrop = false;
			nukeIsDropped = false;
			HatchClose();
		}
		
		else if (col.transform.name == "DropZone") {

			nukeFXHolder.SendMessage("ShowNukeEffects",SendMessageOptions.DontRequireReceiver);

			readyToDrop = false;
			nukeIsDropped = true; 
			nukeCrate.parent = deliveryTruck;
			nukeFXHolder.transform.parent = deliveryTruck; 

			nukePickerCollider.GetComponent<Collider>().enabled = false;
			deliveryTruckZone.SendMessage("SetNukeIsDropped"); 

			if (SurvivalMissionScript.isSurvivalMission) {
				nukeCrateGroup.SetActive(true); 
				SurvivalMissionScript.nukeCrateGroup = nukeCrateGroup.transform; 
			} else {
				nukeCrateGroup.transform.parent = pickedNukeCollector; 
				nukeCrateGroup.transform.localPosition = new Vector3(0f,0f,0f);
			}

			isHoldingNuke = false;

			if (SurvivalMissionScript.isSurvivalMission) {
				gameManager.SendMessage("IncreaseItemsRetrieved");
				gameManager.SendMessage("SetTheTimerIn3Minutes");
				int survivalMissionPoints = 0;

				if (SurvivalMissionScript.pickedNukeAtZone1) {
					survivalMissionPoints = 500; 
				}

				else if (SurvivalMissionScript.pickedNukeAtZone2) {
					survivalMissionPoints = 2000;
				}

				else if (SurvivalMissionScript.pickedNukeAtZone3) {
					survivalMissionPoints = 5000; 
				}

				gameObject.BroadcastMessage("AddPointsSurvivalMission",survivalMissionPoints,SendMessageOptions.DontRequireReceiver);

				SurvivalMissionScript.pickedNukeAtZone1 = false;
				SurvivalMissionScript.pickedNukeAtZone2 = false;
				SurvivalMissionScript.pickedNukeAtZone3 = false;
			}

			else {
				gameManager.SendMessage("DecreaseItemsRetrived");
				gameObject.BroadcastMessage("AddPoints",SendMessageOptions.DontRequireReceiver);
			}

			chopperHealthCollider.SendMessage("AddHealth",bonusHealthNukeDrop);
			if (bonusHealthNukeDrop > 1.0f) {
				int bonusHealthInt = (int)(bonusHealthNukeDrop);
				string rewardString = "+" + bonusHealthInt + " ARMOUR";
				gameManager.SendMessage("DisplayRewards",rewardString,SendMessageOptions.DontRequireReceiver);	
			}
			gameManager.SendMessage("ReplenishRocketInventory",SendMessageOptions.DontRequireReceiver); // from WeaponsInventoryScript.cs

			gameManager.SendMessage("SetTextHealthIncrease",bonusHealthNukeDrop.ToString(),SendMessageOptions.DontRequireReceiver); // from ControlsVisibilityScript.cs
			gameManager.SendMessage("SetTextRocketIncrease","10",SendMessageOptions.DontRequireReceiver); // from ControlsVisibilityScript.cs

			chopperCharacterCtrl.center = characterCtrlCenterVector3Normal;
			chopperCharacterCtrl.height = characterCtrlHeightNormal;

			GetComponent<AudioSource>().PlayOneShot(nukePickedAudio); 

			dropMessage.SetActive(false); 
			dropZoneObject.SetActive(false); 
			Invoke("MoveTheTruck",0.4f); 
			 
			gameManager.SendMessage("InvokePlayNukeSecuredChatter",SendMessageOptions.DontRequireReceiver);
			gameManager.SendMessage("InvokeDisplayEventMessageWithNukeNumber",SendMessageOptions.DontRequireReceiver);

			// Called in ScoreManagerScript class
			gameManager.SendMessage("AddPointsToNukesExtracted",SendMessageOptions.DontRequireReceiver);

			laserIsOn = false; 

			gameManager.SendMessage("ShowImageDirectionArrowForward",SendMessageOptions.DontRequireReceiver); // from ControlsVisibilityScript.cs
			Invoke("ShowPanelIncrease",displayPanelIncreaseDelay); 
		} 
	}

	void ShowPanelIncrease()
	{
		gameManager.SendMessage("ShowPanelIncrease",SendMessageOptions.DontRequireReceiver); // from ControlsVisibilityScript.cs
	}

	void AddUpwardForce()
	{
		GetComponent<Rigidbody>().useGravity = false;
		if (!gameIsPaused) {
			GetComponent<Rigidbody>().AddForce(Vector3.up * liftForce);	
		} 
	}
	
	void HatchOpen()
	{
		if (!hatchIsOpen) {
			hatchRight.GetComponent<Animation>().Play(hatchRightOpenClip.name);
			hatchLeft.GetComponent<Animation>().Play(hatchLeftOpenClip.name);
			GetComponent<AudioSource>().PlayOneShot(hatchOpeningAudio); 
			hatchIsOpen = true; 
		}
	}
	
	void HatchClose()
	{
		if (hatchIsOpen) {
			hatchRight.GetComponent<Animation>().Play(hatchRightCloseClip.name);
			hatchLeft.GetComponent<Animation>().Play(hatchLeftCloseClip.name);
			hatchIsOpen = false;

			if (laserIsOn) {
				laserPointerGroup.SetActive(true); 
			}
		}
	}

	void MoveTheTruck() 
	{
		moveEnemyPositionScript.enabled = true; 
		wheelRotation1.enabled = true; 
		wheelRotation2.enabled = true; 
		wheelRotation3.enabled = true; 
		wheelRotation4.enabled = true; 
	}

	public void SetNukeIsDetected()
	{
		nukeDetected = true; 
	}

	public void SetNukeIsNotDetected()
	{
		nukeDetected = false; 
	}

	void SetNukeCrateGroupInactive()
	{
		nukeCrateGroup.SetActive(false); 
	}
}
