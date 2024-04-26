using UnityEngine;
using System.Collections;

public class Unity46SceneAdjustmentsManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject invisibleWallStart = GameObject.Find ("invisibleWallStart");
		invisibleWallStart.transform.position = new Vector3 (-15,invisibleWallStart.transform.position.y,0); 

		GameObject goBackZoneStart = GameObject.Find ("GoBackZoneStart");
		goBackZoneStart.transform.position = new Vector3 (-16,goBackZoneStart.transform.position.y,0); 
	}
}
