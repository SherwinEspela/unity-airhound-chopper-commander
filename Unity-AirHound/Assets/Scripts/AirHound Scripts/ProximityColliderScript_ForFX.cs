using UnityEngine;
using System.Collections;

public class ProximityColliderScript_ForFX : MonoBehaviour {
	 
	void OnTriggerExit(Collider col) 
	{
		if (col.gameObject.name == "chopperMain") {
			Destroy(gameObject);
		} 
	}
}
