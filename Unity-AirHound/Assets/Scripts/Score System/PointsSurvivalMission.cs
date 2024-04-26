using UnityEngine;
using System.Collections;

public class PointsSurvivalMission : MonoBehaviour {

	//private int points;
	private GameObject gameManager;
	
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager");
	}	
	
	public void AddPointsSurvivalMission(int points)
	{
		gameManager.SendMessage("AddPointsToScore",points,SendMessageOptions.DontRequireReceiver);
	}
}
