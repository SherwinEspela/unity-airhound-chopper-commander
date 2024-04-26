using UnityEngine;
using System.Collections;
using PathologicalGames; 

public class EnemyTankFireScript : MonoBehaviour {

	public GameObject projectile;
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
	private bool isFiring = false; 
	
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey("SFXVolume")) {
			if (PlayerPrefs.GetFloat("SFXVolume") >= 0.7f) {
				gameObject.GetComponent<AudioSource>().volume = 0.7f;
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
	}
	
	public void startFire()
	{		
		Fire();
	}
	
	public void stopFire()
	{
		//muzzleFlashLight.SetActive(false); 
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
}
