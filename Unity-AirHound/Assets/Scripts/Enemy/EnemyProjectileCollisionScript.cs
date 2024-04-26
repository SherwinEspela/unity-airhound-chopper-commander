using UnityEngine;
using System.Collections;
using PathologicalGames;

public class EnemyProjectileCollisionScript : MonoBehaviour {
	
	public GameObject[] explosions;
	
	void OnCollisionEnter(Collision collision) {
		//GameObject explosion = explosions[Random.Range(0,explosions.Length)];
		//Instantiate (explosion, transform.position, transform.rotation);
		//Destroy(gameObject,0.05f);
		PoolManager.Pools["Projectiles"].Despawn(gameObject.transform); 
    }

	void OnDespawned()
	{
		GameObject explosion = explosions[Random.Range(0,explosions.Length)];
		//PoolManager.Pools["Explosions"].Spawn(explosion.transform, transform.position, transform.rotation);
		Instantiate (explosion, transform.position, transform.rotation);
	}
}
