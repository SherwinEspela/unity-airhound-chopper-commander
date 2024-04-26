using UnityEngine;
using System.Collections;
using PathologicalGames; 

public class DespawnByDistance : MonoBehaviour {

	// Private
	private GameObject chopper; 
	private GameObject gameManager;
	private string enemyAirDroneString = "enemyAirDrone";
	private string enemyAirBuzzerString = "enemyAirBuzzer";
	private string enemyTankString = "enemyTank";
	private string stringJeepName = "enemyJeep";
	private float initialPosX; 
	private float initialPosY;
	private float initialPosZ;

	// Public
	public float distanceX = 24f; 

	// Event
	public delegate void DespawnByDistanceAction();
	public static event DespawnByDistanceAction OnDistanceAwayFromChopper;

	void Awake()
	{
		chopper = GameObject.Find("chopperMain");
		gameManager = GameObject.Find("GameManager");

		initialPosX = this.transform.position.x;
		initialPosY = this.transform.position.y;
		initialPosZ = this.transform.position.z;
	}

	// Use this for initialization
	void Start () {
		chopper = GameObject.Find("chopperMain");
		gameManager = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
		CheckDistance(); 
	}

	void CheckDistance()
	{
		if (chopper) {
			if (transform.position.x - chopper.transform.position.x > distanceX || 
				chopper.transform.position.x - transform.position.x > distanceX
			)
			{
				RemoveEnemyFromArray(); 
				if (OnDistanceAwayFromChopper != null) {
					OnDistanceAwayFromChopper ();
				}
			}
//			if (chopper.transform.position.x - transform.position.x > distanceX) {
//				RemoveEnemyFromArray(); 
//			}	
		}
	}

	void RemoveEnemyFromArray()
	{
		PoolManager.Pools["Enemies"].Despawn(this.transform);

		if (gameObject.name.Contains(enemyAirBuzzerString)) {
			GameManagerScript.airbuzzerCount--;
			if (GameManagerScript.airbuzzerCount == 0) {
				gameManager.SendMessage("UpdateEnemyBuzzerSpawnTimeRestart",SendMessageOptions.DontRequireReceiver);
			}
		}

		else if (gameObject.name.Contains(enemyTankString)) {
			GameManagerScript.tanksCount--;
			if (GameManagerScript.tanksCount == 0) {
				gameManager.SendMessage("UpdateEnemyTankSpawnTimeRestart",SendMessageOptions.DontRequireReceiver);
			}
		}
		
		else if (gameObject.name.Contains(stringJeepName)) {
			GameManagerScript.jeepsCount--;
			if (GameManagerScript.jeepsCount == 0) {
				gameManager.SendMessage("UpdateEnemyJeepSpawnTimeRestart",SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}