using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic; 
//using I2.Loc; 

public class AirhoundLocalizationManager : MonoBehaviour {

	private string stringPlayerPrefsLanguange = "PlayerPrefsLanguange"; 
	
	private string languangeEnglish = "English"; 
	private string languangeFrench = "French";
	private string languangeChinese = "Chinese";
	private string languangeSpanish = "Spanish";
	private string languangeGerman = "German";
	private string languangeKorean = "Korean";
	private string languangeRussian = "Russian";
	private string languangeItalian = "Italian";
	
	public Toggle toggleEnglish; 
	public Toggle toggleFrench;
	public Toggle toggleChinese;
	public Toggle toggleSpanish;
	public Toggle toggleGerman;
	public Toggle toggleKorean;
	public Toggle toggleRussian;
	public Toggle toggleItalian;
	
	private List<Toggle> listOfTogglesForLanguage = new List<Toggle>(); 
	
	// Use this for initialization
	void Start () {
		listOfTogglesForLanguage.Add (toggleEnglish); 
		listOfTogglesForLanguage.Add (toggleFrench);
		listOfTogglesForLanguage.Add (toggleChinese);
		listOfTogglesForLanguage.Add (toggleSpanish);
		listOfTogglesForLanguage.Add (toggleGerman);
		listOfTogglesForLanguage.Add (toggleKorean);
		listOfTogglesForLanguage.Add (toggleRussian);
		listOfTogglesForLanguage.Add (toggleItalian);
		
		InitializeLanguage (); 
	}
	
	void InitializeLanguage()
	{
		if (PlayerPrefs.HasKey(stringPlayerPrefsLanguange)) {
			string selectedLanguage = PlayerPrefs.GetString(stringPlayerPrefsLanguange); 
			//Debug.Log("selectedLanguage = " + selectedLanguage); 

			//if (LocalizationManager.HasLanguage(selectedLanguage)) {
				//LocalizationManager.CurrentLanguage = selectedLanguage; 
			//}

			foreach (var toggle in listOfTogglesForLanguage) {
				toggle.isOn = false; 
			}
			
			if (selectedLanguage.Contains(languangeEnglish)) {
				toggleEnglish.isOn = true;
			}
			else if (selectedLanguage.Contains(languangeFrench)) {
				toggleFrench.isOn = true; 
			}
			else if (selectedLanguage.Contains(languangeChinese)) {
				toggleChinese.isOn = true; 
			}
			else if (selectedLanguage.Contains(languangeSpanish)) {
				toggleSpanish.isOn = true; 
			}
			else if (selectedLanguage.Contains(languangeGerman)) {
				toggleGerman.isOn = true; 
			}
			else if (selectedLanguage.Contains(languangeKorean)) {
				toggleKorean.isOn = true; 
			}
			else if (selectedLanguage.Contains(languangeRussian)) {
				toggleRussian.isOn = true; 
			}
			else if (selectedLanguage.Contains(languangeItalian)) {
				toggleItalian.isOn = true; 
			}
		}
	}
	
	//public void SaveSelectedLanguange(SetLanguage setLanguageScript)
	//{
		//PlayerPrefs.SetString (stringPlayerPrefsLanguange, setLanguageScript._Language);
		//PlayerPrefs.Save (); 
	//}
}
