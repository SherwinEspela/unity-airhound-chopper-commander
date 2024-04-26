using UnityEngine;
using System.Collections;

public class PanelMainMenuAnimationEvent : MonoBehaviour {

	public GameObject mainMenuManager;

	public void DisableAllMenuPanels()
	{
		mainMenuManager.SendMessage ("DisableAllMenuPanels",SendMessageOptions.DontRequireReceiver); // from AnimationEventManager.cs 
	}

	public void DisablePanelMainMenu()
	{
		mainMenuManager.SendMessage ("DisablePanelMainMenu",SendMessageOptions.DontRequireReceiver); // from AnimationEventManager.cs
	}
}
