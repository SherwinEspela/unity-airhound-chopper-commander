using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathologicalGames;

namespace AirHound 
{
	public class EnemyDrone2 : HealthScriptForEnemyDrones, IDetonatable
	{

		private const int HEALTH_ENEMY_DRONE2 = 8;

		void OnDespawned()
		{
			health = HEALTH_ENEMY_DRONE2;
			AreScriptsEnabled (true);
			SetDroneMeshOriginalPosition ();
			droneDestroyedCollisionScript.enabled = false;
		}
			
		public void Detonate()
		{
			health -= 100;
			HealthReductionEvent ();
		}
	}
}