using UnityEngine;
using System.Collections;
using PathologicalGames; 

public class DespawnEnemyRocket : MonoBehaviour {

	public ParticleSystem rocketExplosion; 
	private float life = 4f; 
	private bool hasDespawned = false; 

	void Start()
	{
		Physics.IgnoreLayerCollision(17,18, true);
	}

	public void InvokeForceDespawnTheRocket()
	{
		Invoke ("ForceDespawnTheRocket",life); 
	}

	void ForceDespawnTheRocket()
	{
		if (!hasDespawned) {
			PoolManager.Pools ["ExplosionFX"].Spawn (rocketExplosion, this.transform.position, this.transform.rotation);
			PoolManager.Pools ["Projectiles"].Despawn (this.transform);	
		}
	}

	void OnCollisionEnter(Collision col) {
		PoolManager.Pools ["ExplosionFX"].Spawn (rocketExplosion, this.transform.position, this.transform.rotation);
		PoolManager.Pools ["Projectiles"].Despawn (this.transform);
		hasDespawned = true; 
	}

	void OnSpawned()
	{
		hasDespawned = false;
	}

	void OnDespawned()
	{
		// reset the rockets position and rotation values
		this.transform.position = new Vector3 (0,0,0); 
		this.transform.rotation = new Quaternion (0, 0, 0, 0);  
	}
}
