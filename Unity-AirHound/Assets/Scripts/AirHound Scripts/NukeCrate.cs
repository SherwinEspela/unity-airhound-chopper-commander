using UnityEngine;
using System.Collections;

public class NukeCrate : MonoBehaviour {
	
	private GameObject nukePicker;
	
	void Start()
	{
		nukePicker = GameObject.Find("nukePicker"); 
	}
	
	void OnTriggerEnter(Collider collider) 
	{		
		if (collider.transform.name == "chopperMain") {
			print("Nuke Found");
			
			//nukePicker.SendMessage("PickerDown"); 
		}
	}
	
	void OnTriggerExit()
	{
		print("Nuke Ignored");
		//nukePicker.SendMessage("PickerUp"); 
	}
}
