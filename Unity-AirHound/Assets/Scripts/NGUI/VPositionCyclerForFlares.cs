using UnityEngine;
using System.Collections;

public class VPositionCyclerForFlares : MonoBehaviour {

	public float smooth = 0.2f;
	private Vector3 newPosition;
	private float xPos; 
	private float zPos;
	private float nextMove; 
	public float moveRate = 5f; 
	public float yPosMax = 1f; 
	public float yPosMin = -0.2f;
	
	//public Transform mainTransform; 
	
	void Start()
	{
		newPosition = transform.position;
		xPos = transform.position.x;
		zPos = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		PositionChanging();	
	}
	
	void PositionChanging()
	{
		float randomYPos = Random.Range(yPosMin,yPosMax); 
		Vector3 positionA = new Vector3(xPos, randomYPos, zPos);
		if (Time.time > nextMove) {	
			newPosition = positionA;
			nextMove = Time.time + moveRate;
		}
		transform.position = Vector3.Lerp(transform.position, newPosition, smooth * Time.deltaTime);
	}
}
