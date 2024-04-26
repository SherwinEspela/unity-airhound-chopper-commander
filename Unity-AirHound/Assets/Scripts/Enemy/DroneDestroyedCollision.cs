using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AirHound 
{
	public class DroneDestroyedCollision : MonoBehaviour {

		public HealthScriptForEnemyDrones healthScriptForEnemyDronesScript; 

		public void OnCollisionEnter (Collision col)
		{
			healthScriptForEnemyDronesScript.CompleteEnemyDroneDestruction ();

			try {
				foreach (ContactPoint contact in col.contacts)
				{
					if (contact.otherCollider.gameObject.GetComponent<HealthScriptForEnemyClone>()) {
						contact.otherCollider.gameObject.GetComponent<HealthScriptForEnemyClone> ().Detonate ();	
					}

					if (contact.otherCollider.gameObject.GetComponent<EnemyDrone1>()) {
						contact.otherCollider.gameObject.GetComponent<EnemyDrone1> ().Detonate ();	
					}

					if (contact.otherCollider.gameObject.GetComponent<EnemyDrone2>()) {
						contact.otherCollider.gameObject.GetComponent<EnemyDrone2> ().Detonate ();	
					}

					if (contact.otherCollider.gameObject.GetComponent<HealthScriptForEnviroment>()) {
						contact.otherCollider.gameObject.GetComponent<HealthScriptForEnviroment> ().Detonate ();	
					}

					if (contact.otherCollider.gameObject.GetComponent<HealthScriptForTurretCannon>()) {
						contact.otherCollider.gameObject.GetComponent<HealthScriptForTurretCannon> ().Detonate ();	
					}
				}
			} catch (System.Exception ex) {
				Debug.Log (ex.Message);
			}
		}

		void Update(){}
	}
}