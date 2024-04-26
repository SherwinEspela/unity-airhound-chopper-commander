using UnityEngine;
using System.Collections;

public class DeviceManager : MonoBehaviour {

	public static bool deviceIsIPad;  
	//public GameObject panelMainMenuIPad; 
	//public GameObject panelMainMenuIPhone;
	public Transform sideFlaresGroup;
	//public GameObject panelSocialMedia_iPhone; 
	//public GameObject panelSocialMedia_iPad; 
	public Transform coboltFlareTitleGroup; 

	// Use this for initialization
	void Start () {
		if ((UnityEngine.iOS.Device.generation.ToString()).IndexOf("iPad")>-1) {
			deviceIsIPad = true;
		} else {
			deviceIsIPad = false; 
		}

		ConfigureMenuSettings(); 
	}

	void ConfigureMenuSettings()
	{
		if (deviceIsIPad) {
			//panelMainMenuIPad.SetActive(true);
			//panelMainMenuIPhone.SetActive(false);

			sideFlaresGroup.position = new Vector3(0.5f,sideFlaresGroup.position.y,sideFlaresGroup.position.z); 

			//panelSocialMedia_iPad.SetActive(true);
			//panelSocialMedia_iPhone.SetActive(false); 
			coboltFlareTitleGroup.position = new Vector3(-0.4f,0.125f,0f); 
		}

		else {
			//panelMainMenuIPad.SetActive(false);
			//panelMainMenuIPhone.SetActive(true);

			sideFlaresGroup.position = new Vector3(0,sideFlaresGroup.position.y,sideFlaresGroup.position.z);

			//panelSocialMedia_iPad.SetActive(false);
			//panelSocialMedia_iPhone.SetActive(true);
		}
	}
}
