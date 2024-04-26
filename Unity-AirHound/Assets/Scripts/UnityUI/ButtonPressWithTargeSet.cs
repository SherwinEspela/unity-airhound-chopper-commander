using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonPressWithTargeSet : MonoBehaviour {
	 
	public Button buttonScript;

	void Start()
	{
        buttonScript.onClick.AddListener(() => OnPress());
	}

	void OnPress()
	{
    	if (this.GetComponent<AudioSource>()) {
			this.GetComponent<AudioSource>().Play();  	
		}
        
		GameManagerScript.gameManagerStatic.SendMessage("HidePanelTopHud",SendMessageOptions.DontRequireReceiver); // from ControlsVisibilityScript.cs
		GameManagerScript.gameManagerStatic.SendMessage("ShowPanelPausedGroup",SendMessageOptions.DontRequireReceiver); // from UnityGUIGamePlayManager.cs
		GameManagerScript.gameManagerStatic.SendMessage("PauseTheGame",SendMessageOptions.DontRequireReceiver); // from GameManagerScript.cs
	}
}
