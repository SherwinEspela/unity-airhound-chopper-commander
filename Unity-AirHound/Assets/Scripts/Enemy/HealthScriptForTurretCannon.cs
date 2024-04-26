using UnityEngine;
using System.Collections;
using PathologicalGames; 

public class HealthScriptForTurretCannon : MonoBehaviour, IDetonatable
{
	private GameObject chopperHealthCollider;
	private int collisionDamage = 110;

	public GameObject mainObjectToDestroy; 
	public int health = 100;
	public int bulletDamage = 1;
	public int rocketDamage = 10;
	public GameObject[] explosions;
	public GameObject[] explosions2nd;
	public GameObject[] fireDamage; 
	public AudioClip[] hitSounds;
	public GameObject gameManager; 
	// chopper health 
	public float bonusHealthMin; 
	public float bonusHealthMax;
	// chopper weapons
	public float bonusRocketMin; 
	public float bonusRocketMax;
	public bool isEnemyObject = false; 
	public ExploderPlacement exploderPlacement;

	void Awake()
	{
		if (gameManager == null) {
			gameManager = GameObject.Find("GameManager"); 
		}
		
		chopperHealthCollider = GameObject.Find("chopper_healthCollider"); 
	}

	void HealthReductionEvent() 
	{
		if (health <= 0) {
			DoMeshExplosionEffects ();

			gameManager.SendMessage("InvokePlayRadiochatter",SendMessageOptions.DontRequireReceiver);
			gameObject.BroadcastMessage("AddPoints",SendMessageOptions.DontRequireReceiver);

			if (isEnemyObject) {
				gameObject.BroadcastMessage("AddEnemyDestroyed",SendMessageOptions.DontRequireReceiver); 
			}

			SpawnExplosionFX(); 

			if (explosions2nd.Length > 0) {
				SpawnSecondExplosionFX(); 
			}

			if (fireDamage.Length > 0) {
				GameObject fire = fireDamage[Random.Range(0,fireDamage.Length)];
				Instantiate (fire, transform.position, transform.rotation);
			}

			PoolManager.Pools["Environments"].Despawn(mainObjectToDestroy.transform);
		}
	}

	public void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name.Contains("chopperBullet")) {
			health -= bulletDamage; 
			
		}
		
		else if (col.gameObject.name.Contains("rocket")) {
			health -= rocketDamage; 
		}

		HealthReductionEvent(); 
	}

	void DoMeshExplosionEffects()
	{
		exploderPlacement.PlaceExploder();
		//gameManager.SendMessage("ExplodeObject",SendMessageOptions.DontRequireReceiver);
	}
		
	public void DamageByCollision()
	{
		bonusHealthMin = 0f; 
		bonusHealthMax = 0f; 
		health -= collisionDamage; 
		HealthReductionEvent(); 
	}
	
	public void playHitSound()
	{
		AudioClip hitSound = hitSounds[Random.Range(0,hitSounds.Length)];
		GetComponent<AudioSource>().PlayOneShot(hitSound);
	}
	
	public void DecreaseObjectsHealth(int theDamage)
	{
		health -= theDamage; 
		HealthReductionEvent(); 
	}

	public void SpawnExplosionFX()
	{
		if (explosions.Length > 0) {
			GameObject explosion = explosions[Random.Range(0,explosions.Length)];
			PoolManager.Pools["Explosions"].Spawn(explosion.transform,transform.position,transform.rotation); 	
		}
	}

	public void SpawnSecondExplosionFX()
	{
		GameObject explosion2 = explosions2nd[Random.Range(0,explosions2nd.Length)];
		PoolManager.Pools["Explosions"].Spawn(explosion2.transform,transform.position,transform.rotation); 
	}

	public void Detonate()
	{
		health -= 100;
		HealthReductionEvent ();
	}
}
