using UnityEngine;
using System.Collections;
using PathologicalGames;

public class ChopperRocketCollisionScript : MonoBehaviour {

	public GameObject[] explosions;
	public GameObject rocketTail; 
	
	void Start()
	{
		Physics.IgnoreLayerCollision(17,18, true);
	}
	
	void OnCollisionEnter(Collision col) {

		if (explosions.Length > 0) {
			GameObject explosion = explosions[Random.Range(0,explosions.Length)];
			Instantiate (explosion, transform.position, transform.rotation);	
		}
		Destroy(rocketTail); 
		gameObject.GetComponent<Renderer>().enabled = false;
		gameObject.GetComponent<Rigidbody>().GetComponent<Collider>().enabled = false; 
		gameObject.GetComponent<Light>().enabled = false; 
		gameObject.BroadcastMessage("StopParticleEmission",SendMessageOptions.DontRequireReceiver); 
		PoolManager.Pools["Projectiles"].Despawn(gameObject.transform,4f);
	}

//	void OnDespawned()
//	{
//		GameObject explosion = explosions[Random.Range(0,explosions.Length)];
//		//Transform rocketExplosion = PoolManager.Pools["Explosions"].Spawn(explosion.transform, transform.position, transform.rotation);
//		Instantiate (explosion, transform.position, transform.rotation);
//	}
}
