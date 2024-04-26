using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AirHound 
{
	public class PlayerTarget : HealthScript {

		// Protected constants
		protected const string CHOPPER_BULLET = "chopperBullet";
		protected const string ROCKET = "rocket";

		// Public
		public PointsScript pointScript;

		public virtual void AddPoints()
		{
			if (pointScript != null) {
				pointScript.AddPoints();	
			}
		}

		public virtual void ProjectileDamage(Collision collider){
			if (collider.gameObject.name.Contains(CHOPPER_BULLET)) {
				health -= bulletDamage;
				if (health <= 0) {
					ExplosionManager.destroyedByRocket = false; 
				}
			}

			else if (collider.gameObject.name.Contains(ROCKET)) {
				health -= rocketDamage; 
				if (health <= 0) {
					ExplosionManager.destroyedByRocket = true;
				}
			}
		}
	}
}