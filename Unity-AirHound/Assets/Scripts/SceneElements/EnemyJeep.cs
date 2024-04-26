using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AirHound 
{
	public class EnemyJeep : EnemyMoving, IRewardable
	{
		// Events
		public static event DestroyedAction OnEnemyJeepDestroyed;

		public override void HealthReductionEvent() 
		{
			if (health <= 0) {
				DespawnMovingEnemy ();
				SpawnExplosionFX(); 
				DoObjectMeshExplosionEffects ();
				DoSecondExplosionEffects ();
				DoFireDamage ();
				PlayRadioChatter ();
				IncreaseRocketReward ();
				IncreaseHealthReward ();
				Invoke("ShowPanelIncrease",1f);
				AddPoints();
				DestroyedEvent();
			}
		}

		public override void DestroyedEvent()
		{
			if (OnEnemyJeepDestroyed != null) {
				OnEnemyJeepDestroyed(); 
			}
		}

		void OnDespawned()
		{
			health = assignedHealthValue; 
		}

		void ShowPanelIncrease()
		{
			GameManagerScript.gameManagerStatic.SendMessage("ShowPanelIncrease",SendMessageOptions.DontRequireReceiver); // from ControlsVisibilityScript.cs
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

		public void Detonate()
		{
			health -= 100;
			HealthReductionEvent();
		}

		// IRewardable Methods
		public void IncreaseRocketReward()
		{
			int bonusRocket = Random.Range(bonusRocketMin,bonusRocketMax); 
			GameManagerScript.gameManagerStatic.SendMessage("AddRocketInventory",bonusRocket); 
			GameManagerScript.gameManagerStatic.SendMessage(
				"SetTextRocketIncrease",
				bonusRocket.ToString(),
				SendMessageOptions.DontRequireReceiver
			); // from ControlsVisibilityScript.cs
		}

		public void IncreaseHealthReward()
		{
			int bonusHealth = Random.Range(bonusHealthMin,bonusHealthMax); 
			if (chopperHealthCollider) {
				chopperHealthCollider.SendMessage(
					"AddHealth",
					(float)(bonusHealth),
					SendMessageOptions.DontRequireReceiver
				); 
			}
			 
			GameManagerScript.gameManagerStatic.SendMessage(
				"SetTextHealthIncrease",
				bonusHealth.ToString(),
				SendMessageOptions.DontRequireReceiver
			); // from ControlsVisibilityScript.cs
		}
	}
}