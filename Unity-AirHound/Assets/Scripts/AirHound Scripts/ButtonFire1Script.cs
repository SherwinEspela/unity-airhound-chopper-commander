using UnityEngine;
using System.Collections;
using PathologicalGames;

public class ButtonFire1Script : MonoBehaviour {
		
	public GameObject projectile;
	public float fireRate = 0.05f;
	private float audioRate = 1.02f; // orig value = 1.965f  
	private float nextFire; 
	private float nextAudioPlay; 
	private float nextRicochet;
	public Transform shootPosition;
	public float speed = 10f; 
	private bool isFiring; 
	public GameObject muzzleFlashLight;
	public Transform muzzleFlashSpawn; 
	public GameObject muzzleFlashPrefab;
	public AudioClip[] ricochets; 

	void Start()
	{

	}

	// EasyButton Methods
	void onEnable() 
	{
		EasyButton.On_ButtonPress += On_ButtonPress;
		EasyButton.On_ButtonUp += ButtonUp;
	}

	void On_ButtonPress (string buttonName)
	{
		startFire();
	}
	
	void ButtonUp( string buttonName)
	{
		stopFire();  
	}
	
	void OnDisable(){
		UnsubscribeEvent();
	}
	
	void UnsubscribeEvent(){
		EasyButton.On_ButtonPress -= On_ButtonPress;
		EasyButton.On_ButtonUp -= ButtonUp;
	}
	
	public void startFire()
	{
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			GameObject muzzleFlashEffect = (GameObject)(Instantiate (muzzleFlashPrefab, muzzleFlashSpawn.position, muzzleFlashSpawn.rotation));
			muzzleFlashEffect.transform.parent = muzzleFlashSpawn.transform; 
			Transform clone = PoolManager.Pools["Projectiles"].Spawn(projectile.transform,transform.position,transform.rotation); 

			clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0,0,speed));

			muzzleFlashLight.SetActive(true); 
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
		muzzleFlashLight.SetActive(false); 
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
