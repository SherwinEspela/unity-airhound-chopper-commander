using UnityEngine;
using System.Collections;

public class ButtonFire2Script : MonoBehaviour {

	public Transform rocketSpawnRight;
	public Transform rocketSpawnLeft;
	public Transform rocketMuzzleSpawnRight; 
	public Transform rocketMuzzleSpawnLeft;
	public GameObject muzzleFlashPrefab; 
	private bool launchedLeft = true;
	private GameObject gameManager;
	
	void Start()
	{
		gameManager = GameObject.Find("GameManager"); 
	}
	
	// EasyButton Methods
	void onEnable() 
	{
		EasyButton.On_ButtonDown += On_ButtonDown; 
	}
	
	void OnDisable(){
		UnsubscribeEvent();
	}
	
	void UnsubscribeEvent(){
		EasyButton.On_ButtonDown -= On_ButtonDown;	
	}
	
	void On_ButtonDown (string buttonName)
	{
		startFire(); 
	}
	
	public void startFire()
	{		
		if (!WeaponsInventoryScript.rocketEmpty) {
			FireRockets(); 
		} else {
			PlayNoAmmoSound(); 
		}
	}
	
	void FireRockets()
	{
		if (launchedLeft) {
			rocketSpawnRight.SendMessage("LaunchRocket",SendMessageOptions.DontRequireReceiver);
			GameObject muzzleFlashEffect = (GameObject)(Instantiate (muzzleFlashPrefab, rocketMuzzleSpawnRight.position, rocketMuzzleSpawnRight.rotation));
			launchedLeft = false;
		} else {
			rocketSpawnLeft.SendMessage("LaunchRocket",SendMessageOptions.DontRequireReceiver);
			GameObject muzzleFlashEffect = (GameObject)(Instantiate (muzzleFlashPrefab, rocketMuzzleSpawnLeft.position, rocketMuzzleSpawnLeft.rotation));
			launchedLeft = true;	
		}
		
		decreaseRocket();
	}
	
	void decreaseRocket()
	{
		gameManager.SendMessage("DecreaseRocketInventory",SendMessageOptions.DontRequireReceiver); 
	}
	
	void PlayNoAmmoSound()
	{
		gameManager.SendMessage("PlayNoAmmoSound",SendMessageOptions.DontRequireReceiver); 
	}
}
