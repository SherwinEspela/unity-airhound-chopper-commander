using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathologicalGames;

namespace AirHound 
{
	public class EnemyMoving : Enemy {

		protected int assignedHealthValue;
		protected DespawnByDistance despawnByDistanceScript;
		protected Transform rootObject;

		void Awake()
		{
			rootObject = transform.root; 
			despawnByDistanceScript = rootObject.gameObject.GetComponent<DespawnByDistance>(); 
			assignedHealthValue = health; 
		}

		void Start()
		{
			assignedHealthValue = health; 
		}

		protected void DespawnMovingEnemy()
		{
			PoolManager.Pools ["Enemies"].Despawn (mainObjectToDestroy.transform);
		}
	}
}
