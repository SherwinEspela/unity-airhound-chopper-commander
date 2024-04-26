using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AirHound
{
	public class Enemy : PlayerTarget
	{
		// public
		public GameObject[] explosions2nd;

		// Events
		public static event DestroyedAction OnEnemyDestroyed;

		public override void AddPoints()
		{
			base.AddPoints ();
			pointScript.AddEnemyDestroyed ();
		}
			
		protected void DoSecondExplosionEffects()
		{
			if (explosions2nd.Length > 0) {
				GameObject explosion2 = explosions2nd[Random.Range(0,explosions2nd.Length)]; 
				Instantiate (explosion2, transform.position, transform.rotation);	
			}
		}
	}	
}