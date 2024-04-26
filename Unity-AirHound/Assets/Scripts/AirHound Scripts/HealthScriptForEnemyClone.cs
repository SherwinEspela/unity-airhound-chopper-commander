using UnityEngine;
using System.Collections;
using PathologicalGames; 

namespace AirHound
{	
	public class HealthScriptForEnemyClone : EnemyMoving
	{	
		// Events
		public static event DestroyedAction OnEnemyTankDestroyed;

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

		public override void AddPoints()
		{
			if (pointScript != null) {
				base.AddPoints ();
				pointScript.AddEnemyTanksDestroyed ();
			}
		}

		public override void DestroyedEvent()
		{
			if (OnEnemyTankDestroyed != null) {
				OnEnemyTankDestroyed(); 
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

		public override void ProjectileDamage(Collision collider){
			if (collider.gameObject.name.Contains(CHOPPER_BULLET)) {
				health -= bulletDamage;
				if (health <= 0) {
					ExplosionManager.destroyedByRocket = false; 
				}
			}

			else if (collider.gameObject.name.Contains(ROCKET)) {
				health -= rocketDamage; 
				if (health <= 0) {
					ExplosionManager.destroyedByRocket = false;
				}
			}
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