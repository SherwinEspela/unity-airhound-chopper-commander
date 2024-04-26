using UnityEngine;
using System.Collections;

public class DeliveryTruck : MonoBehaviour {

	public Transform deliveryTruck;
	public Transform truckWheel1;
	public Transform truckWheel2;
	public Transform truckWheel3;
	public Transform truckWheel4;

	private MoveEnemyPositionScript moveEnemyPositionScript;
	private WheelRotation wheelRotation1; 
	private WheelRotation wheelRotation2; 
	private WheelRotation wheelRotation3; 
	private WheelRotation wheelRotation4; 

	private Transform nukeCrate; 
	private Transform nukeFXHolder; 
	private Vector3 initialPosition; 
	private bool nukeIsDroppped = false; 

	private GameObject gameManager; 
	public Transform pickedNukeCollector; 

	public GameObject survivalMissionManager; 

	void Start()
	{
		moveEnemyPositionScript = deliveryTruck.GetComponent<MoveEnemyPositionScript>();
		wheelRotation1 = truckWheel1.GetComponent<WheelRotation>();
		wheelRotation2 = truckWheel2.GetComponent<WheelRotation>();
		wheelRotation3 = truckWheel3.GetComponent<WheelRotation>();
		wheelRotation4 = truckWheel4.GetComponent<WheelRotation>();

		initialPosition = deliveryTruck.position;

		gameManager = GameObject.Find("GameManager"); 
	}

	void OnTriggerExit(Collider col) 
	{
		if (col.gameObject.name == "chopperMain") {
			if (nukeIsDroppped) {
				ResetTruck(); 
			}
		} 
	}

	void ResetTruck()
	{
		GameObject deliveryTruckObject = deliveryTruck.gameObject; 
		deliveryTruckObject.SetActive(true); 
		StopTruckMovements();
		deliveryTruck.position = initialPosition;
		nukeCrate = deliveryTruck.Find("NukeCrate");
		nukeFXHolder = deliveryTruck.Find("nukeFXHolder"); 
		if (nukeCrate != null) {
			if (SurvivalMissionScript.isSurvivalMission) {
				if (survivalMissionManager) {
					survivalMissionManager.SendMessage("ReparentNukeCrate",nukeCrate,SendMessageOptions.DontRequireReceiver);
					survivalMissionManager.SendMessage("ReparentNukeFXHolder",nukeFXHolder,SendMessageOptions.DontRequireReceiver);
				}
			} else {
				nukeCrate.parent = pickedNukeCollector; 
				nukeCrate.localPosition = new Vector3(0f,0f,0f);
				Destroy(nukeFXHolder.gameObject);  
			}
		}
		nukeIsDroppped = false; 
	}

	void StopTruckMovements()
	{
		moveEnemyPositionScript.enabled = false; 
		wheelRotation1.enabled = false; 
		wheelRotation2.enabled = false; 
		wheelRotation3.enabled = false; 
		wheelRotation4.enabled = false; 
	}

	public void SetNukeIsDropped()
	{
		nukeIsDroppped = true; 
	}
}
