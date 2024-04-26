using UnityEngine;
using System.Collections;
using PathologicalGames;

public class ChopperProjectileCollisionScript : MonoBehaviour {

	public GameObject[] explosions;
	
	void Start()
	{
		Physics.IgnoreLayerCollision(17,18, true);
	}
	
	void OnCollisionEnter(Collision col) {
		gameObject.GetComponent<Rigidbody>().GetComponent<Collider>().enabled = false; 
		PoolManager.Pools["Projectiles"].Despawn(gameObject.transform);
    }

	void OnDespawned()
	{
		GameObject explosion = explosions[Random.Range(0,explosions.Length)];
		Instantiate (explosion, transform.position, transform.rotation);
	}
}
