using UnityEngine;
using System.Collections;

public class NoNetworkMessageManager : MonoBehaviour {

	//public GameObject panelNoNetwork; 

	public bool isMainMenu = false; 

	// Use this for initialization
	void Start () {
	
	}
	
	public void DisplayPanelNoNetwork()
	{
		//panelNoNetwork.SetActive(true);
//		if (isMainMenu) {
//			this.gameObject.BroadcastMessage("CurtainFadeOut",SendMessageOptions.DontRequireReceiver);	
//		} else {
//			this.gameObject.BroadcastMessage("FadeIn",SendMessageOptions.DontRequireReceiver);
//		}
	}

	public void HidePanelNoNetwork()
	{
		//panelNoNetwork.SetActive(false); 
	}
}
