using UnityEngine;
using System.Collections;

public class NukeCrate2 : MonoBehaviour {

//	private GameObject nukePicker;
//	
//	void Start()
//	{
//		nukePicker = GameObject.Find("nukePicker"); 
//	}
	
//	void OnTriggerEnter(Collider collider) 
//	{		
//		if (collider.transform.name == "NukeCrate") {
//			print("NukeCrate Detected");
//			
//			//nukePicker.SendMessage("PickerDown"); 
//			
//			//transform.parent = collider.transform;
//			
//			collider.transform.parent = this.transform; 
//			//transform.localPosition = new Vector3(0,0,0);
//			//transform.localRotation = Quaternion.Euler(0,0,0); 
//		}
//	}
	
	void OnCollisionEnter(Collision collider) 
	{		
		if (collider.transform.name == "NukeCrate") {
			//print("NukeCrate Detected");
			
			//nukePicker.SendMessage("PickerDown"); 
			
			//transform.parent = collider.transform;
			
			collider.transform.parent = this.transform; 
			//transform.localPosition = new Vector3(0,0,0);
			//transform.localRotation = Quaternion.Euler(0,0,0); 
		}
	}
}
