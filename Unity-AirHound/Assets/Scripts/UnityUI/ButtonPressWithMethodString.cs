using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonPressWithMethodString : MonoBehaviour {

	private Button buttonScript;
	public string methodName; 
	
	void Start()
	{
		buttonScript = this.gameObject.GetComponent<Button>();  
		buttonScript.onClick.AddListener (() => OnPress()); 
	}
	
	void OnPress()
	{
		if (this.GetComponent<AudioSource>()) {
			this.GetComponent<AudioSource>().Play();  	
		}
		GameManagerScript.gameManagerStatic.SendMessage(methodName,SendMessageOptions.DontRequireReceiver);
	}
}
