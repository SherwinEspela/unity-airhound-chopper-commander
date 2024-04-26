using UnityEngine;
using System.Collections;
using PathologicalGames;

namespace AirHound 
{
	public class HealthScriptForEnviroment : PlayerTarget, IDetonatable
	{
		// Private variables

		// Public variables
		public bool isNukeCrate;
		public GameObject nukeCrateMesh; 
		public bool nukeIsNotDestroyed = true; 

		public override void HealthReductionEvent()
		{
			if (health <= 0) {
				if (isNukeCrate) {
					if (nukeIsNotDestroyed) {
						nukeCrateMesh.SetActive(false);	

						if (fireDamage.Length > 0) {
							foreach (GameObject explosion in fireDamage) {
								Instantiate (explosion, transform.position, transform.rotation);
							}
						}

						nukeIsNotDestroyed = false; 
					}
				} else {
					DoObjectMeshExplosionEffects();
					SpawnExplosionFX();
					DoFireDamage ();
					AddPoints ();
					DespawnEnvironmentObject ();
				}
			}
		}

		void DespawnEnvironmentObject()
		{
			PoolManager.Pools["Environments"].Despawn(mainObjectToDestroy.transform);
		}

		public void SetNukeIsNotDestroyed()
		{
			nukeIsNotDestroyed = true; 
		}

		void OnCollisionEnter (Collision col)
		{
			ProjectileDamage (col);
			HealthReductionEvent (); 
		}

		public override void DamageByCollision()
		{
			base.DamageByCollision ();
			HealthReductionEvent();
		}

		public void Detonate()
		{
			health -= 100;
			HealthReductionEvent ();
		}
	}
}