using UnityEngine;
using System.Collections;

public class AnimationEventManager : MonoBehaviour {

	public GameObject panelBGContent;
	public GameObject panelPlayContent;
	public GameObject panelLeaderboardContent;
	public GameObject panelSettingsContent;
	public GameObject panelMainMenuContent; 
	public GameObject[] panelMissionContents; 

	void Start()
	{
		DisableAllMenuPanels (); 
	}

	public void EnablePanelMainMenu()
	{
		panelMainMenuContent.SetActive (true);
	}

	public void DisablePanelMainMenu()
	{
		panelMainMenuContent.SetActive (false);
	}

	public void DisableAllMenuPanels()
	{
		panelBGContent.SetActive (false); 
		panelPlayContent.SetActive (false);
		panelLeaderboardContent.SetActive (false);
		panelSettingsContent.SetActive (false);
		foreach (var item in panelMissionContents) {
			item.SetActive(false); 	
		}
	}
	
	public void EnablePanelPlayContent()
	{
		panelBGContent.SetActive (true); 
		panelPlayContent.SetActive (true);
		panelLeaderboardContent.SetActive (false);
		panelSettingsContent.SetActive (false);
		foreach (var item in panelMissionContents) {
			item.SetActive(true); 	
		}
	}
	
	public void EnablePanelLeaderboardsContent()
	{
		panelBGContent.SetActive (true); 
		panelPlayContent.SetActive (false);
		panelLeaderboardContent.SetActive (true);
		panelSettingsContent.SetActive (false);
	}
	
	public void EnablePanelSettingsContent()
	{
		panelBGContent.SetActive (true); 
		panelPlayContent.SetActive (false);
		panelLeaderboardContent.SetActive (false);
		panelSettingsContent.SetActive (true);
	}
}
