using UnityEngine;
using System.Collections;
using PathologicalGames; 

namespace AirHound
{
	public class HealthScript : MonoBehaviour {

		// private
		protected const int collisionDamage = 110;
		private GameObject gameManager; 

		// protected
		protected GameObject chopperHealthCollider;

		// public
		public GameObject mainObjectToDestroy; 
		public int health = 100;
		public int bulletDamage = 1;
		public int rocketDamage = 10;
		public GameObject[] explosions;
		public AudioClip[] hitSounds;
		// chopper health 
		public int bonusHealthMin; 
		public int bonusHealthMax;
		// chopper weapons
		public int bonusRocketMin; 
		public int bonusRocketMax;
		public bool isEnemyObject = false; 
		public ExploderPlacement exploderPlacement;
		public GameObject[] fireDamage;

		// Events
		public delegate void DestroyedAction(); 
		public static event DestroyedAction OnDestroyed;

		void Awake()
		{
			FindTheGameManager(); 
			chopperHealthCollider = GameObject.Find("chopper_healthCollider"); 
		}

		public virtual void HealthReductionEvent() 
		{
			FindTheGameManager(); 
			if (health <= 0) {
				gameObject.BroadcastMessage("AddPoints",SendMessageOptions.DontRequireReceiver);
				if (isEnemyObject) {
					gameObject.BroadcastMessage("AddEnemyDestroyed",SendMessageOptions.DontRequireReceiver); 
				}
				PoolManager.Pools["Environments"].Despawn(mainObjectToDestroy.transform);
				CreateExplosion ();
				PlayRadioChatter ();
			}
		}
			
		void CreateExplosion(){
			if (explosions.Length > 0) {
				GameObject explosion = explosions[Random.Range(0,explosions.Length)]; 
				Instantiate (explosion, transform.position, transform.rotation);	
			}
		}

		public void OnCollisionEnter (Collision col)
		{
			if (col.gameObject.name.Contains("chopperBullet")) {
				health -= bulletDamage;
				if (health <= 0) {
					ExplosionManager.destroyedByRocket = false; 
				}
			}
			
			else if (col.gameObject.name.Contains("rocket")) {
				health -= rocketDamage; 
				if (health <= 0) {
					if (this.transform.root.name.Contains("tank")) {
						ExplosionManager.destroyedByRocket = false;
					}
					else if (this.transform.root.name.Contains("turret")) {
						ExplosionManager.destroyedByRocket = false;
					}
					else {
						ExplosionManager.destroyedByRocket = true;
					}
				}
			}

			HealthReductionEvent(); 
		}
		
		public virtual void DamageByCollision()
		{
			bonusHealthMin = 0; 
			bonusHealthMax = 0; 
			health -= collisionDamage;  
		}
		
		public void playHitSound()
		{
			AudioClip hitSound = hitSounds[Random.Range(0,hitSounds.Length)];
			GetComponent<AudioSource>().PlayOneShot(hitSound);
		}

		protected void PlayRadioChatter(){
			if (gameManager == null) {
				gameManager = GameObject.Find("GameManager"); 
			}
			gameManager.SendMessage("InvokePlayRadiochatter",SendMessageOptions.DontRequireReceiver);
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
				Instantiate (explosion, transform.position, transform.rotation);	
			}
		}

		public void FindTheGameManager()
		{
			if (gameManager == null) {
				gameManager = GameObject.Find("GameManager"); 
			}
		}
			
		public void DoFireDamage()
		{
			if (fireDamage.Length > 0) {
				GameObject fire = fireDamage[Random.Range(0,fireDamage.Length)];
				Instantiate (fire, transform.position, transform.rotation);
			}
		}
			
		public void DoObjectMeshExplosionEffects()
		{
			if (exploderPlacement) {
				exploderPlacement.PlaceExploder();
			}
		}
			
		public virtual void DestroyedEvent()
		{
			if (OnDestroyed != null) {
				OnDestroyed(); 
			}
		}
	}
}