using UnityEngine;
using System.Collections;

public class ActivateLaserPointer : MonoBehaviour {

	public GameObject laserPointerGroup;
	public GameObject chopperHealth; 

	public void SetLaserPointerActive()
	{
		if (laserPointerGroup) {
			laserPointerGroup.SetActive(true); 	
		}

		chopperHealth.SendMessage("SetNukeIsDetected",SendMessageOptions.DontRequireReceiver); 
	}

	public void SetLaserPointerInactive()
	{
		if (laserPointerGroup) {
			laserPointerGroup.SetActive(false); 	
		}

		chopperHealth.SendMessage("SetNukeIsNotDetected",SendMessageOptions.DontRequireReceiver);
	}
}
