using UnityEngine;
using System.Collections;

public class AirHoundIOSSocialMediaManager : MonoBehaviour {

//	//public bool isMainMenu = false; 
//	//private GameObject panelPauseButtons;
//	private string messageMainMenu = "Commandeer the best!\nPlay AirHound Chopper Commander.\nFree to play on iOS."; 
//	private string[] randomMessages = {"Come and play this free game!","Its free to play!"}; 
//	//private bool panelPauseButtonIsHidden = false; 
//
//	public UnityGUIMainMenuManager ugmmmScript; 
//
//	// Use this for initialization
//	void Start () {
//		IOSSocialManager.instance.addEventListener(IOSSocialManager.FACEBOOK_POST_SUCCESS, OnPostSuccess); 
//		IOSSocialManager.instance.addEventListener(IOSSocialManager.TWITTER_POST_SUCCESS, OnPostSuccess);
//
//		IOSSocialManager.instance.addEventListener(IOSSocialManager.FACEBOOK_POST_FAILED, OnPostFailed); 
//		IOSSocialManager.instance.addEventListener(IOSSocialManager.TWITTER_POST_FAILED, OnPostFailed);
//
////		if (!isMainMenu) {
////			panelPauseButtons = GameObject.Find("PanelPauseButtons");	
////		}
//	}
//
////	private void DisplayPanelPauseButtons()
////	{
////		if (!isMainMenu) {
////			if (panelPauseButtons == null) {
////				panelPauseButtons = GameObject.Find("PanelPauseButtons");	 
////			}
////			panelPauseButtons.SetActive(true);
////			this.gameObject.BroadcastMessage("ShowCurtain",SendMessageOptions.DontRequireReceiver); // to show the curtain
////		}
////	}
//
////	public void HidePanelPauseButtons()
////	{
////		if (!isMainMenu) {
////			if (panelPauseButtons == null) {
////				panelPauseButtons = GameObject.Find("PanelPauseButtons");	 
////			}
////			panelPauseButtons.SetActive(false); 
////			panelPauseButtonIsHidden = true; 
////			this.gameObject.BroadcastMessage("HideCurtain",SendMessageOptions.DontRequireReceiver); // to hide the curtain
////		}
////	}
//
//	public void DoPostFBScreenShot()
//	{
//		StartCoroutine (PostFBScreenShot()); 
//	}
//
//	IEnumerator PostFBScreenShot()
//	{
//		yield return new WaitForEndOfFrame(); 
//		//HidePanelPauseButtons();
//
//		int width = Screen.width; 
//		int height = Screen.height; 
//		Texture2D tex = new Texture2D(width,height,TextureFormat.RGB24,false); 
//		tex.ReadPixels(new Rect(0,0,width,height),0,0); 
//		tex.Apply(); 
//	
//		IOSSocialManager.instance.FacebookPost(MessageToPost(),tex);
//		Destroy(tex); 
//
//		//DisplayPanelPauseButtons(); 
//	}
//
//	public void DoPostTwitterScreenShot()
//	{
//		StartCoroutine (PostTwitterScreenShot()); 
//	}
//
//	IEnumerator PostTwitterScreenShot()
//	{
//		yield return new WaitForEndOfFrame(); 
//		//HidePanelPauseButtons();
//
//		int width = Screen.width; 
//		int height = Screen.height; 
//		Texture2D tex = new Texture2D(width,height,TextureFormat.RGB24,false); 
//		tex.ReadPixels(new Rect(0,0,width,height),0,0); 
//		tex.Apply(); 
//		
//		IOSSocialManager.instance.TwitterPost(MessageToPost(),tex);
//		Destroy(tex);
//
//		//DisplayPanelPauseButtons(); 
//	}
//
//	// for score sharing when mission completed or failed
//	public IEnumerator PostFBScreenShotAfterGameCompletion()
//	{	
//		yield return new WaitForEndOfFrame(); 
//		
//		int width = Screen.width; 
//		int height = Screen.height; 
//		Texture2D tex = new Texture2D(width,height,TextureFormat.RGB24,false); 
//		tex.ReadPixels(new Rect(0,0,width,height),0,0); 
//		tex.Apply(); 
//
//		IOSSocialManager.instance.FacebookPost(MessageToPostAfterMissionOutcome(),tex);
//		Destroy(tex); 
//	}
//
//	public IEnumerator PostTwitterScreenShotAfterGameCompletion()
//	{
//		yield return new WaitForEndOfFrame(); 
//		
//		int width = Screen.width; 
//		int height = Screen.height; 
//		Texture2D tex = new Texture2D(width,height,TextureFormat.RGB24,false); 
//		tex.ReadPixels(new Rect(0,0,width,height),0,0); 
//		tex.Apply(); 
//		
//		IOSSocialManager.instance.TwitterPost(MessageToPostAfterMissionOutcome(),tex);
//		Destroy(tex);
//	}
//
//	private string MessageToPostAfterMissionOutcome()
//	{
//		string message = string.Empty; 
//		if (GameManagerScript.resultInThisMission == GameManagerScript.MissionResult.MissionCompleted) {
//			message = "Mission - " + SceneIndexManager.sceneIndex + " completed!\n" + "Checkout my score in AirHound: Chopper Commander"; 
//		} else {
//			message = "Failed to beat Mission - " + SceneIndexManager.sceneIndex + "\nAirHound: Chopper Commander is tough to play." + "\nAnyway, here's my score."; 
//		}
//
//		return message; 
//	}
//
//	private string MessageToPost()
//	{
////		string message = "";
////		string randomMessage = randomMessages[Random.Range(0,randomMessages.Length)]; 
////
////		if (isMainMenu) {
////			message = messageMainMenu; 
////		} else {
////			message = "Playing Mission - " + SceneIndexManager.sceneIndex + " of " + "AirHound: Chopper Commander\n" + randomMessage; 
////		}
//
//		return messageMainMenu; 
//	}
//
//	private void OnPostSuccess()
//	{
//		IOSNativePopUpManager.showMessage("Successful","Your message has been posted!"); 
//
//		ugmmmScript.EnableMainMenuButtons (); 
//	}
//
//	private void OnPostFailed()
//	{
//		IOSNativePopUpManager.showMessage("Connection Failed","Please try again later.");
//
//		ugmmmScript.EnableMainMenuButtons ();
//	}
}
