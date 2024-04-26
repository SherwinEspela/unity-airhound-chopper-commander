using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathologicalGames;

namespace AirHound
{
	public class HealthScriptForEnemyDrones : EnemyMoving
	{
		// private
		private bool isDestroyed = false;
		private BoxCollider boxCollider;
		private Rigidbody rigidBody;

		// public
		public GameObject enemyDroneMesh;
		public Vector3 originalDroneMeshPosition;
		public DroneDestroyedCollision droneDestroyedCollisionScript;
		public MoveEnemyPositionForAirDrone moveEnemyPositionForAirDroneScript;
		public EnemyFiringDistance enemyFiringDistanceScript;
		public VPositionCyclerForAirDrone vPositionCyclerForAirDroneScript;
		public LookAtChopperShootTransform lookAtChopperShootTransformScript;
		public EnemyFire1Script enemyFire1Script; // script in Drone 2
		public EnemyDroneFireScript[] enemyDroneFireScripts;
		public Collider[] droneColliders;

		// event
		public static event DestroyedAction OnEnemyDroneDestroyed;

		void Start()
		{
			droneDestroyedCollisionScript.enabled = false;
		}

		// Callbacks
		void OnSpawned()
		{
			isDestroyed = false;
		}

//		void OnDespawned()
//		{
//			AreScriptsEnabled (true);
//			SetDroneMeshOriginalPosition ();
//			droneDestroyedCollisionScript.enabled = false;
//		}
			
		protected void SetDroneMeshOriginalPosition()
		{
			enemyDroneMesh.transform.localPosition = originalDroneMeshPosition;	
		}

		public override void HealthReductionEvent() 
		{
			if (health <= 0) {
				isDestroyed = true;
				AddPoints ();
				EnemyDroneDeathAction ();	 
			}
		}

		public override void AddPoints()
		{
			if (pointScript != null) {
				base.AddPoints ();
				pointScript.AddEnemyAirDronesDestroyed ();
			}
		}

		public virtual void CompleteEnemyDroneDestruction()
		{
			DoObjectMeshExplosionEffects ();
			if (isDestroyed) {
				EnemyDroneSecondExplosionFX ();
			} else {
				DoSecondExplosionEffects ();
			}
			PlayRadioChatter ();
			DestroyedEvent();
			DespawnMovingEnemy ();
		}

		void EnemyDroneSecondExplosionFX(){
			if (explosions2nd.Length > 0) {
				GameObject explosion2 = explosions2nd[Random.Range(0,explosions2nd.Length)]; 
				Instantiate (
					explosion2,
					enemyDroneMesh.transform.position,
					enemyDroneMesh.transform.rotation
				);	
			}
		}

		public override void DestroyedEvent()
		{
			if (OnEnemyDroneDestroyed != null) {
				OnEnemyDroneDestroyed ();
			}
		}

		public void OnCollisionEnter (Collision collision)
		{
			ProjectileDamage(collision);
			HealthReductionEvent ();
		}

		public override void DamageByCollision()
		{
			if (!isDestroyed) {
				health -= collisionDamage; 
				HealthReductionEvent ();
			}
		}

		void EnemyDroneDeathAction()
		{
			int choice = Random.Range (0, 10);
			if (choice > 2) {
				EnemyDroneFallingDeathAction ();
			} else {
				CompleteEnemyDroneDestruction ();
			}
		}

		void EnemyDroneFallingDeathAction(){

			// enable DroneDestroyedCollision script
			if (droneDestroyedCollisionScript) {
				droneDestroyedCollisionScript.enabled = true;
			}
				
			AreScriptsEnabled(false);

			// add collider for mesh
			if (boxCollider == null) {
				boxCollider = enemyDroneMesh.AddComponent<BoxCollider>();	
			}

			AddRigidBodyToDroneMesh ();
		}
			
		protected void AreScriptsEnabled(bool enabled)
		{
			despawnByDistanceScript.enabled = enabled;
			moveEnemyPositionForAirDroneScript.enabled = enabled;
			if(enemyFiringDistanceScript){
				enemyFiringDistanceScript.enabled = enabled;
			}
			if (enemyFire1Script) {
				enemyFire1Script.enabled = enabled;
			}
			vPositionCyclerForAirDroneScript.enabled = enabled;
			lookAtChopperShootTransformScript.enabled = enabled;

			if (enemyDroneFireScripts.Length > 0) {
				foreach (var fireScript in enemyDroneFireScripts) {
					fireScript.enabled = enabled;
				}	
			}
				
			foreach (var collider in droneColliders) {
				collider.enabled = enabled;
			}
		}

		void AddRigidBodyToDroneMesh()
		{
			if (rigidBody == null) {
				rigidBody = enemyDroneMesh.AddComponent<Rigidbody>();
			}
				
			rigidBody.useGravity = true;
			rigidBody.mass = 10f;

			// add force and torque action
			float pushForce = Random.Range(90f,130f);
			float torqueForce = Random.Range (100f, 200f);
			float xForce = 0f;
			if (TurnChopperScript.isChopperFacingBack) {
				xForce = Random.Range (-10f,-20f);	
			} else {
				xForce = Random.Range (10f,20f);
			}
			float yForce = Random.Range (-0.2f,-1.0f);
			float xTorque = Random.Range (5f,50f);
			float yTorque = Random.Range (2f,10f);
			float zTorque = Random.Range (5f,30f);

			rigidBody.AddForce(new Vector3(xForce,yForce,0f) * pushForce);
			rigidBody.AddTorque (new Vector3 (xTorque, yTorque, zTorque) * torqueForce);
		}
	}
}