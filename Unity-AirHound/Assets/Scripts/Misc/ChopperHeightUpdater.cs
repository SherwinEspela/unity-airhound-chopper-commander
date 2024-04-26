using UnityEngine;
using System.Collections;

public class ChopperHeightUpdater : MonoBehaviour {
		
	// Update is called once per frame
	void Update () {
		if (this.transform.localPosition.y > 8f) {
			this.transform.localPosition = new Vector3(transform.localPosition.x,8f,transform.localPosition.z); 	
		}	
	}
}
