using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AirHound 
{
	public class EnemyBuzzer : EnemyMoving
	{
		// Events
		public static event DestroyedAction OnEnemyBuzzerDestroyed;

		public override void HealthReductionEvent() 
		{
			if (health <= 0) {
				DespawnMovingEnemy ();
				SpawnExplosionFX(); 
				DoObjectMeshExplosionEffects ();
				DoSecondExplosionEffects ();
				DoFireDamage ();
				PlayRadioChatter ();
				AddPoints();
				DestroyedEvent();
			}
		}

		public override void DestroyedEvent()
		{
			if (OnEnemyBuzzerDestroyed != null) {
				OnEnemyBuzzerDestroyed(); 
			}
		}

		void OnDespawned()
		{
			health = assignedHealthValue; 
		}

		public void OnCollisionEnter (Collision col)
		{
			ProjectileDamage (col);
			HealthReductionEvent();
		}

		public override void DamageByCollision()
		{
			base.DamageByCollision ();
			HealthReductionEvent();
		}

		// IDetonatable Method
		public void Detonate()
		{
			health -= 100;
			HealthReductionEvent();
		}
	}
}