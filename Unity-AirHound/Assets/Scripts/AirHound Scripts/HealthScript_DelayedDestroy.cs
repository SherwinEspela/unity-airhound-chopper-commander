using UnityEngine;
using System.Collections;

public class HealthScript_DelayedDestroy : MonoBehaviour {
	
	private bool destructionSequenceDone = false; 
	private Transform rootObject; 

	public int health = 100;
	public int bulletDamage = 1;
	public int rocketDamage = 10;
	public GameObject[] explosions;
	private int collisionDamage = 110;
	public AudioClip[] hitSounds;
	public GameObject gameManager; 
	
	// chopper health 
	private GameObject chopperHealthCollider;
	public int bonusHealthMin; 
	public int bonusHealthMax;
	
	// chopper weapons
	public int bonusRocketMin; 
	public int bonusRocketMax;

	private bool destroyedByCollision = false; 

	public GameObject[] explosions2nd;
	public GameObject fireDamage1;
	public GameObject fireDamage2; 

	public ExploderPlacement exploderPlacement;

	public AudioClip bigExplosionSound; 

	void Awake()
	{
		rootObject = transform.root;

		if (gameManager == null) {
			gameManager = GameObject.Find("GameManager"); 
		}
		
		chopperHealthCollider = GameObject.Find("chopper_healthCollider"); 
	}

	void HealthReductionEvent() 
	{
		if (health <= 0) {
			RunDestructionSequence();
		}
	}
	
	void RunDestructionSequence() 
	{
		if (!destructionSequenceDone) {
			if (explosions.Length > 0) {
				GameObject explosion = explosions[Random.Range(0,explosions.Length)]; 
				Instantiate (explosion, transform.position, transform.rotation);	
			}

			if (GetComponent<AudioSource>()) {
				GetComponent<AudioSource>().PlayOneShot(bigExplosionSound);
			}

			AddHealthToChopper();
			AddRocketToChopper();
			Invoke("ShowPanelIncrease",1f);

			destructionSequenceDone = true;
			gameObject.BroadcastMessage("AddPoints",SendMessageOptions.DontRequireReceiver); 

			DoMeshExplosionEffects();

			if (!destroyedByCollision) {
				gameManager.SendMessage("InvokeOhYeahChatter",SendMessageOptions.DontRequireReceiver);
			}

			if (explosions2nd.Length > 0) {
				GameObject explosion2 = explosions2nd[Random.Range(0,explosions2nd.Length)]; 
				Instantiate (explosion2, transform.position, transform.rotation);	
			}

			Instantiate (fireDamage1, transform.position, transform.rotation);
			Instantiate (fireDamage2, transform.position, transform.rotation);

			rootObject.SendMessage("InvokeDestroyObject");
		}
	}

	void DoMeshExplosionEffects()
	{
		exploderPlacement.PlaceExploder();
		//gameManager.SendMessage("ExplodeObject",SendMessageOptions.DontRequireReceiver);
	}

	void ShowPanelIncrease()
	{
		GameManagerScript.gameManagerStatic.SendMessage("ShowPanelIncrease",SendMessageOptions.DontRequireReceiver); // from ControlsVisibilityScript.cs
	}

	public void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name.Contains("chopperBullet")) {
			health -= bulletDamage;
			ExplosionManager.destroyedByRocket = true;
		}
		
		else if (col.gameObject.name.Contains("rocket")) {
			health -= rocketDamage; 
			ExplosionManager.destroyedByRocket = true;
		}

		HealthReductionEvent(); 
	}
	
	public void DamageByCollision()
	{
		bonusHealthMin = 0;
		bonusHealthMax = 0; 
		health -= collisionDamage; 
		destroyedByCollision = true; 
		HealthReductionEvent(); 
	}
	
	public void playHitSound()
	{
		AudioClip hitSound = hitSounds[Random.Range(0,hitSounds.Length)];
		GetComponent<AudioSource>().PlayOneShot(hitSound);
	}
	
	public void AddHealthToChopper()
	{
		int bonusHealth = Random.Range(bonusHealthMin,bonusHealthMax); 
		chopperHealthCollider.SendMessage("AddHealth",bonusHealth);
		GameManagerScript.gameManagerStatic.SendMessage("SetTextHealthIncrease",bonusHealth.ToString(),SendMessageOptions.DontRequireReceiver); // from ControlsVisibilityScript.cs
	}
	
	public void AddRocketToChopper()
	{
		int bonusRocket = Random.Range(bonusRocketMin,bonusRocketMax); 
		gameManager.SendMessage("AddRocketInventory",bonusRocket); 
		GameManagerScript.gameManagerStatic.SendMessage("SetTextRocketIncrease",bonusRocket.ToString(),SendMessageOptions.DontRequireReceiver); // from ControlsVisibilityScript.cs
	}
	
	public void DecreaseObjectsHealth(int theDamage)
	{
		health -= theDamage; 
		HealthReductionEvent();
	}
}
