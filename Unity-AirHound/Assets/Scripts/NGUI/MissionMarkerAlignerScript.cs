using UnityEngine;
using System.Collections;

public class MissionMarkerAlignerScript : MonoBehaviour {

	public GameObject missionMarker1;
	public GameObject missionMarker8; 
	public GameObject[] missionMarkers; // include marker 1 and 8

	// Use this for initialization
	void Start () {
		float missionMarker1PositionX = missionMarker1.transform.position.x;
		float missionMarker8PositionX = missionMarker8.transform.position.x;

		float positionDifference = missionMarker8PositionX - missionMarker1PositionX;
		float positionGaps = positionDifference / (missionMarkers.Length - 1);

		float positionX = missionMarker1.transform.position.x;
		for (int i = 0; i < missionMarkers.Length; i++) {
			missionMarkers[i].transform.position = new Vector3(positionX,missionMarkers[i].transform.position.y,missionMarkers[i].transform.position.z);
			positionX += positionGaps;
		}
	}
}
