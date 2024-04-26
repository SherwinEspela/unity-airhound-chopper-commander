using UnityEngine;
using System.Collections;

public class PointsScript : MonoBehaviour {

	public int points;
	private GameObject gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager");
	}	

	// Calls method from ScoreManagerScript class
	public void AddPoints()
	{
		gameManager.SendMessage("AddPointsToScore",points,SendMessageOptions.DontRequireReceiver);
	}

	// Calls method from ScoreManagerScript class
	public void AddEnemyDestroyed()
	{
		gameManager.SendMessage("AddPointsToEnemyDestroyed",SendMessageOptions.DontRequireReceiver);
	}

	// Calls method from ScoreManagerScript class
	public void AddEnemyTanksDestroyed()
	{
		gameManager.SendMessage("AddPointsToEnemyTanksDestroyed",SendMessageOptions.DontRequireReceiver);
	}

	// Calls method from ScoreManagerScript class
	public void AddEnemyAirDronesDestroyed()
	{
		gameManager.SendMessage("AddPointsToEnemyAirDronesDestroyed",SendMessageOptions.DontRequireReceiver);
	}
}
