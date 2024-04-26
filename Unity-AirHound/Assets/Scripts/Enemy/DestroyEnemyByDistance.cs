using UnityEngine;
using System.Collections;
using PathologicalGames; 

public class DestroyEnemyByDistance : MonoBehaviour {

	private GameObject gameManager;
	public GameObject mainObject;
	public string gameObjectName; 
	private string completeGameObjectName;
	private string enemyTank1String = "enemyTank1";
	private string enemyTank2String = "enemyTank2";
	private string enemyTank3String = "enemyTank3";
	private string stringJeep1Name = "enemyJeep1";

	void Start()
	{
		completeGameObjectName = gameObjectName + "(Clone)"; 
		gameManager = GameObject.Find("GameManager");
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x < -40f) {
			RemoveEnemyFromArray();
		}

		if (transform.position.x > 175f) {
			RemoveEnemyFromArray();		
		}
	}

	void RemoveEnemyFromArray()
	{
		PoolManager.Pools["Enemies"].Despawn(mainObject.transform);
		//Destroy(mainObject);

		if (completeGameObjectName.Contains(enemyTank1String)) {
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
