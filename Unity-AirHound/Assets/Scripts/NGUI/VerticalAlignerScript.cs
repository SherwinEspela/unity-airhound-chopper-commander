using UnityEngine;
using System.Collections;

public class VerticalAlignerScript : MonoBehaviour {

	public GameObject topObject;
	public GameObject bottomObject; 
	public GameObject[] objects;
	
	// Use this for initialization
	void Start () {
		float topObjectPositionY = topObject.transform.position.y;
		float bottomObjectPositionY = bottomObject.transform.position.y;
		
		float positionDifference = bottomObjectPositionY - topObjectPositionY;
		float positionGaps = positionDifference / (objects.Length - 1);
		
		float positionY = topObject.transform.position.y;
		float positionX = topObject.transform.position.x; 
		for (int i = 0; i < objects.Length; i++) {
			objects[i].transform.position = new Vector3(positionX,positionY,objects[i].transform.position.z);
			positionY += positionGaps;
		}
	}
}
