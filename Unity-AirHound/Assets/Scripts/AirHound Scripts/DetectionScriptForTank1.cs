using UnityEngine;
using System.Collections;

public class DetectionScriptForTank1 : MonoBehaviour {

	public GameObject triggeredObject; 
	
	void OnTriggerEnter(Collider col) 
	{
		if (col.gameObject.name == "chopperMain") {
//			foreach (GameObject triggeredObject in triggeredObjects) {
//				triggeredObject.SendMessage("setIsFiring",SendMessageOptions.DontRequireReceiver);
//				triggeredObject.SendMessage("setIsAttacking",SendMessageOptions.DontRequireReceiver);
//			}
			
			triggeredObject.SendMessage("setIsFiring",SendMessageOptions.DontRequireReceiver);
		} 
	}
	
	void OnTriggerExit(Collider col) 
	{
		if (col.gameObject.name == "chopperMain") {
//			foreach (GameObject triggeredObject in triggeredObjects) {
//				triggeredObject.SendMessage("setIsNotFiring",SendMessageOptions.DontRequireReceiver);
//				triggeredObject.SendMessage("setIsNotAttacking",SendMessageOptions.DontRequireReceiver);
//			}
//			
//			triggeredObjects[1].SendMessage("setDelayedFiring",SendMessageOptions.DontRequireReceiver);
			
			triggeredObject.SendMessage("setIsNotFiring",SendMessageOptions.DontRequireReceiver);
		} 
	}
}
