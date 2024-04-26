using UnityEngine;
using System.Collections;

public class DetectionScriptForTank3 : MonoBehaviour {

	public GameObject triggeredObject; 
	
	void OnTriggerEnter(Collider col) 
	{
		if (col.gameObject.name == "chopperMain") {
			triggeredObject.SendMessage("setIsFiring",SendMessageOptions.DontRequireReceiver);
			triggeredObject.SendMessage("setIsAttacking",SendMessageOptions.DontRequireReceiver);
		} 
	}
	
	void OnTriggerExit(Collider col) 
	{
		if (col.gameObject.name == "chopperMain") {
			triggeredObject.SendMessage("setIsNotFiring",SendMessageOptions.DontRequireReceiver);
			triggeredObject.SendMessage("setIsNotAttacking",SendMessageOptions.DontRequireReceiver);
		} 
	}
}
