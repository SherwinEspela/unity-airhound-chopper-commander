using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;
using UnityEngine.SceneManagement;

public class AirHoundUnityAdsManager : MonoBehaviour {

	private string stringLoadingScene = "LoadingScene"; 
	private const string stringGameID = "17633"; // for android = 131621799 

	// Use this for initialization
	void Start () {
		DoInitialize (); 
	}
	
	void DoInitialize()
	{
		Advertisement.Initialize (stringGameID, true);
		PlayUnityAdsVideo ();
	}
	
	public void PlayUnityAdsVideo()
	{
		if (Advertisement.isInitialized) {
			ShowUnityAdvetisement(); 
		} else {
			DoInitialize(); 
			ShowUnityAdvetisement(); 
		}
	}
	
	void ShowUnityAdvetisement()
	{
		string zone = "defaultVideoAndPictureZone";

		ShowOptions options = new ShowOptions ();
		options.resultCallback = AdCallbackhandler;

		if (Advertisement.IsReady(zone)) {
			Advertisement.Show (zone, options);
		}
	}
	
	public void GotoLoadingScene()
	{
        SceneManager.LoadScene(stringLoadingScene);
	}

	void AdCallbackhandler (ShowResult result)
	{
		switch(result)
		{
		case ShowResult.Finished:
			Debug.Log ("Ad Finished. Rewarding player...");
			break;
		case ShowResult.Skipped:
			Debug.Log ("Ad skipped. Son, I am dissapointed in you");
			break;
		case ShowResult.Failed:
			Debug.Log("I swear this has never happened to me before");
			break;
		}

		GotoLoadingScene ();
	}

//	IEnumerator WaitForAd()
//	{
//		float currentTimeScale = Time.timeScale;
//		Time.timeScale = 0f;
//		yield return null;
//
//		while (Advertisement.isShowing)
//			yield return null;
//
//		Time.timeScale = currentTimeScale;
//	}
}