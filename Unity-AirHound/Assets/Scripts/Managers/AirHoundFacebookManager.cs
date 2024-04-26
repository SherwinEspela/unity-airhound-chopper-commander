using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using Facebook.MiniJSON; 

public class AirHoundFacebookManager : MonoBehaviour {

//	private string status = "Ready"; 
//	private string lastResponse = "";
//	private GameObject gameManager; 
//
//	void Start()
//	{
//		CallFBInit(); 
//		DontDestroyOnLoad(this.gameObject); 
//	}
//
//	#region FB.Init()
//	public void CallFBInit()
//	{
//		FB.Init(OnInitComplete, OnHideUnity);
//	}
//	
//	private void OnInitComplete()
//	{
//		Debug.Log("FB.Init completed: Is user logged in? " + FB.IsLoggedIn);
//	}
//	
//	private void OnHideUnity(bool isGameShown)
//	{
//		Debug.Log("Is game showing? " + isGameShown);
//	}
//	
//	#endregion
//
//	#region FB.Login() example
//	
//	private void CallFBLogin()
//	{
//		FB.Login("email,publish_actions", LoginCallback);
//	}
//	
//	void LoginCallback(FBResult result)
//	{
//		if (result.Error != null)
//			lastResponse = "Error Response:\n" + result.Error;
//		else if (!FB.IsLoggedIn)
//		{
//			lastResponse = "Login cancelled by Player";
//		}
//		else
//		{
//			lastResponse = "Login was successful!";
//			//CallFBInit(); 
//		}
//
//		Debug.Log(lastResponse); 
//	}
//	
//	private void CallFBLogout()
//	{
//		FB.Logout();
//	}
//	#endregion
//
//	#region FB.AppRequest() Friend Selector
//	
//	public string FriendSelectorTitle = "Invite Friends";
//	public string FriendSelectorMessage = "";
//	public string FriendSelectorFilters = "[\"app_users\"]";
//	public string FriendSelectorData = "{}";
//	public string FriendSelectorExcludeIds = "";
//	public string FriendSelectorMax = "";
//	private string message1 = " invites you to play\nAirHound: Chopper Commander"; 
//	
//	public void InviteFriendsToPlay()
//	{
//		Debug.Log("InviteFriendsToPlay method..."); 
//
//		if (FB.IsLoggedIn) {
//			// If there's a Max Recipients specified, include it
//			int? maxRecipients = null;
//			if (FriendSelectorMax != "")
//			{
//				try
//				{
//					maxRecipients = Int32.Parse(FriendSelectorMax);
//				}
//				catch (Exception e)
//				{
//					status = e.Message;
//				}
//			}
//			
//			// include the exclude ids
//			string[] excludeIds = (FriendSelectorExcludeIds == "") ? null : FriendSelectorExcludeIds.Split(',');
//			List<object> FriendSelectorFiltersArr = null;
//			if (!String.IsNullOrEmpty(FriendSelectorFilters))
//			{
//				try
//				{
//					FriendSelectorFiltersArr = Facebook.MiniJSON.Json.Deserialize(FriendSelectorFilters) as List<object>;
//				}
//				catch
//				{
//					throw new Exception("JSON Parse error");
//				}
//			}
//			
//			Debug.Log("Doing app request process..."); 
//
//			FriendSelectorMessage = FB.UserId + message1; 
//
//			FB.AppRequest(
//				FriendSelectorMessage,
//				null,
//				FriendSelectorFiltersArr,
//				excludeIds,
//				maxRecipients,
//				FriendSelectorData,
//				FriendSelectorTitle,
//				InviteCallback
//				);	
//		} else {
//			Debug.Log("User is not logged in..."); 
//			CallFBLogin(); 
//		}
//	}
//	#endregion
//
//	private void InviteCallback(FBResult result)
//	{
//		if (result != null)
//		{
//			var responseObject = Json.Deserialize(result.Text) as Dictionary<string, object>;
//			IEnumerable<object> objectArray = (IEnumerable<object>)responseObject["to"];
//			
//			if (objectArray.Count() >= 1)
//			{
//				Debug.Log("FB app request successful!"); 
//				Debug.Log(result.Text); 
//				IncreaseRocketInventory(); 
//			}
//		}
//	}
//	
//	private void IncreaseRocketInventory()
//	{
//		Debug.Log("IncreaseRocketInventory method..."); 
//
//		if (gameManager == null) {
//			gameManager = GameObject.Find("GameManager"); 
//		}
//
//		gameManager.SendMessage("SetRocketInventory",SendMessageOptions.DontRequireReceiver);
//		gameManager.SendMessage("GetRocketInventoryValue",SendMessageOptions.DontRequireReceiver);
//	}
}
