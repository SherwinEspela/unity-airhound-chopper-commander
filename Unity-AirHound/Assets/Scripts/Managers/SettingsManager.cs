using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class SettingsManager : MonoBehaviour {
	
	public static bool radioChatterEnabled; 
	public static bool messagePromptEnabled;
 
	public Toggle toggleRadioChatter; 
	public Toggle toggleMessagePrompt;

	private string musicVolumeString = "MusicVolume";
	private GameObject musicManager; 

	void Start()
	{
//		if (PlayerPrefs.HasKey("RadioChatterEnabled")) {
//			if (PlayerPrefs.GetInt("RadioChatterEnabled") == 1) {
//				radioChatterEnabled = true;
//				toggleRadioChatter.isOn = true; 
//			} else {
//				radioChatterEnabled = false;
//				toggleRadioChatter.isOn = false;
//			}	
//		} else {
//			PlayerPrefs.SetInt("RadioChatterEnabled",1);
//			PlayerPrefs.Save();
//			radioChatterEnabled = true;
//			toggleRadioChatter.isOn = true;
//		}
//
//		if (PlayerPrefs.HasKey("MessagePromptEnabled")) {
//			if (PlayerPrefs.GetInt("MessagePromptEnabled") == 1) {
//				messagePromptEnabled = true;
//				toggleMessagePrompt.isOn = true; 
//			} else {
//				messagePromptEnabled = false;
//				toggleMessagePrompt.isOn = false;
//			}	
//		} else {
//			PlayerPrefs.SetInt("MessagePromptEnabled",1);
//			PlayerPrefs.Save();
//			messagePromptEnabled = true;
//			toggleMessagePrompt.isOn = true;
//		}
	}

	public void UpdateRadioChatterState()
	{
		if (toggleRadioChatter.isOn) {
			EnableRadioChatter(); 
		} else {
			DisableRadioChatter(); 
		}
	}

	void EnableRadioChatter()
	{ 
		radioChatterEnabled = true;
		PlayerPrefs.SetInt("RadioChatterEnabled",1);
		PlayerPrefs.Save();
	}

	void DisableRadioChatter()
	{
		radioChatterEnabled = false; 
		PlayerPrefs.SetInt("RadioChatterEnabled",0);
		PlayerPrefs.Save();
	}

	public void UpdateMessagePromptState()
	{
		if (toggleMessagePrompt.isOn) {
			EnableMessagePrompt(); 
		} else {
			DisableMessagePrompt(); 
		}
	}

	void EnableMessagePrompt()
	{
		messagePromptEnabled = true;
		PlayerPrefs.SetInt("MessagePromptEnabled",1);
		PlayerPrefs.Save();
	}

	void DisableMessagePrompt()
	{
		messagePromptEnabled = false;
		PlayerPrefs.SetInt("MessagePromptEnabled",0);
		PlayerPrefs.Save();
	}
}
