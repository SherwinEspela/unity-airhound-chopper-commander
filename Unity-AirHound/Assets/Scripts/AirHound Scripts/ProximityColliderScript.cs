using UnityEngine;
using System.Collections;
using PathologicalGames; 

public class ProximityColliderScript : MonoBehaviour {
	
	public GameObject mainObject;
	private GameObject gameManager;
	public string gameObjectName; 
	private string completeGameObjectName;
	private string enemyAirDrone1String = "enemyAirDrone1";
	private string enemyTank1String = "enemyTank1";
	private string enemyTank2String = "enemyTank2";
	private string enemyTank3String = "enemyTank3";
	private string stringJeep1Name = "enemyJeep1";
	
	void Awake()
	{
		completeGameObjectName = gameObjectName + "(Clone)"; 
		gameManager = GameObject.Find("GameManager");
	}
	
	void OnTriggerExit(Collider col) 
	{
		if (col.gameObject.name == "chopperMain") {

			PoolManager.Pools["Enemies"].Despawn(mainObject.transform);
			//Destroy(mainObject);
			//Destroy(gameObject); 
			
			if (completeGameObjectName.Contains(enemyAirDrone1String)) {
				gameManager.SendMessage("RemoveAirDroneFromArray",mainObject);
			}
			
			else if (completeGameObjectName.Contains(enemyTank1String)) {
				gameManager.SendMessage("RemoveTankFromArray",mainObject);
			}
			
			else if (completeGameObjectName.Contains(enemyTank2String)) {
				gameManager.SendMessage("RemoveTankFromArray",mainObject);
			}
			
			else if (completeGameObjectName.Contains(enemyTank3String)) {
				gameManager.SendMessage("RemoveTankFromArray",mainObject);
			}
			
			else if (completeGameObjectName.Contains(stringJeep1Name)) {
				gameManager.SendMessage("RemoveJeepFromArray",mainObject);
			}
		} 
	}
}
