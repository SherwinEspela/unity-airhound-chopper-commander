using UnityEngine;
using System.Collections;

public class EnemyFiringDistance : MonoBehaviour {

	private Transform chopperMain; 
	private float distance; 
	private float firingDistance = 11f; 

	public GameObject firePoint;
	public GameObject[] firePoints; 
	public bool isArialDrone = false; 

	void Start()
	{
		chopperMain = GameObject.FindGameObjectWithTag ("Player").transform; 
	}

	// Update is called once per frame
	void Update () {
		if (isArialDrone) {
			UpdateArialEnemyDistance(); 			
		} else {
			UpdateGroundEnemyDistance ();
		}
	}

	void UpdateGroundEnemyDistance()
	{
		distance = Vector3.Distance (this.transform.position,chopperMain.position); 
		if (distance <= firingDistance) {
			if (firePoint) {
				firePoint.SendMessage("setIsFiring",SendMessageOptions.DontRequireReceiver);
				firePoint.SendMessage("setIsAttacking",SendMessageOptions.DontRequireReceiver);	
			}
		} else { 
			if (firePoint) {
				firePoint.SendMessage("setIsNotFiring",SendMessageOptions.DontRequireReceiver);
				firePoint.SendMessage("setIsNotAttacking",SendMessageOptions.DontRequireReceiver);	
			}
		}
	}

	void UpdateArialEnemyDistance()
	{
		distance = Vector3.Distance (this.transform.position,chopperMain.position); 
		if (distance <= firingDistance) {
			if (firePoints != null) {
				foreach (var firePoint in firePoints) {
					firePoint.SendMessage("setIsFiring",SendMessageOptions.DontRequireReceiver);
					firePoint.SendMessage("setIsAttacking",SendMessageOptions.DontRequireReceiver);
				}
			}
		} else { 
			if (firePoints !=  null) {
				foreach (var firePoint in firePoints) {
					firePoint.SendMessage("setIsNotFiring",SendMessageOptions.DontRequireReceiver);
					firePoint.SendMessage("setIsNotAttacking",SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
}
