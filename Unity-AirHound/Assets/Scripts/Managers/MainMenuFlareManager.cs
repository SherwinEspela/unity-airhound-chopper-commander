using UnityEngine;
using System.Collections;

public class MainMenuFlareManager : MonoBehaviour {

	public Animator animatorFlare1; 
	public Transform flare1PositionOffset; 
	private Vector3 flare1PositionOffsetForIpad = new Vector3(-6.3f,0.34f,0f); 

	public Animator animatorFlareMenuTitle; 
	public Transform flareMenuTitlePositionOffset; 
	private Vector3 flareMenuTitlePositionOffsetForIpad = new Vector3(-0.07f,0.02f,0f);

	// Use this for initialization
	void Start () {

#if UNITY_IOS
		if (UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPad1Gen) {
			flare1PositionOffset.position = flare1PositionOffsetForIpad; 	
			flareMenuTitlePositionOffset.localPosition = flareMenuTitlePositionOffsetForIpad; 
		}
		else if (UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPad2Gen) {
			flare1PositionOffset.position = flare1PositionOffsetForIpad; 	
			flareMenuTitlePositionOffset.localPosition = flareMenuTitlePositionOffsetForIpad;
		}
		else if (UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPad3Gen) {
			flare1PositionOffset.position = flare1PositionOffsetForIpad; 
			flareMenuTitlePositionOffset.localPosition = flareMenuTitlePositionOffsetForIpad;
		}
		else if (UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPad4Gen) {
			flare1PositionOffset.position = flare1PositionOffsetForIpad; 
			flareMenuTitlePositionOffset.localPosition = flareMenuTitlePositionOffsetForIpad;
		}
		else if (UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPad5Gen) {
			flare1PositionOffset.position = flare1PositionOffsetForIpad; 
			flareMenuTitlePositionOffset.localPosition = flareMenuTitlePositionOffsetForIpad;
		}
		else if (UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPadAir2) {
			flare1PositionOffset.position = flare1PositionOffsetForIpad; 
			flareMenuTitlePositionOffset.localPosition = flareMenuTitlePositionOffsetForIpad;
		}
		else if (UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPadMini1Gen) {
			flare1PositionOffset.position = flare1PositionOffsetForIpad; 
			flareMenuTitlePositionOffset.localPosition = flareMenuTitlePositionOffsetForIpad;
		}
		else if (UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPadMini2Gen) {
			flare1PositionOffset.position = flare1PositionOffsetForIpad; 
			flareMenuTitlePositionOffset.localPosition = flareMenuTitlePositionOffsetForIpad;
		}
		else if (UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPadMini3Gen) {
			flare1PositionOffset.position = flare1PositionOffsetForIpad; 
			flareMenuTitlePositionOffset.localPosition = flareMenuTitlePositionOffsetForIpad;
		}
		else if (UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPadUnknown) {
			flare1PositionOffset.position = flare1PositionOffsetForIpad; 
			flareMenuTitlePositionOffset.localPosition = flareMenuTitlePositionOffsetForIpad;
		}
#endif

	}

	public void TriggerShowFlare1()
	{
		animatorFlare1.SetTrigger ("TriggerShow"); 
	}

	public void TriggerHideFlare1()
	{
		animatorFlare1.SetTrigger ("TriggerHide"); 
	}

	public void TriggerShowFlareMenuTitle()
	{
		animatorFlareMenuTitle.SetTrigger ("TriggerShow"); 
	}
	
	public void TriggerHideFlareMenuTitle()
	{
		animatorFlareMenuTitle.SetTrigger ("TriggerHide"); 
	}
}
