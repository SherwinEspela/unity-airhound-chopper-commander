using UnityEngine;
using System.Collections;

public class EnemyDroneSpawnPointScript : MonoBehaviour {

	private Vector3 newPosition;
	private float smooth = 1f;
	private Vector3 positionFront = new Vector3(15,2,0);
	private Vector3 positionBack = new Vector3(-15,2,0);
	private bool chopperIsFacingFront = true; 
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		PositionChange(); 
	}
	
	void PositionChange()
	{
		if (chopperIsFacingFront) {
			MoveToFront(); 	
		} else {
			MoveToBack(); 
		}
	}
	
	void MoveToFront()
	{
		print ("Move to front");
		newPosition = positionFront; 
		transform.position = Vector3.Lerp(transform.position, newPosition, smooth * Time.deltaTime);
	}
	
	void MoveToBack()
	{
		print ("Move to back");
		newPosition = positionBack;
		transform.position = Vector3.Lerp(transform.position, newPosition, smooth * Time.deltaTime);
	}
	
	void ChopperFacesFront()
	{
		chopperIsFacingFront = true; 
	}
	
	void ChopperFacesBack()
	{
		chopperIsFacingFront = false; 
	}
}
