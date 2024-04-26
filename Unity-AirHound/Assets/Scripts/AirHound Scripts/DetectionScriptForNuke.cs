using UnityEngine;
using System.Collections;

public class DetectionScriptForNuke : MonoBehaviour {

	public GameObject displayObject;
	public GameObject pickerObject; 
	public GameObject gameManager;
	public GameObject laserPointerGroup; 
	private bool nukeFoundChatterPlayed = false;

	void Start()
	{
		if (!gameManager) {
			gameManager = GameObject.Find("GameManager"); 
		}

		if (!laserPointerGroup) {
			laserPointerGroup = GameObject.Find("laserPointerGroup");	
		}

		if (!pickerObject) {
			pickerObject = GameObject.Find("itemPicker");
		}
	}

	void OnTriggerEnter(Collider col) 
	{
		if (col.gameObject.name == "chopperMain") {
			if (!ItemPickerScript.isHoldingNuke) {
				if (displayObject) {
					displayObject.SetActive(true);
					ItemPickerScript.laserIsOn = true; 
					if (laserPointerGroup) {
						laserPointerGroup.SetActive(true);	
						gameManager.SendMessage("HideBothImageDirectionArrows",SendMessageOptions.DontRequireReceiver); // from ControlsVisibilityScript.cs
						//GameManagerScript.haltAddingEnemyTanks = true; 
					} else {
						col.gameObject.SendMessage("SetLaserPointerActive"); 
					}
					pickerObject.SendMessage("SetNukeIsDetected",SendMessageOptions.DontRequireReceiver);
					if (!nukeFoundChatterPlayed) {
						gameManager.SendMessage("InvokePlayNukeFoundChatter",SendMessageOptions.DontRequireReceiver);
						nukeFoundChatterPlayed = true; 
					}
				}	
			}
		} 
	}
	
	void OnTriggerExit(Collider col) 
	{
		if (col.gameObject.name == "chopperMain") {
			if (!ItemPickerScript.isHoldingNuke) {
				if (displayObject) {
					ItemPickerScript.laserIsOn = false;
					displayObject.SetActive(false);
					if (laserPointerGroup) {
						laserPointerGroup.SetActive(false);
						//GameManagerScript.haltAddingEnemyTanks = false;
					} else {
						col.gameObject.SendMessage("SetLaserPointerInactive",SendMessageOptions.DontRequireReceiver);
					}
					if (pickerObject) {
						pickerObject.SendMessage("SetNukeIsNotDetected",SendMessageOptions.DontRequireReceiver);	
					}
				}	
			}
		} 
	}
}
