using UnityEngine;
using System.Collections;
using PathologicalGames; 

public class EnemyTank3FireScript : MonoBehaviour {

	public GameObject projectile;
	public Transform target; 
	public float fireRate = 2.0f;
	public float firePause = 2.0f; 
	private float nextFirePause; 
	private float audioRate = 1.965f;  
	private float nextFire; 
	private float nextAudioPlay; 
	public float speed = 10f; 
	public Transform muzzleFlashSpawn; 
	public GameObject muzzleFlashPrefab; 
	public GameObject muzzleFlashLight;
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
		Fire(); 
	}
	
	public void stopFire()
	{
		muzzleFlashLight.SetActive(false); 
	}
	
	void FireWithPause()
	{
		if (Time.time > nextFirePause) {
			nextFirePause = Time.time + firePause;
		
			Fire();
		}
	}
	
	void Fire()
	{
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;

			GameObject muzzleFlashEffect = (GameObject)(Instantiate (muzzleFlashPrefab, muzzleFlashSpawn.position, muzzleFlashSpawn.rotation));
			muzzleFlashEffect.transform.parent = muzzleFlashSpawn.transform; 

			Transform clone = PoolManager.Pools["Projectiles"].Spawn(projectile.transform, transform.position, transform.rotation); 
			clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0,0,speed));

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
	
//	public void setDelayedFiring()
//	{
//		delayedFiring = true; 
//	}
}
