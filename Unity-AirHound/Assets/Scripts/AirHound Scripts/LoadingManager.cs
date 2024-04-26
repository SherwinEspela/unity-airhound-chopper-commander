using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingManager : MonoBehaviour {
	
	private AsyncOperation async;
	public GameObject panelControlsGuide; 
	public GameObject panelLoadingUI; 
	public GameObject[] loadingPanels; 
	public Slider sliderScript;
	public Slider sliderControlsGuideScript; 
	private string stringAirHoundPPCGS = "AirHoundPlayerPrefsControlsGuideShown";  

	IEnumerator Start() 
	{
		if (PlayerPrefs.HasKey(stringAirHoundPPCGS)) {
			// show random either loading screen or controls guide
			loadingPanels[Random.Range(0,loadingPanels.Length)].SetActive(true); 
		} else {
			// show controls guide only
			panelControlsGuide.SetActive(true);
			panelLoadingUI.SetActive(false); 
		}
		
		PlayerPrefs.SetInt(stringAirHoundPPCGS,1); 
		PlayerPrefs.Save(); 
		
		async = Application.LoadLevelAsync(SceneIndexManager.sceneIndex); 
		while (!async.isDone)
		{ 
			sliderScript.value = async.progress; 
			sliderControlsGuideScript.value = async.progress; 
			yield return 0;
		}
	}
}
