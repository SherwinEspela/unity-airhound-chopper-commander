using UnityEngine;
using System.Collections;

public class DropZoneChopperDetector : MonoBehaviour {
	
	private GameObject gameManager; 

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager"); 
	}
	
	void OnTriggerEnter(Collider col) 
	{
		if (col.gameObject.name == "chopperMain") {
			if (ItemPickerScript.isHoldingNuke) {
				gameManager.SendMessage("HideBothImageDirectionArrows",SendMessageOptions.DontRequireReceiver); // from ControlsVisibilityScript.cs
			}
		}
	}

	void OnTriggerExit(Collider col) 
	{
		if (col.gameObject.name == "chopperMain") {
			if (ItemPickerScript.isHoldingNuke) {
				gameManager.SendMessage("ShowImageDirectionArrowBackward",SendMessageOptions.DontRequireReceiver); // from ControlsVisibilityScript.cs
			}
		}
	}
}
