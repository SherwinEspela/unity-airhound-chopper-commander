using UnityEngine;
using System.Collections;

public class GoBackZoneScript : MonoBehaviour {

	public GameObject gameManager;

	void OnTriggerEnter(Collider col) 
	{
		if (col.gameObject.name == "chopperMain") {
			gameManager.SendMessage("InvokeDisplayEventMessage","GO BACK");
		} 
	}
}
