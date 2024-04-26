using UnityEngine;
using System.Collections;
using PathologicalGames;

public class EnemyFire1Script : MonoBehaviour {
	
	public GameObject projectile;
	public Transform target;
	public float fireRateMin = 1.0f; 
	public float fireRateMax = 2.0f;
	private float audioRate = 1.965f;  
	private float nextFire; 
	private float nextAudioPlay; 
	public Transform shootPosition;
	public float speed = 10f; 
	public Transform muzzleFlashSpawn; 
	public GameObject muzzleFlashPrefab; 
	public GameObject muzzleFlashLight;
	public Transform recoilController;
	public float rangeMax = 9;
	public float rangeMin = 0;
	
	// Use this for initialization
	void Start () {
		if (target == null) {
			GameObject targetObject = GameObject.Find("chopperMain");
			if (targetObject) {
				target = targetObject.transform;	
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (target) {
			if ((Vector3.Distance(transform.position, target.position) < rangeMax) && 
			    ((transform.position.x - target.position.x) > rangeMin)) {	
				startFire(); 
			}
			
			else if ((Vector3.Distance(transform.position, target.position) < rangeMax) && 
			         ((target.position.x - transform.position.x) > rangeMin)) {	
				startFire(); 
			}	
		}
	}
	
	public void startFire()
	{	
		if (Time.time > nextFire) {
			float randomFireRate = Random.Range(fireRateMin,fireRateMax); 
			nextFire = Time.time + randomFireRate;

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

			if (recoilController) {
				recoilController.SendMessage("PlayRecoil",SendMessageOptions.DontRequireReceiver);	
			}
		}
	}
}
