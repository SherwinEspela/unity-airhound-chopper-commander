using UnityEngine;
using System.Collections;

public class JoystickGunScript : MonoBehaviour {

	public GameObject projectile;
	public float fireRate = 0.05f;
	private float audioRate = 1.965f;  
	private float nextFire; 
	private float nextAudioPlay; 
	private float nextRicochet;
	public Transform shootPosition;
	public float speed = 500f; 
	public Transform muzzleFlashTransform; 
	public GameObject muzzleFlashObject;
	public AudioClip[] ricochets; 
	
	// EasyButton Methods
	void onEnable() 
	{
		//EasyButton.On_ButtonPress += On_ButtonPress;
		//EasyButton.On_ButtonUp += ButtonUp;
		
		EasyJoystick.On_JoystickTouchStart += On_JoystickTouchStart;
	}
	
	void On_JoystickTouchStart( MovingJoystick move)
	{
		startFire();
	}
	
//	void On_JoystickMove( MovingJoystick move)
//	{
//		startFire(); 	
//	}
//	
//	void On_JoystickMoveEnd( MovingJoystick move) 
//	{
//		stopFire();
//	}
	
//	void On_ButtonPress (string buttonName)
//	{
//		startFire(); 
//	}
//	
//	void ButtonUp( string buttonName)
//	{
//		stopFire();  
//	}
	
//	void OnDisable(){
//		UnsubscribeEvent();
//	}
//	
//	void UnsubscribeEvent(){
//		EasyButton.On_ButtonPress -= On_ButtonPress;
//		EasyButton.On_ButtonUp -= ButtonUp;
//	}
	
	public void startFire()
	{
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			GameObject clone = (GameObject)(Instantiate (projectile, transform.position, transform.rotation));
			clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0,0,speed));
			
			muzzleFlashObject.SetActive(true); 
			muzzleFlashTransform.SendMessage("PlayMuzzleFlash",SendMessageOptions.DontRequireReceiver);
		}
		
		if (Time.time > nextAudioPlay) {
			nextAudioPlay = Time.time + audioRate;
			if (GetComponent<AudioSource>()) {
				GetComponent<AudioSource>().Play();
			}
		}
		
		if (Time.time > nextRicochet) {
			nextRicochet = Time.time + Random.Range(3,7);
			playRicochetSound();
		}
	}
	
	public void stopFire()
	{
		muzzleFlashObject.SetActive(false); 
		if (GetComponent<AudioSource>()) {
			GetComponent<AudioSource>().Stop();
		}
		
		playRicochetSound(); 
	}
	
	void playRicochetSound()
	{
		AudioClip ricochet = ricochets[Random.Range(0,ricochets.Length)];
		GetComponent<AudioSource>().PlayOneShot(ricochet); 
	}
	
}
