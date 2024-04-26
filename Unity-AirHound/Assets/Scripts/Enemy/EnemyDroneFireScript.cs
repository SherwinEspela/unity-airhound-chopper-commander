using UnityEngine;
using System.Collections;
using PathologicalGames; 

public class EnemyDroneFireScript : MonoBehaviour {

	public GameObject projectile;
	public Transform target; 
	public float fireRate = 2.0f;
	private float firePause = 2.0f; 
	private float nextFirePause; 
	private float audioRate = 1.965f;  
	private float nextFire; 
	private float nextAudioPlay; 
	public float speed = 10f; 
	public Transform muzzleFlashSpawn; 
	public GameObject muzzleFlashPrefab; 
	public GameObject muzzleFlashLight;
	public bool delayedFiring;
	public bool isTheOneDelayed; 
	private bool isAttacking = false; 
	private bool isFiring = false; 
	
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey("SFXVolume")) {
			if (PlayerPrefs.GetFloat("SFXVolume") >= 0.62f) {
				gameObject.GetComponent<AudioSource>().volume = 0.62f;
			} else {
				gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFXVolume"); 
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isFiring) {
			startFire();
		} else {
			stopFire(); 
		}
		
		if (isAttacking) {
			toggleFiring(); 
		}
	}
	
	public void startFire()
	{	
		if (delayedFiring) {
			nextFire = Time.time + (fireRate + (fireRate/2));
			Fire(); 
			delayedFiring = false; 
		} else {
			Fire(); 
		}
	}
	
	public void stopFire()
	{
		muzzleFlashLight.SetActive(false); 
	}
	
	void Fire()
	{
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			GameObject muzzleFlashEffect = (GameObject)(Instantiate (muzzleFlashPrefab, muzzleFlashSpawn.position, muzzleFlashSpawn.rotation));
			muzzleFlashEffect.transform.parent = muzzleFlashSpawn.transform; 

			Transform clone = PoolManager.Pools["Projectiles"].Spawn(projectile.transform, transform.position, transform.rotation); 
			clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0,0,speed));
			//clone.parent = null; 

			DespawnEnemyRocket derScript = clone.GetComponent<DespawnEnemyRocket>(); 
			if (derScript) {
				derScript.InvokeForceDespawnTheRocket(); 
			}

			if (GetComponent<AudioSource>()) {
				GetComponent<AudioSource>().Play();
			}
			
			muzzleFlashLight.SetActive(true); 
		}
	}
	
	private void toggleFiring()
	{
		if (Time.time > nextFirePause) {
			nextFirePause = Time.time + firePause;
			if (isFiring) {
				isFiring = false;	
			} else {
				isFiring = true;
				if (isTheOneDelayed) {
					delayedFiring = true; 
				}
			}
		}
	}
	
	public void setIsFiring()
	{
		isFiring = true; 
	}
	
	public void setIsNotFiring()
	{
		isFiring = false; 
	}
	
	public void setIsAttacking()
	{
		isAttacking = true; 
		nextFirePause = Time.time + firePause;
	}
	
	public void setIsNotAttacking()
	{
		isAttacking = false; 
	}
	
	public void setDelayedFiring()
	{
		delayedFiring = true; 
	}
}
