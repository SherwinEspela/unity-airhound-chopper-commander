using UnityEngine;
//using GoogleMobileAds.Api; 
using System.Collections;

public class BannerAdsManager : MonoBehaviour {
	
//#if UNITY_IOS
//	// Device is iOS
//
//	public void InvokeShowAdBanner()
//	{
//		Invoke("ShowAdBanner",3f); 
//	}
//
//	public void ShowAdBanner()
//	{
//		if (iAdsManager_mainMenu.bannerIAd == null) {
//			iAdsManager_mainMenu.bannerIAd = iAdBannerController.instance.CreateAdBanner(TextAnchor.LowerLeft);	
//		}
//		
//		if (iAdsManager_mainMenu.bannerIAd != null) {
//			iAdsManager_mainMenu.bannerIAd.Show();	
//		}
//	}
//	
//	public void HideAdBanner()
//	{
//		if (iAdsManager_mainMenu.bannerIAd == null) {
//			iAdsManager_mainMenu.bannerIAd = iAdBannerController.instance.CreateAdBanner(TextAnchor.LowerLeft);	
//		}
//		
//		if (iAdsManager_mainMenu.bannerIAd != null) {
//			iAdsManager_mainMenu.bannerIAd.Hide();
//		}
//	}
//
//	public void DestroyAdBanner()
//	{
//		iAdBannerController.instance.DestroyBanner(iAdsManager_mainMenu.bannerIAd.id);
//		iAdsManager_mainMenu.bannerIAd = null;
//	}
//#endif
//
//#if UNITY_ANDROID
//	// Device is Android
//
//	private string admobID = "admob id";
//	private BannerView bannerView;
//
//	void Start()
//	{
//		CreateAdMobBannerAd();
//	}
//
//	void CreateAdMobBannerAd()
//	{
//		// create a banner at the bottom of the screen
//		bannerView = new BannerView (admobID, AdSize.SmartBanner, AdPosition.Bottom); 
//		
//		// create an empty ad request
//		AdRequest request = new AdRequest.Builder ().Build (); 
//		
//		// Load the banner with the request
//		bannerView.LoadAd (request); 
//	}
//
//	public void InvokeShowAdBanner()
//	{
//		Invoke("ShowAdBanner",3f); 
//	}
//	
//	public void ShowAdBanner()
//	{
//		if (!ProOrFreeSwitch.isProVersionStatic) {
//			// Free version. Show ads.
//			bannerView.Show(); 
//		}
//	}
//	
//	public void HideAdBanner()
//	{
//		if (!ProOrFreeSwitch.isProVersionStatic) {
//			// Free version. Hide ads. 
//			bannerView.Hide(); 
//		}
//	}
//	
//	public void DestroyAdBanner()
//	{
//		if (!ProOrFreeSwitch.isProVersionStatic) {
//			// Free version. destroy ad banner.
//			bannerView.Destroy();  
//		}
//	}
//#endif
}
