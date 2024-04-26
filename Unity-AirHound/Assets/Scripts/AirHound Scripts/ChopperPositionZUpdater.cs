using UnityEngine;
using System.Collections;

public class ChopperPositionZUpdater : MonoBehaviour {
			
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.z != 0) {
			gameObject.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,0); 	
		}
	}
}
